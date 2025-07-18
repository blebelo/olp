using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineLearningPlatform.Domain.Courses;
using OnlineLearningPlatform.Domain.Entities;
using OnlineLearningPlatform.Domain.Persons;
using OnlineLearningPlatform.Domain.StudentCourses;

namespace OnlineLearningPlatform.Domain.Students
{
    public class Student : Person
    {
        public string Interests { get; set; }
        public string AcademicLevel { get; set; }

        //Course.EnrolledCourses is a collection of course IDs based on Course.cs for course enrollment
        public ICollection<string> EnrolledCourses { get; set; }

        public virtual ICollection<StudentCourse> StudentCourses { get; set; }
        public ICollection<Course> EnrolledCourses => StudentCourses?.Select(sc => sc.Course).ToList();

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
