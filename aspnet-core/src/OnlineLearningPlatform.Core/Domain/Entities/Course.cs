using Abp.Domain.Entities.Auditing;
using OnlineLearningPlatform.Domain.StudentCourses;
using OnlineLearningPlatform.Domain.Students;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineLearningPlatform.Domain.Entities
{
    public class Course : FullAuditedEntity<Guid>
    {
        public string Title { get; set; }
        public string Topic { get; set; }
        public string Description { get; set; }
        public bool IsPublished { get; set; }
        public String Instructor { get; set; }
        public ICollection<string> EnrolledStudents { get; set; }
        public ICollection<string> Lessons {get; set; }

        //navigation properties
        public virtual ICollection<StudentCourse> StudentCourses { get; set; }
        //Convenience property
        public virtual ICollection<Student> EnrolledStudentsList => StudentCourses?.Select(sc => sc.Student).ToList();

        public Course()
        {
            StudentCourses = new List<StudentCourse>();
            Lessons = new List<string>();
        }
        public void UpdateCourse(string title, string topic, string description, bool isPublished, String instructor)
        {
            Title = title;
            Topic = topic;
            Description = description;
            IsPublished = isPublished;
            Instructor = instructor;

        }
        public void EnrollStudent(Student student)
        {
            if (student == null)
            {
                throw new ArgumentException(nameof(student), "Student cannot be null");
            }
            if (!HasEnrolledStudent(student.Id))
            {
                StudentCourses.Add(new StudentCourse
                {
                    StudentId = student.Id,
                    CourseId = this.Id,
                    Student = student,
                    Course = this
                });
            }
        }
        public void UnenrollStudent(Guid studentId)
        {
           var enrollment = StudentCourses.FirstOrDefault(sc => sc.StudentId == studentId);
            if (enrollment != null)
            {
                StudentCourses.Remove(enrollment);
            }
        }
        public bool HasEnrolledStudent(Guid studentId)
        {
            return StudentCourses.Any(sc => sc.StudentId == studentId);
        }
        public void AddLesson(string lesson)
        {
            if (!Lessons.Contains(lesson))
            {
                Lessons.Add(lesson);
            }
        }
        public void RemoveLesson(string lesson)
        {
            if (Lessons.Contains(lesson))
            {
                Lessons.Remove(lesson);
            }
        }
        public void PublishCourse()
        {
            IsPublished = true;

        }
        public void UnpublishCourse()
        {
            IsPublished = false;

        }
        public void DeleteCourse()
        {
            IsDeleted = true;

        }
        public int GetEnrolledStudentsCount()
        {
            return StudentCourses.Count;
        }
    }
}
