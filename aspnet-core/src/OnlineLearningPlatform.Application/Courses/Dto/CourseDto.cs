using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using OnlineLearningPlatform.Domain.Courses;
using OnlineLearningPlatform.Lessons.Dto;
using OnlineLearningPlatform.Quizzes.Dto;
using System;
using System.Collections.Generic;

namespace OnlineLearningPlatform.Courses.Dto
{
    [AutoMap(typeof(Course))]
    public class CourseDto: EntityDto<Guid>
    {
        public string Title { get; set; }
        public string Topic { get; set; }
        public string Description { get; set; }
        public string CoverImageUrl { get; set; }
        public bool IsPublished { get; set; }
        public string Instructor { get; set; }
        public ICollection<string> EnrolledStudents { get; set; }
        public ICollection<LessonDto> Lessons { get; set; }
        public QuizDto Quiz { get; set; } 
        
    }
}
