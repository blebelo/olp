using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;

namespace OnlineLearningPlatform.Domain.Entities
{
    public class Course : FullAuditedEntity<Guid>
    {
        public string Title { get; set; }
        public string Topic { get; set; }
        public string Description { get; set; }
        public bool IsPublished { get; set; }
        public Instructor Instructor { get; set; }
        public ICollection<string> EnrolledStudents { get; set; }
        public ICollection<string> Lessons {get; set; }


        public Course()
        {
            Id = Guid.NewGuid();
            IsPublished = false;
            EnrolledStudents = new List<string>();
            Lessons = new List<string>();
        }
        public Course(string title, string topic, string description, Instructor instructor, string lesson)
        {
            Id = Guid.NewGuid();
            Title = title;
            Topic = topic;
            Description = description;
            IsPublished = false;
            Instructor = instructor;
            EnrolledStudents = new List<string>();
            Lessons = new List<string>();
        }
        public void UpdateCourse(string title, string topic, string description, bool isPublished, Instructor instructor)
        {
            Title = title;
            Topic = topic;
            Description = description;
            IsPublished = isPublished;
            Instructor = instructor;

        }
        public void EnrollStudent(string studentId)
        {
            if (!EnrolledStudents.Contains(studentId))
            {
                EnrolledStudents.Add(studentId);
            }
        }
        public void UnenrollStudent(string studentId)
        {
            if (EnrolledStudents.Contains(studentId))
            {
                EnrolledStudents.Remove(studentId);
            }
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
    }
}
