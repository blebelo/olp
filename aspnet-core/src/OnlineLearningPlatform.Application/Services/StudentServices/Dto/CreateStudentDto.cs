using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using AutoMapper;
using OnlineLearningPlatform.Domain.Student;

namespace OnlineLearningPlatform.Services.StudentServices.Dto
{
    //[AutoMap(typeof(Student))]
    public class CreateStudentDto : EntityDto<Guid>
    {

        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public string Interests { get; set; }
        public string AcademicLevel { get; set; }
    }
}
