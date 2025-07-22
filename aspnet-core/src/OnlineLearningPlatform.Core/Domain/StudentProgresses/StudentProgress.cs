using Abp.Domain.Entities;
using OnlineLearningPlatform.Domain.Courses;
using OnlineLearningPlatform.Domain.Entities;
using OnlineLearningPlatform.Domain.Quizzes;
using OnlineLearningPlatform.Domain.Students;
using System;
using System.Collections.Generic;

namespace OnlineLearningPlatform.Domain.StudentProgresses
{
    public class StudentProgress: AggregateRoot<Guid>
    {
        public string StudentName { get; set; }
        public Student Student { get; set; }
        public ICollection<Course> EnrolledCourses { get; set; }
        public ICollection<Course> UnenrolledCourses { get; set; }
        public ICollection<Course> CompletedCourses { get; set; }
        public ICollection<Lesson> CompletedLessons { get; set; }
        public ICollection<QuizAttempt> CompletedQuizzes { get; set; }
    }
}
