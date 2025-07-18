using OnlineLearningPlatform.Domain.Persons;
using System.Collections.Generic;

namespace OnlineLearningPlatform.Domain.Students
{
    public class Student : Person
    {
        public string StudentId { get; set; }
        public string Interests { get; set; }
        public string AcademicLevel { get; set; }

        //Course.EnrolledCourses is a collection of course IDs based on Course.cs for course enrollment
        public ICollection<string> EnrolledCourses { get; set; }

        public Student()
        {
            EnrolledCourses = new List<string>();
        }


        //Course enrollment methods
        public void EnrollInCourse(string courseId)
        {
            if (!EnrolledCourses.Contains(courseId))
            {
                EnrolledCourses.Add(courseId);
            }
        }
        public void UnenrollFromCourse(string courseId)
        {
            if (EnrolledCourses.Contains(courseId))
            {
                EnrolledCourses.Remove(courseId);
            }
        }

        public bool IsEnrolledInCourse(string courseId)
        {
            return EnrolledCourses.Contains(courseId);
        }

        public int GetEnrolledCoursesCount()
        {
            return EnrolledCourses.Count;
        }
    }
}
