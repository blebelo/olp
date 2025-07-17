using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using OnlineLearningPlatform.Domain.Courses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineLearningPlatform.Courses.Dto
{
    [AutoMap(typeof(Course))]
    public class CreateCourseDto : EntityDto<Guid>
    {

        [Required(ErrorMessage = "Title is a required field")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Topic is a required field")]
        public string Topic { get; set; }

        [Required(ErrorMessage = "Description is a required field")]
        public string Description { get; set; }
        public bool IsPublished { get; set; } = false;

        [Required(ErrorMessage = "Instructor is a required field")]
        public string Instructor { get; set; }
        public ICollection<string> EnrolledStudents { get; set; }
        public ICollection<string> Lessons { get; set; }
    }
}
