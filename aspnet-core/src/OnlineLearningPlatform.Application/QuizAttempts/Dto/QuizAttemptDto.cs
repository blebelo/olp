using Abp.AutoMapper;
using OnlineLearningPlatform.Domain.Quizzes;
using System;
using System.Collections.Generic;

namespace OnlineLearningPlatform.QuizAttempts.Dto
{
    [AutoMap(typeof(QuizAttempt))]
    public class QuizAttemptDto
    {
        public Guid QuizId { get; set; }
        public Guid StudentId { get; set; }
        public bool IsPassed { get; set; }
        public bool IsCompleted { get; set; }
        public ResultDto Results { get; set; }
        public ICollection<string> StudentAnswers { get; set; }
    }
}
