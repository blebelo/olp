using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;

namespace OnlineLearningPlatform.Domain.Entities
{
    public class Lesson : FullAuditedEntity<Guid>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string VideoLink { get; set; }
        public Boolean IsCompleted { get; set; }
        public ICollection<string> StudyMaterialLinks { get; set; }

    }
}
