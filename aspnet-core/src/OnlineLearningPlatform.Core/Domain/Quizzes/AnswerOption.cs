using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace OnlineLearningPlatform.Domain.Quizzes
{
    [Owned]
    public class AnswerOption
    {
        public string CorrectAnswer { get; set; }
        public ICollection<string> PossibleAnswers { get; set; } = new List<string>();
    }
}