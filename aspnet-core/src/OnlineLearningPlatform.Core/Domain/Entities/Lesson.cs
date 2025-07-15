using System;

namespace OnlineLearningPlatform.Domain.Entities
{
    public class Lesson
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Instructor { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Lesson()
        {
            CreatedDate = DateTime.UtcNow;
            UpdatedDate = DateTime.UtcNow;
        }
        public Lesson(string title, string content, string instructor)
        {
            Title = title;
            Content = content;
            Instructor = instructor;
            CreatedDate = DateTime.UtcNow;
            UpdatedDate = DateTime.UtcNow;
        }
    }
}
