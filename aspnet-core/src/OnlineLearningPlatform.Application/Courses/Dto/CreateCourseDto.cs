using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using OnlineLearningPlatform.Domain.Courses;
using System;

namespace OnlineLearningPlatform.Courses.Dto
{
    [AutoMap(typeof(Course))]
    public class CreateCourseDto : EntityDto<Guid>
    {
        public string Title { get; set; }
        public string Topic { get; set; }
        public string Description { get; set; }
        public string CoverImageUrl { get; set; }
        public string Category { get; set; }
        public bool IsPublished { get; set; } = false;
        public Guid InstructorId { get; set; }
    }
}
