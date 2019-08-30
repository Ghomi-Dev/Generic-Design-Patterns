using FluentAssertions;
using GenericDesignPatterns.Creational;
using GenericDesignPatterns.Samples.SampleClasses;
using Xunit;

namespace GenericDesignPatterns.Sample.Tests.Unit.Creational
{
    public class SingletonTests
    {
        [Fact]
        public void Should_have_not_null_instance()
        {
            //Arrange

            //Act

            //Assert
            Singleton<Student>.Instance.Should().NotBeNull();
        }

        [Fact]
        public void Should_have_accessible_vale_when_using_instance()
        {
            //Arrange
            Singleton<Student>.Instance.Name = "John";
            Singleton<Student>.Instance.Age = 30;

            //Act

            //Assert
            Singleton<Student>.Instance.Name.Should().Be("John");
            Singleton<Student>.Instance.Age.Should().Be(30);
        }
    }
}
