using Abp.Domain.Entities;
using OnlineLearningPlatform.Domain.Courses;
using OnlineLearningPlatform.Domain.Entities;
using OnlineLearningPlatform.Domain.Quizzes;
using OnlineLearningPlatform.Domain.Students;
using System;
using System.Collections.Generic;

namespace OnlineLearningPlatform.Domain.StudentProgresses
{
    public class StudentProgress : AggregateRoot<Guid>
    {
        public Guid StudentId { get; set; }
        public Student Student { get; set; }

        public Guid CourseId { get; set; }
        public Course Course { get; set; }
        public ICollection<Lesson> CompletedLessons { get; set; } = new List<Lesson>();
        public ICollection<QuizAttempt> CompletedQuizzes { get; set; } = new List<QuizAttempt>();

        public DateTime LastAccessed { get; set; }
        public bool IsCompleted { get; set; }
        public double CompletionPercentage { get; set; }
    }
}
