using Abp.Domain.Repositories;
using Abp.Domain.Services;
using OnlineLearningPlatform.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineLearningPlatform.Domain.Courses
{
    public class CourseManager: DomainService
    {
        private readonly IRepository<Course, Guid> _courseRepository;
        public CourseManager(IRepository<Course, Guid> courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<Course> CreateCourseAsync(string title, string topic, string description, bool isPublished, string instructor)
        {
            var course = new Course
            {
                Title = title,
                Topic = topic,
                Description = description,
                IsPublished = isPublished,
                Instructor = instructor,
                EnrolledStudents = new List<string>(),
                Lessons = new List<Lesson>()
            };
            await _courseRepository.InsertAsync(course);
            return course;
        }
        public async Task<Course> UpdateCourseAsync(string title,  string topic, string description)
        {
            var course = new Course
            {
                Title = title,
                Topic = topic,
                Description = description
            };

            await _courseRepository.UpdateAsync(course);
            return course;
        }
    }
}
