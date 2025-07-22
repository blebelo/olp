using Abp.Domain.Entities.Auditing;
using OnlineLearningPlatform.Domain.Courses;
using OnlineLearningPlatform.Domain.Entities;
using OnlineLearningPlatform.Domain.Quizzes;
using OnlineLearningPlatform.Domain.Students;
using System;
using System.Collections.Generic;

namespace OnlineLearningPlatform.Domain.StudentProgresses
{
    public class StudentProgress: FullAuditedEntity<Guid>
    {
        public string StudentName { get; set; }
        public Student Student { get; set; }
        public ICollection<Course> Courses { get; set; }
        public ICollection<Lesson> CompletedLessons { get; set; }
        public ICollection<QuizAttempt> CompletedQuizzes { get; set; }
    }
}
