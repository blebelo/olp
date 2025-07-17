using OnlineLearningPlatform.Authorization.Roles;
using OnlineLearningPlatform.Authorization.Users;
using System.Collections.Generic;

namespace OnlineLearningPlatform.Domain.Entities
{
    public class Instructor : Person
    {

        //public virtual User User { get; set; }
        public string Profession { get; set; }
        public virtual ICollection<Course> CoursesCreated { get; set; }


        //Initializing the CoursesCreated collection to avoid null reference exceptions
        public Instructor()
        {

            CoursesCreated = new List<Course>();
        }
    }
}