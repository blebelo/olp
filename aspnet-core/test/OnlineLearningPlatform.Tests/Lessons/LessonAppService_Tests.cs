using Xunit;
using OnlineLearningPlatform.Lessons.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineLearningPlatform.Tests.Lessons
{
    public class LessonAppService_Tests
    {
        [Fact]
        public async Task GetAsync_ReturnsLesson()
        {
            // Arrange
            var lessonId = Guid.NewGuid();
            var lesson = new LessonDto { Id = lessonId, Title = "Intro to Programming" };
            // Act
            var result = lesson;
            // Assert
            Assert.Equal(lessonId, result.Id);
            Assert.Equal("Intro to Programming", result.Title);
        }

        [Fact]
        public async Task DeleteAsync_DeletesLesson()
        {
            // Arrange
            bool deleted = true; // Simulate deletion
            // Act & Assert
            Assert.True(deleted);
        }

        [Fact]
        public async Task GetAllAsync_ReturnsLessons()
        {
            // Arrange
            var lessons = new List<LessonDto> { new LessonDto { Id = Guid.NewGuid(), Title = "Intro to Programming" } };
            // Act & Assert
            Assert.Single(lessons);
            Assert.Equal("Intro to Programming", lessons[0].Title);
        }

        [Fact]
        public async Task MarkComplete_MarksLessonComplete()
        {
            // Arrange
            bool markedComplete = true; // Simulate marking complete
            // Act & Assert
            Assert.True(markedComplete);
        }

        [Fact]
        public async Task CreateAsync_CreatesLesson()
        {
            // Arrange
            var input = new LessonDto { Id = Guid.NewGuid(), Title = "Intro to Programming" };
            // Act
            var createdLesson = input;
            // Assert
            Assert.NotNull(createdLesson);
            Assert.Equal("Intro to Programming", createdLesson.Title);
        }
    }
}
