using Abp.AutoMapper;
using OnlineLearningPlatform.Domain.Quizzes;
using System.Collections.Generic;

namespace OnlineLearningPlatform.Quizzes.Dto
{
    [AutoMap(typeof(AnswerOption))]
    public class AnswerOptionDto
    {
        public int CorrectIndex { get; set; }
        public List<string> PossibleAnswers { get; set; } 
    }
}
