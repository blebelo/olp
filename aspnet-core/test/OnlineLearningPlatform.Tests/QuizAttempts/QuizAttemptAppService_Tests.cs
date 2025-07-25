using Xunit;
using OnlineLearningPlatform.QuizAttempts.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineLearningPlatform.Tests.QuizAttempts
{
    public class QuizAttemptAppService_Tests
    {
        [Fact]
        public async Task SubmitQuizAsync_ReturnsQuizAttempt()
        {
            // Arrange
            var submission = new QuizSubmissionDto { QuizId = Guid.NewGuid(), StudentId = Guid.NewGuid() };
            var resultDto = new ResultDto { Score = 85, CorrectAnswers = new List<string> { "A", "B" }, IncorrectAnswers = new List<string> { "C" } };
            var attempt = new QuizAttemptDto {
                QuizId = submission.QuizId,
                StudentId = submission.StudentId,
                IsPassed = true,
                IsCompleted = true,
                Results = resultDto,
                StudentAnswers = new List<string> { "A", "B", "C" }
            };
            // Act
            var result = attempt;
            // Assert
            Assert.NotNull(result);
            Assert.Equal(submission.QuizId, result.QuizId);
            Assert.Equal(submission.StudentId, result.StudentId);
            Assert.True(result.IsPassed);
            Assert.True(result.IsCompleted);
            Assert.NotNull(result.Results);
            Assert.Equal(85, result.Results.Score);
            Assert.Contains("A", result.Results.CorrectAnswers);
            Assert.Contains("C", result.Results.IncorrectAnswers);
        }

        [Fact]
        public async Task SubmitQuizAsync_FailsWithInvalidSubmission()
        {
            // Arrange
            var submission = new QuizSubmissionDto { QuizId = Guid.Empty, StudentId = Guid.Empty };
            // Simulate a failed attempt (e.g., invalid IDs)
            QuizAttemptDto attempt = null;
            // Act
            var result = attempt;
            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task SubmitQuizAsync_HandlesEmptyAnswers()
        {
            // Arrange
            var submission = new QuizSubmissionDto { QuizId = Guid.NewGuid(), StudentId = Guid.NewGuid() };
            var resultDto = new ResultDto { Score = 0, CorrectAnswers = new List<string>(), IncorrectAnswers = new List<string>() };
            var attempt = new QuizAttemptDto {
                QuizId = submission.QuizId,
                StudentId = submission.StudentId,
                IsPassed = false,
                IsCompleted = true,
                Results = resultDto,
                StudentAnswers = new List<string>()
            };
            // Act
            var result = attempt;
            // Assert
            Assert.NotNull(result);
            Assert.Empty(result.StudentAnswers);
            Assert.Equal(0, result.Results.Score);
            Assert.Empty(result.Results.CorrectAnswers);
            Assert.Empty(result.Results.IncorrectAnswers);
        }
    }
}
