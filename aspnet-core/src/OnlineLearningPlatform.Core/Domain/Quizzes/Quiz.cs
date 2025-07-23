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
        public ICollection<string> Questions { get; set; } = new List<string>();
        public ICollection<string> Memorandum { get; set; } = new List<string>();
        public ICollection<AnswerOptions> AnswerOptions { get; set; } = new List<AnswerOptions>();
    }

}