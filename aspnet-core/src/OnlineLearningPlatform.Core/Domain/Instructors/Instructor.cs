using OnlineLearningPlatform.Domain.Courses;
using OnlineLearningPlatform.Domain.Persons;
using System.Collections.Generic;

namespace OnlineLearningPlatform.Domain.Instructors
{
    public class Instructor : Person
    {
        public string Profession { get; set; }
        public ICollection<Course> CoursesCreated { get; set; } = new List<Course>();
    }
}
