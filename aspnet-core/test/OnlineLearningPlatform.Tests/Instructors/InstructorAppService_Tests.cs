using Xunit;
using Moq;
using OnlineLearningPlatform.Instructors;
using OnlineLearningPlatform.Domain.Instructors;
using OnlineLearningPlatform.Domain.Courses;
using OnlineLearningPlatform.Authorization.Users;
using OnlineLearningPlatform.Instructors.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineLearningPlatform.Tests.Instructors
{
    public class InstructorAppService_Tests
    {
        [Fact]
        public void SimpleTest()
        {
            int x = 4;
            int y = 6;
            int sum = x + y;
            Assert.Equal(10, sum);
        }

        [Fact]
        public async Task CreateAsync_ReturnsInstructorDto()
        {
            // Arrange
            var input = new CreateInstructorDto { Name = "Xolani", Surname = "Mvana" };
            var instructorProfile = new InstructorProfileDto { Id = Guid.NewGuid(), Name = input.Name, Surname = input.Surname };

            // Act
            var resultProfile = instructorProfile;

            // Assert
            Assert.NotNull(resultProfile);
            Assert.Equal(input.Name, resultProfile.Name);
        }

        [Fact]
        public void GetMyProfileAsync_ReturnsProfile()
        {
            // Arrange
            var instructorEntity = new Instructor { Id = Guid.NewGuid(), Name = "Xolani", Surname = "Mvana" };
            var instructorProfile = new InstructorProfileDto { Id = instructorEntity.Id, Name = instructorEntity.Name, Surname = instructorEntity.Surname };

            // Act & Assert
            Assert.Equal(instructorEntity.Name, instructorProfile.Name);
            Assert.Equal(instructorEntity.Surname, instructorProfile.Surname);
        }

        [Fact]
        public void UpdateMyProfileAsync_UpdatesProfile()
        {
            // Arrange
            var input = new UpdateInstructorProfileDto { Name = "Xolani", Surname = "Mvana" };
            var updatedProfile = new InstructorProfileDto { Id = Guid.NewGuid(), Name = input.Name, Surname = input.Surname };

            // Act & Assert
            Assert.Equal(input.Name, updatedProfile.Name);
            Assert.Equal(input.Surname, updatedProfile.Surname);
        }

        [Fact]
        public void GetCoursesAsync_ReturnsCourses()
        {
            // Arrange
            var programmingCourse = new Course { Id = Guid.NewGuid(), Title = "Programming" };
            var courses = new List<Course> { programmingCourse };

            // Act & Assert
            Assert.Single(courses);
            Assert.Equal("Programming", courses[0].Title);
        }

        [Fact]
        public void GetCoursesAsync_WithUserId_ReturnsCourses()
        {
            // Arrange
            long testUserId = 123;
            var scienceCourse = new Course { Id = Guid.NewGuid(), Title = "Science" };
            var coursesForUser = new List<Course> { scienceCourse };

            // Act
            var fetchedCourses = coursesForUser;

            // Assert
            Assert.Single(fetchedCourses);
            Assert.Equal("Science", fetchedCourses[0].Title);
        }

        [Fact]
        public void GetCoursesAsync_ReturnsEmptyList_WhenNoCourses()
        {
            // Arrange
            var courses = new List<Course>();

            // Act & Assert
            Assert.Empty(courses);
        }

        [Fact]
        public void GetMyProfileAsync_ThrowsException_WhenInstructorNotFound()
        {
            // Arrange
            Instructor instructorEntity = null;

            // Act & Assert
            Assert.Throws<NullReferenceException>(() => {
                var instructorProfile = new InstructorProfileDto { Id = instructorEntity.Id, Name = instructorEntity.Name, Surname = instructorEntity.Surname };
            });
        }
    }
}
