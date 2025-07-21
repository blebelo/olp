using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using OnlineLearningPlatform.Courses.Dto;
using OnlineLearningPlatform.Domain.Students;
using System;
using System.Collections.Generic;

namespace OnlineLearningPlatform.Students.Dto
{
    [AutoMap(typeof(Student))]
    public class StudentDto : FullAuditedEntityDto<Guid>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Interests { get; set; }
        public string AcademicLevel { get; set; }
        public List<CourseDto> EnrolledCourses { get; set; }
    }
}
