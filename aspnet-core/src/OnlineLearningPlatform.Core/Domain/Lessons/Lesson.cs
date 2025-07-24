using Abp.Domain.Entities.Auditing;
using OnlineLearningPlatform.Domain.Courses;
using OnlineLearningPlatform.Domain.Instructors;
using System;
using System.Collections.Generic;

namespace OnlineLearningPlatform.Domain.Entities
{
    public class Lesson : FullAuditedEntity<Guid>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string VideoLink { get; set; }
        public Course Course { get; set; }
        public Instructor Instructor { get; set; }
        public ICollection<string> StudyMaterialLinks { get; set; }

    }
}
