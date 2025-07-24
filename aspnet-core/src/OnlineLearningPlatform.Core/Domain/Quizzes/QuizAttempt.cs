using Abp.Domain.Entities.Auditing;
using OnlineLearningPlatform.Domain.Results;
using OnlineLearningPlatform.Domain.Students;
using System;
using System.Collections.Generic;

namespace OnlineLearningPlatform.Domain.Quizzes
{
    public class QuizAttempt : FullAuditedEntity<Guid>
    {
        public Quiz Quiz { get; set; }
        public Student Student { get; set; }
        public decimal Percentage { get; set; }
        public bool IsPassed { get; set; }
        public bool IsCompleted { get; set; }
        public Result Results { get; set; }
        public ICollection<string> StudentAnswers { get; set; }
    }
}
