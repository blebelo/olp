using System;
using System.Collections.Generic;

namespace OnlineLearningPlatform.QuizAttempts.Dto
{
    public class QuizSubmissionDto
    {
        public Guid QuizId { get; set; }
        public Guid StudentId { get; set; }
        public ICollection<string> StudentAnswers { get; set; }
    }
}
