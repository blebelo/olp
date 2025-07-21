using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using OnlineLearningPlatform.Domain.Students;

namespace OnlineLearningPlatform.Students.Dto
{
    [AutoMap(typeof(Student))]
    public class UpdateStudentDto : EntityDto<Guid>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Interests { get; set; }
        public string AcademicLevel { get; set; }
    }
}
