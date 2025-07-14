using System;
using OnlineLearningPlatform.Domain.Persons;

namespace OnlineLearningPlatform.Domain.Students
{
    public class Student : Person
    {
        public string StudentId { get; set; }
        public DateTime EnrollmentDate { get; set; } = DateTime.UtcNow;
    }
}