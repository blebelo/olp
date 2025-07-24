using Abp.Domain.Entities;
using OnlineLearningPlatform.Domain.Courses;
using OnlineLearningPlatform.Domain.Entities;
using OnlineLearningPlatform.Domain.Quizzes;
using OnlineLearningPlatform.Domain.Students;
using System;
using System.Collections.Generic;

namespace OnlineLearningPlatform.Domain.StudentProgresses
{
    public class StudentProgress : Entity<Guid>
    {
        public Guid StudentId { get; set; }
        public Student Student { get; set; }

        public Guid CourseId { get; set; }
        public Course Course { get; set; }

        public bool IsCompleted { get; set; }
        public double CompletionPercentage { get; set; }
        public ICollection<Guid> CompletedLessonIds { get; set; } = new List<Guid>();
        public ICollection<Guid> CompletedQuizIds { get; set; } = new List<Guid>();

    }
}
