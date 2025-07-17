using Abp.Application.Services.Dto;
using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineLearningPlatform.Courses.Dto
{
    public class UpdateCourseDto : EntityDto<Guid>
    {
        [Required]
        public string Title { get; set; }

        public string Topic { get; set; }

        public string Description { get; set; }

    }
}
