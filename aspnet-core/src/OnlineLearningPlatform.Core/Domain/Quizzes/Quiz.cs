using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;

namespace OnlineLearningPlatform.Domain.Quizzes
{
    public class Quiz : FullAuditedEntity<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public TimeSpan Duration { get; set; }
        public decimal PassingScore { get; set; }
        public ICollection<string> Questions { get; set; }
        public ICollection<string> Memorandum { get; set; }
        public ICollection<string> AnswerOptions { get; set; }
        public ICollection<QuizAttempt> StudentAttempts { get; set; }
    }

}