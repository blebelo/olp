using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using OnlineLearningPlatform.Courses.Dto;
using OnlineLearningPlatform.Domain.Courses;
using OnlineLearningPlatform.Domain.Entities;
using OnlineLearningPlatform.Instructors.Dto;
using OnlineLearningPlatform.Lessons.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
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
            course.EnrolledStudents = new List<string>();
            course.Lessons = new List<Lesson>();

            await _courseRepository.InsertAsync(course);
            return ObjectMapper.Map<CourseDto>(course);
        }

        public override async Task<CourseDto> GetAsync(EntityDto<Guid> input)
        {
            var course = await _courseRepository.GetAsync(input.Id);
            return ObjectMapper.Map<CourseDto>(course);
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
            course.Title = input.Title;
            course.Topic = input.Topic;
            course.Description = input.Description;

            await _courseRepository.UpdateAsync(course);
            return ObjectMapper.Map<CourseDto>(course);
        }


        public async Task EnrollStudentAsync(Guid courseId, string student)
        {
            var course = await _courseRepository.GetAsync(courseId);

            if (!course.EnrolledStudents.Contains(student))
            {
                course.EnrolledStudents.Add(student);
                await _courseRepository.UpdateAsync(course);
            }
        }

        public async Task UnEnrollStudentAsync(Guid courseId, string student)
        {
            var course = await _courseRepository.GetAsync(courseId);

            if (course.EnrolledStudents.Contains(student))
            {
                course.EnrolledStudents.Remove(student);
                await _courseRepository.UpdateAsync(course);
            }
        }

        public async Task AddLessonAsync(Guid courseId, LessonDto lessonDto)
        {
            var course = await _courseRepository.GetAsync(courseId);

            var lesson = ObjectMapper.Map<Lesson>(lessonDto);

            if (!course.Lessons.Any(l => l.Title == lesson.Title))
            {
                course.Lessons.Add(lesson);
                await _courseRepository.UpdateAsync(course);
            }
        }

        public async Task RemoveLessonAsync(Guid courseId, Guid lessonId)
        {
            var course = await _courseRepository.GetAsync(courseId);
            var lesson = course.Lessons.FirstOrDefault(l => l.Id == lessonId);
            if (lesson != null)
            {
                course.Lessons.Remove(lesson);
                await _courseRepository.UpdateAsync(course);
            }
        }


    }
}
