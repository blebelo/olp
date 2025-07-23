using Abp.Domain.Entities.Auditing;
using OnlineLearningPlatform.Domain.Entities;
using OnlineLearningPlatform.Domain.Instructors;
using OnlineLearningPlatform.Domain.Quizzes;
using OnlineLearningPlatform.Domain.StudentProgresses;
using OnlineLearningPlatform.Domain.Students;
using System;
using System.Collections.Generic;

namespace OnlineLearningPlatform.Domain.Courses
{
    public class Course : FullAuditedEntity<Guid>
    {
        public string Title { get; set; }
        public string Topic { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public bool IsPublished { get; set; }
        public Instructor Instructor { get; set; }
        public ICollection<Student> EnrolledStudents { get; set; } = new List<Student>();
        public ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();
        public ICollection<StudentProgress> Progresses { get; set; } = new List<StudentProgress>();
        public Quiz Quiz { get; set; }

    }
}
