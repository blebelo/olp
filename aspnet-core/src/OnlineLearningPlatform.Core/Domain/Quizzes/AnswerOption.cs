using Abp.Domain.Values;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace OnlineLearningPlatform.Domain.Quizzes
{
    [Owned]
    public class AnswerOption     
    {
        public int QuestionIndex { get; set; }
        public ICollection<string> Options { get; set; }
    }
}
