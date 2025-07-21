using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using OnlineLearningPlatform.Domain.Entities;
using System;
using System.Collections.Generic;

namespace OnlineLearningPlatform.Lessons.Dto
{
    [AutoMap(typeof(Lesson))]
    public class LessonDto : EntityDto<Guid>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string VideoLink { get; set; }
        public Guid CourseId { get; set; }
        public Guid InstructorId { get; set; }
        public Boolean IsCompleted { get; set; }
        public ICollection<string> StudyMaterialLinks { get; set; }
    }
}
