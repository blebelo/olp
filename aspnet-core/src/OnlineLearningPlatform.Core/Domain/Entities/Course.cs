using Abp.Domain.Entities;
using System;
using System.Collections.Generic;

namespace OnlineLearningPlatform.Domain.Entities
{
    public class Course : Entity<Guid>
    {
        public string Title { get; set; }
        public string Topic { get; set; }
        public string Description { get; set; }
        public bool IsPublished { get; set; }
        public string Instructor { get; set; }
        public DateTime CreatedDate { get; }
        public DateTime? UpdatedDate { get; }
        public ICollection<string> EnrolledStudents { get; set; }
    }
}
