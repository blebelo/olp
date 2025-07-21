using Abp.Domain.Entities.Auditing;
using OnlineLearningPlatform.Domain.Quizzes;
using OnlineLearningPlatform.Domain.Students;
using System;
using System.Collections.Generic;

namespace OnlineLearningPlatform.Domain.Results
{
    public class Result : FullAuditedEntity<Guid>
    {
        public int Score { get; set; }
        public ICollection<string> CorrectAnswers { get; set; } = new List<string>();
        public ICollection<string> IncorrectAnswers { get; set; } = new List<string>();
        public Quiz Quiz { get; set; }
        public Student Student { get; set; }
    }
}
