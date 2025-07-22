using Abp.AutoMapper;
using Abp.Domain.Entities;
using OnlineLearningPlatform.Domain.Courses;
using System;

namespace OnlineLearningPlatform.Courses.Dto
{
    [AutoMap(typeof(Course))]
    public class GetAllCoursesDto : Entity<Guid>
    {
        public string Title { get; set; }
        public string Topic { get; set; }
        public string Description { get; set; }
        public bool IsPublished { get; set; }
    }
}
