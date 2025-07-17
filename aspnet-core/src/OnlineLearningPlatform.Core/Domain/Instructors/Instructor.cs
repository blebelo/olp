using OnlineLearningPlatform.Domain.Entities;
using System.Collections.Generic;

namespace OnlineLearningPlatform.Domain.Instructors
{
    public class Instructor : Person
    {
        public string Profession { get; set; }
        public ICollection<Course> CoursesCreated { get; set; }
    }
}
