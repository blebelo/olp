using OnlineLearningPlatform.Domain.Courses;
using OnlineLearningPlatform.Domain.Persons;
using System.Collections.Generic;
using System.Linq;

namespace OnlineLearningPlatform.Domain.Students
{
    public class Student : Person
    {
        public string Interests { get; set; }
        public string AcademicLevel { get; set; }
        public ICollection<Course> EnrolledCourses { get; set; }
    }
}
