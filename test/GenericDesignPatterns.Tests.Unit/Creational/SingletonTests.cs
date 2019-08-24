using FluentAssertions;
using GenericDesignPatterns.Creational;
using GenericDesignPatterns.Tests.Unit.Samples;
using Xunit;

namespace GenericDesignPatterns.Tests.Unit.Creational
{
    public class SingletonTests
    {
        [Fact]
        public void Should_have_not_null_instance()
        {
            //Arrange

            //Act

            //Assert
            Singleton<SampleClass>.Instance.Should().NotBeNull();
        }

        [Fact]
        public void Should_have_accessible_vale_when_using_instance()
        {
            //Arrange
            Singleton<SampleClass>.Instance.Age = 30;

            //Act

            //Assert
            Singleton<SampleClass>.Instance.Age.Should().Be(30);
        }
    }
}
