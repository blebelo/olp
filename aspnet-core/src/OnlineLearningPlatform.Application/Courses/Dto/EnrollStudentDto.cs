using Abp.AutoMapper;
using OnlineLearningPlatform.Domain.Courses;
using OnlineLearningPlatform.Domain.Students;
using System;

namespace OnlineLearningPlatform.Courses.Dto
{
    [AutoMap(typeof(Course))]
    public class EnrollStudentDto
    {
        public Guid CourseId { get; set; }
        public Guid StudentId { get; set; }

    }
}
