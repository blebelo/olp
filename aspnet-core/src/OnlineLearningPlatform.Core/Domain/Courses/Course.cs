using Abp.Domain.Entities.Auditing;
using OnlineLearningPlatform.Domain.Entities;
using System;
using System.Collections.Generic;

namespace OnlineLearningPlatform.Domain.Courses
{
    public class Course : FullAuditedEntity<Guid>
    {
        public string Title { get; set; }
        public string Topic { get; set; }
        public string Description { get; set; }
        public bool IsPublished { get; set; }
        public string Instructor { get; set; }
        public ICollection<string> EnrolledStudents { get; set; }
        public ICollection<Lesson> Lessons {get; set; }


        public void UpdateCourse(string title, string topic, string description, bool isPublished, string instructor)
        {
            Title = title;
            Topic = topic;
            Description = description;
            IsPublished = isPublished;
            Instructor = instructor;

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
