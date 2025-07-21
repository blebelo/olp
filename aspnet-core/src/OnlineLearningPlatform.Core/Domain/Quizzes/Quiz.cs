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
        public ICollection<string> Memorandum { get; set; }
        public ICollection<string> StudentAnswers { get; set; }
        public ICollection<string> Questions { get; set; }
        public ICollection<AnswerOption> AnswerOptions { get; set; }

    }
}

public class AnswerOption
{
    public int QuestionIndex { get; set; }
    public ICollection<string> Options { get; set; };
    public string CorrectAnswer { get; set; } 
}

