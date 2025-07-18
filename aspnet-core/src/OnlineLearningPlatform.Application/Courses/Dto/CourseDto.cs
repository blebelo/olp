using Abp.Application.Services.Dto;
using OnlineLearningPlatform.Domain.Entities;
using System;
using System.Collections.Generic;

namespace OnlineLearningPlatform.Courses.Dto
{
    public class CourseDto: EntityDto<Guid>
    {
        public string Title { get; set; }
        public string Topic { get; set; }
        public string Description { get; set; }
        public bool IsPublished { get; set; }
        public string Instructor { get; set; }
        public ICollection<string> EnrolledStudents { get; set; }
        public ICollection<Lesson> Lessons { get; set; }
    }
}
