using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace OnlineLearningPlatform.Domain.Quizzes
{
    [Owned]
    public class AnswerOptions
    {
        public int QuestionIndex { get; set; }
        public ICollection<string> PossibleAnswers { get; set; } = new List<string>();
    }
}