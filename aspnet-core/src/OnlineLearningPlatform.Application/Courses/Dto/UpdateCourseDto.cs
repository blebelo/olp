using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using OnlineLearningPlatform.Domain.Instructors;
using System;

namespace OnlineLearningPlatform.Instructors.Dto
{
    [AutoMap(typeof(Instructor))]
    public class UpdateCourseDto : EntityDto<Guid>
    {
        public string? Title { get; set; }
        public string? Topic { get; set; }
        public string? Description { get; set; }
        public string? CoverImageUrl { get; set; }
    }
}
