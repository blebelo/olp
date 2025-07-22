using Abp.Domain.Entities.Auditing;
using OnlineLearningPlatform.Domain.Results;
using OnlineLearningPlatform.Domain.Students;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineLearningPlatform.Domain.Quizzes
{
    public class QuizAttempt : FullAuditedEntity<Guid>
    {
        public Student Student { get; set; }
        public Quiz Quiz { get; set; }
        public decimal Score { get; set; }
        public decimal Percentage { get; set; }
        public bool IsPassed { get; set; }
        public bool IsCompleted { get; set; }
        public ICollection<string> StudentAnswers { get; set; }
        public ICollection<Result> Results { get; set; }

        public void CompleteAttempt()
        {
            if (!IsCompleted)
            {
                IsCompleted = true;
            }
        }

        public void CalculateScoreAndPercentage(ICollection<string> correctAnswers)
        {
            if (StudentAnswers == null || !StudentAnswers.Any())
            {
                throw new InvalidOperationException("No answers provided for the quiz attempt.");
            }
            if (correctAnswers == null || !correctAnswers.Any())
            {
                throw new InvalidOperationException("No correct answers provided for the quiz.");
            }
            int correctCount = StudentAnswers.Intersect(correctAnswers).Count();
            Score = correctCount * (Quiz.PassingScore / correctAnswers.Count);
            Percentage = (decimal)correctCount / correctAnswers.Count * 100;
            IsPassed = Percentage >= Quiz.PassingScore;
        }
    }
}
