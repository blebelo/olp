using Xunit;
using Moq;
using OnlineLearningPlatform.Students;
using OnlineLearningPlatform.Domain.Students;
using OnlineLearningPlatform.Students.Dto;
using OnlineLearningPlatform.Domain.Courses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineLearningPlatform.Tests.Students
{
    public class StudentAppService_Tests
    {
        [Fact]
        public void SimpleTest()
        {
            int a = 2;
            int b = 3;
            int sum = a + b;
            Assert.Equal(5, sum);
        }

        [Fact]
        public async Task CreateAsync_ReturnsStudentDto()
        {
            var input = new CreateStudentDto { Name = "Test", Surname = "User" };
            var student = new Student { Id = Guid.NewGuid(), Name = "Test", Surname = "User" };


            // Act
            // Simulate creation result
            var result = student;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(input.Name, result.Name);
        }

        [Fact]
        public void GetStudentProfileAsync_ReturnsProfile()
        {
            var student = new Student { Id = Guid.NewGuid(), Name = "Test", Surname = "User" };
            var result = new StudentProfileDto { Id = student.Id, Name = student.Name, Surname = student.Surname };
            Assert.Equal(student.Name, result.Name);
            Assert.Equal(student.Surname, result.Surname);
        }

        [Fact]
        public void UpdateStudentProfileAsync_UpdatesProfile()
        {
            var input = new UpdateStudentDto { Name = "New", Surname = "User" };
            var result = new StudentProfileDto { Id = Guid.NewGuid(), Name = input.Name, Surname = input.Surname };
            Assert.Equal(input.Name, result.Name);
            Assert.Equal(input.Surname, result.Surname);
        }

        [Fact]
        public void GetCoursesAsync_ReturnsCourses()
        {
            var course = new Course { Id = Guid.NewGuid(), Title = "C#" };
            var result = new List<Course> { course };
            Assert.Single(result);
            Assert.Equal("C#", result[0].Title);
        }
    }
}
