using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;

namespace OnlineLearningPlatform.Lessons.Dto
{
    public class CreateLessonDto: EntityDto<int>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string VideoLink { get; set; }
        public string Instructor { get; set; }
        public Boolean isCompleted { get; set; }
        public ICollection<string> StudyMaterialLinks { get; set; }

    }
}
