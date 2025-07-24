using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using OnlineLearningPlatform.Domain.Quizzes;
using System;
using System.Collections.Generic;

namespace OnlineLearningPlatform.Quizzes.Dto
{
    [AutoMap(typeof(Quiz))]
    public class UpdateQuizDto : EntityDto<Guid>
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public TimeSpan? Duration { get; set; }
        public decimal? PassingScore { get; set; }
        public ICollection<string>? Questions { get; set; }
        public ICollection<AnswerOptionDto>? AnswerOptions { get; set; }
    }
}
