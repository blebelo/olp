using Abp.Domain.Values;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace OnlineLearningPlatform.Domain.Quizzes
{
    [Owned]
    public class AnswerOption
    {
        public int CorrectAnswer { get; set; }
        public ICollection<string> PossibleAnswers { get; set; } = new List<string>();
    }
}

