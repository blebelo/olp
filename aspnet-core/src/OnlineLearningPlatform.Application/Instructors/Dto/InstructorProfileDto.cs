using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using OnlineLearningPlatform.Domain.Instructors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLearningPlatform.Instructors.Dto
{
    [AutoMapFrom(typeof(Instructor))]
    public class InstructorProfileDto: EntityDto<Guid>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Bio { get; set; }
        public string Profession { get; set; }
    }
}
