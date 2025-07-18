using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;

namespace OnlineLearningPlatform.Services.StudentServices.Dto
{
    public class StudentDto : EntityDto<Guid>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string StudentId { get; set; }
        public string Interests { get; set; }
        public string AcademicLevel { get; set; }
        public int EnrolledCoursesCount { get; set; }
    }
}
