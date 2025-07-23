using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using OnlineLearningPlatform.Domain.Results;
using System.Collections.Generic;

namespace OnlineLearningPlatform.QuizAttempts.Dto
{
    [AutoMap(typeof(Result))]
    public class ResultDto : EntityDto
    {
        public int Score { get; set; }
        public ICollection<string> CorrectAnswers { get; set; }
        public ICollection<string> IncorrectAnswers { get; set; }
    }
}
