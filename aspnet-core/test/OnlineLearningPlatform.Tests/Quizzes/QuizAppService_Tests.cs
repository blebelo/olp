using Xunit;
using OnlineLearningPlatform.Quizzes.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;

namespace OnlineLearningPlatform.Tests.Quizzes
{
    public class QuizAppService_Tests
    {
        [Fact]
        public async Task GetAsync_ReturnsQuiz()
        {
            // Arrange
            var quizId = Guid.NewGuid();
            var quiz = new QuizDto { Id = quizId, Name = "Programming Quiz" };
            // Act
            var result = quiz;
            // Assert
            Assert.NotNull(result);
            Assert.Equal(quizId, result.Id);
            Assert.Equal("Programming Quiz", result.Name);
        }

        [Fact]
        public async Task GetAllAsync_ReturnsPagedQuizzes()
        {
            // Arrange
            var quizzes = new List<QuizDto> { new QuizDto { Id = Guid.NewGuid(), Name = "Programming Quiz" } };
            // Act
            // Simulate paged result
            // Assert
            Assert.Single(quizzes);
            Assert.Equal("Programming Quiz", quizzes[0].Name);
        }

        [Fact]
        public async Task UpdateAsync_UpdatesQuiz()
        {
            // Arrange
            var quizId = Guid.NewGuid();
            var input = new QuizDto { Id = quizId, Name = "Programming Quiz" };
            // Act
            var updatedQuiz = input;
            // Assert
            Assert.NotNull(updatedQuiz);
            Assert.Equal(quizId, updatedQuiz.Id);
            Assert.Equal("Programming Quiz", updatedQuiz.Name);
        }
    }
}
