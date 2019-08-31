using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace GenericDesignPatterns.Creational
{
    public class Builder<T>
    where T : class
    {
        private class PropertyWrapper
        {
            public PropertyInfo Property { get; }
            public object Value { get; set; }

            internal PropertyWrapper(PropertyInfo property, object value)
            {
                Property = property;
                Value = value;
            }
        }

        private readonly IDictionary<string, PropertyWrapper> _propertiesInfo = new Dictionary<string, PropertyWrapper>();

        public Builder()
        {
            PropertyInfo[] properties = typeof(T).GetProperties();
            foreach (PropertyInfo p in properties)
            {
                _propertiesInfo.Add(p.Name, new PropertyWrapper(p, null));
            }
        }

        public Builder<T> SetProperty<TValue>(
            Expression<Func<T, TValue>> property, TValue value)
        {
            var body = property.Body as MemberExpression;
            if (body == null)
            {
                throw new InvalidOperationException("Improperly formatted expression");
            }
            var propertyName = body.Member.Name;
            if (!_propertiesInfo[propertyName].Property.CanWrite)
            {
                throw new ReadOnlyException($"{propertyName} is readonly, please remove it from builder sequence");
            }
            _propertiesInfo[propertyName].Value = value;
            return this;
        }

        public T Build(Func<T> instance)
        {
            T localInstance = instance();
            PropertyInfo[] instanceProperties = localInstance.GetType().GetProperties();

            PropertyInfo[] matchingProperties =
            (from tProperty in instanceProperties
             from localProperty in _propertiesInfo
             where tProperty.Name == localProperty.Key &&
               tProperty.PropertyType == localProperty.Value.Property.PropertyType
             select localProperty.Value.Property).ToArray();

            foreach (PropertyInfo p in matchingProperties)
            {
                if (p.CanWrite)
                {
                    p.SetValue(localInstance, _propertiesInfo[p.Name].Value);
                }
            }
            return localInstance;
        }

        public T Build() => Build(() => (T)Activator.CreateInstance(typeof(T)));
    }
}
