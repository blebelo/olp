using Abp.Application.Services;
using Abp.Domain.Repositories;
using OnlineLearningPlatform.Courses.Dto;
using OnlineLearningPlatform.Domain.Courses;
using OnlineLearningPlatform.Instructors.Dto;
using System;
using System.Threading.Tasks;

namespace OnlineLearningPlatform.Courses
{
    public class CourseAppService : AsyncCrudAppService<Course, CreateCourseDto, Guid>, ICourseAppService
    {
        private readonly CourseManager _courseManager;
        public CourseAppService(IRepository<Course, Guid> repository, CourseManager courseManager)
            : base(repository)
        {
            _courseManager = courseManager;
        }

        public async override Task<CreateCourseDto> CreateAsync(CreateCourseDto input)
        {
            await _courseManager.CreateCourseAsync(
                input.Title,
                input.Topic,
                input.Description,
                input.IsPublished,
                input.Instructor
            );
            return input;
        }


        public async Task<UpdateCourseDto> UpdateAsync(UpdateCourseDto input)
        {
            await _courseManager.UpdateCourseAsync(
                input.Title,
                input.Topic,
                input.Description
            );
            return input;
        }
    }
}
