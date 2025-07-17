using Abp.Application.Services.Dto;
<<<<<<< HEAD
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

=======
using Abp.AutoMapper;
using OnlineLearningPlatform.Domain.Instructors;
using System;

namespace OnlineLearningPlatform.Instructors.Dto
{
    [AutoMap(typeof(Instructor))]
    public class UpdateCourseDto : EntityDto<Guid>
    {
        public string? Title { get; set; }
        public string? Topic { get; set; }
        public string? Description { get; set; }
>>>>>>> f5809b615cba864677f6945c667ad0a4f64c3ef7
    }
}
