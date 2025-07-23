using OnlineLearningPlatform.Domain.Courses;
using OnlineLearningPlatform.Domain.Persons;
using OnlineLearningPlatform.Domain.StudentProgresses;
using System.Collections.Generic;
using System.Linq;

namespace OnlineLearningPlatform.Domain.Students
{
    public class Student : Person
    {
        public string Interests { get; set; }
        public string AcademicLevel { get; set; }
        public ICollection<Course> EnrolledCourses { get; set; } = new List<Course>();
        public ICollection<StudentProgress> Progress { get; set; } = new List<StudentProgress>();
    }
}
