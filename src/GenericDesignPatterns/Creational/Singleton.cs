using System;

namespace GenericDesignPatterns.Creational
{
    public sealed class Singleton<T> where T : class, new()
    {
        private static readonly Lazy<T> _instance = new Lazy<T>(() => new T());
        private Singleton()
        {

        }
        public static T Instance => _instance.Value;

    }
}
