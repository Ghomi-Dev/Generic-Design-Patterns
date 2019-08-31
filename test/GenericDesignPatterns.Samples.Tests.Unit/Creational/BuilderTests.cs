using FluentAssertions;
using GenericDesignPatterns.Creational;
using GenericDesignPatterns.Samples.SampleClasses;
using System;
using System.Collections.Generic;
using System.Data;
using Xunit;

namespace GenericDesignPatterns.Samples.Tests.Unit.Creational
{
    public class BuilderTests
    {
        private School _school;

        public BuilderTests()
        {
            _school = null;
            var schoolBuilder = new Builder<School>();
            var managerBuilder = new Builder<Manager>();
            var teacherBuilder = new Builder<Teacher>();
            var students = new List<Student>();

            students.Add(new Builder<Student>().SetProperty(entity => entity.Name, "Bruce")
                .SetProperty(entity => entity.Age, 14)
                .Build());

            _school = schoolBuilder.SetProperty(entity => entity.Name, "Master School")
                .SetProperty(entity => entity.Manager, managerBuilder.SetProperty(entity => entity.Name, "John")
                    .SetProperty(entity => entity.Salary, 10000)
                    .Build())
                .SetProperty(entity => entity.Teacher, teacherBuilder.SetProperty(entity => entity.Name, "John")
                    .SetProperty(entity => entity.ClassroomName, "Classroom 1")
                    .SetProperty(entity => entity.Students, students)
                    .Build())
                .Build();
        }

        [Fact]
        public void Should_created_school_instance_not_be_null()
        {
            //Arrange

            //Act

            //Assert
            _school.Should().NotBeNull();
        }

        [Fact]
        public void Should_created_school_instance_name_be_correct()
        {
            //Arrange

            //Act

            //Assert
            _school.Name.Should().Be("Master School");
        }

        [Fact]
        public void Should_created_school_instance_teacher_has_at_least_one_student()
        {
            //Arrange

            //Act

            //Assert
            _school.Teacher.Students.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void Should_created_school_instance_readonly_Id_property_set_value_throw_exception()
        {
            //Arrange
            var schoolBuilder = new Builder<School>();

            //Act
            Action buildAction = () => schoolBuilder.SetProperty(entity => entity.Id, Guid.NewGuid()).Build();

            //Assert

            buildAction.Should().Throw<ReadOnlyException>()
                .WithMessage("Id is readonly, please remove it from builder sequence");
        }

        [Fact]
        public void Should_created_school_instance_empty_body_throw_exception()
        {
            //Arrange
            var schoolBuilder = new Builder<School>();

            //Act
            Action buildAction = () => schoolBuilder.SetProperty(entity => null, new Manager()).Build();

            //Assert
            buildAction.Should().Throw<InvalidOperationException>()
                .WithMessage("Improperly formatted expression");
        }

    }
}
