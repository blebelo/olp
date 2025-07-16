using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using OnlineLearningPlatform.Authorization.Roles;
using OnlineLearningPlatform.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineLearningPlatform.Instructors.Dto
{
    [AutoMap(typeof(Instructor))]
    public class CreateInstructorDto : EntityDto<Guid>
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
        [Required]
        public string Bio { get; set; }
        [Required]
        public string Profession { get; set; }

    }
}
