using Abp.Application.Services;
using Abp.Domain.Repositories;
using OnlineLearningPlatform.Courses.Dto;
using OnlineLearningPlatform.Domain.Entities;
using System;

namespace OnlineLearningPlatform.Courses
{
    public class CourseAppService : AsyncCrudAppService<Course, CreateCourseDto, Guid>, ICourseAppService
    {
        private readonly IRepository<Course, Guid> _courseRepository;
        public CourseAppService(IRepository<Course, Guid> repository)
            : base(repository)
        {
            _courseRepository = repository;
        }

    }
}
