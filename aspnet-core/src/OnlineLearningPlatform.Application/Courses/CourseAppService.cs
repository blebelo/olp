using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using OnlineLearningPlatform.Courses.Dto;
using OnlineLearningPlatform.Domain.Courses;
using OnlineLearningPlatform.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineLearningPlatform.Courses
{
    public class CourseAppService
        : AsyncCrudAppService<Course, CourseDto, Guid, PagedAndSortedResultRequestDto, CreateCourseDto, UpdateCourseDto>,
          ICourseAppService
    {
        private readonly IRepository<Course, Guid> _courseRepository;

        public CourseAppService(IRepository<Course, Guid> repository)
            : base(repository)
        {
            _courseRepository = repository;
        }

        public override async Task<CourseDto> CreateAsync(CreateCourseDto input)
        {
            var course = ObjectMapper.Map<Course>(input);
            course.Id = Guid.NewGuid();
            course.EnrolledStudents = new List<string>();
            course.Lessons = new List<Lesson>();

            await _courseRepository.InsertAsync(course);
            return MapToEntityDto(course);
        }

        public override async Task<CourseDto> GetAsync(EntityDto<Guid> input)
        {
            var course = await _courseRepository.GetAsync(input.Id);
            return MapToEntityDto(course);
        }

        public override async Task<PagedResultDto<CourseDto>> GetAllAsync(PagedAndSortedResultRequestDto input)
        {
            var totalCount = await _courseRepository.CountAsync();
            var items = await _courseRepository.GetAllListAsync();

            return new PagedResultDto<CourseDto>(
                totalCount,
                ObjectMapper.Map<List<CourseDto>>(items)
            );
        }

        public override async Task<CourseDto> UpdateAsync(UpdateCourseDto input)
        {
            var course = await _courseRepository.GetAsync(input.Id);

            ObjectMapper.Map(input, course);
            await _courseRepository.UpdateAsync(course);

            return MapToEntityDto(course);
        }

        public override async Task<ActionResult<string>> DeleteAsync(EntityDto<Guid> input)
        {
            await _courseRepository.DeleteAsync(input.Id);
            return new OkObjectResult("Course deleted successfully.");
        }

    }
}
