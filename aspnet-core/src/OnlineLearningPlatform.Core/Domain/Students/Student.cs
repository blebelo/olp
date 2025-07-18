using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineLearningPlatform.Domain.Entities;
using OnlineLearningPlatform.Domain.StudentCourses;

namespace OnlineLearningPlatform.Domain.Students
{
    public class Student : Person
    {
        public string Interests { get; set; }
        public string AcademicLevel { get; set; }

        public virtual ICollection<StudentCourse> StudentCourses { get; set; }

        //Course.EnrolledCourses is a collection of course IDs based on Course.cs for course enrollment
        public ICollection<Course> EnrolledCourses => StudentCourses?.Select(sc => sc.Course).ToList();

        public Student()
        {
            StudentCourses = new List<StudentCourse>();
        }


        //Course enrollment methods
        public void EnrollInCourse(Course course)
        {

            if (course == null)
                throw new ArgumentNullException(nameof(course));

            if (!IsEnrolledInCourse(course.Id))
            {
                StudentCourses.Add(new StudentCourse
                {
                    StudentId = this.Id,
                    CourseId = course.Id,
                    Student = this,
                    Course = course
                });
            }
        }
        public void UnenrollFromCourse(Guid courseId)
        {
            var enrollment = StudentCourses.FirstOrDefault(sc => sc.CourseId == courseId);
            if (enrollment != null)
            {
                StudentCourses.Remove(enrollment);
            }
        }

        public bool IsEnrolledInCourse(Guid courseId)
        {
            return StudentCourses.Any(sc => sc.CourseId == courseId);
        }

        public int GetEnrolledCoursesCount()
        {
            return StudentCourses.Count;
        }
        public IEnumerable<Course> GetEnrolledCoursesList()
        {
            return StudentCourses.Select(sc => sc.Course);
        }
    }
}
