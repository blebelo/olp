using System.Collections.Generic;

namespace OnlineLearningPlatform.Domain.Entities
{
    public class Instructor : Person
    {
        public string Profession { get; set; }
        public ICollection<Course> CoursesCreated { get; set; }
    }
}
