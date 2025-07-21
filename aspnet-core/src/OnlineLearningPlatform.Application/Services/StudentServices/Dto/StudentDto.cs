using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using OnlineLearningPlatform.Domain.Students;

namespace OnlineLearningPlatform.Services.StudentServices.Dto
{
    [AutoMap(typeof(Student))]
    public class StudentDto : FullAuditedEntityDto<Guid>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Interests { get; set; }
        public string AcademicLevel { get; set; }
        public int EnrolledCoursesCount { get; set; }
        public List<CourseDtos> EnrolledCourses { get; set; }
    }
}
