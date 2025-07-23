using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace OnlineLearningPlatform.Domain.Results
{
    [Owned]
    public class Result 
    {
        public int Score { get; set; }
        public ICollection<string> CorrectAnswers { get; set; } = new List<string>();
        public ICollection<string> IncorrectAnswers { get; set; } = new List<string>();
    }
}
