using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities.Auditing;
using OnlineLearningPlatform.Domain.Entities;
using OnlineLearningPlatform.Domain.Students;

namespace OnlineLearningPlatform.Domain.StudentCourses
{
    public class StudentCourse : FullAuditedEntity<Guid>
    {
        public Guid StudentId { get; set; }
        public Guid CourseId { get; set; }

        public virtual Student Student { get; set; }
        public virtual Course Course { get; set; }
    }
}
