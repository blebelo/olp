using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using Abp.UI;
using OnlineLearningPlatform.Domain.Courses;
using OnlineLearningPlatform.Domain.Entities;
using OnlineLearningPlatform.Domain.Instructors;
using OnlineLearningPlatform.Lessons.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineLearningPlatform.Lessons
{
    public class LessonAppService : ApplicationService, ILessonAppService
    {
        private readonly IRepository<Course, Guid> _courseRepository;
        private readonly IRepository<Lesson, Guid> _lessonRepository;

        public LessonAppService(
            IRepository<Lesson, Guid> lessonRepository, 
            IRepository<Course, Guid> courseRepository
            )
        {
            _courseRepository = courseRepository;
            _lessonRepository = lessonRepository;
        }

        public async Task<LessonDto> GetAsync(Guid lessonId)
        {
            try
            {
                var lesson = await _lessonRepository.GetAsync(lessonId);
                return ObjectMapper.Map<LessonDto>(lesson);
            }
            catch (EntityNotFoundException)
            {
                throw new UserFriendlyException("The requested lesson was not found.");
            }
            catch (Exception)
            {
                throw new UserFriendlyException("An error occurred while retrieving the lesson.");
            }
        }

        public async Task DeleteAsync(Guid lessonId)
        {
            try
            {
                await _lessonRepository.DeleteAsync(lessonId);
            }
            catch (EntityNotFoundException)
            {
                throw new UserFriendlyException("The lesson you're trying to delete doesn't exist.");
            }
            catch (Exception)
            {
                throw new UserFriendlyException("Failed to delete the lesson. Please try again.");
            }
        }

        public async Task<ListResultDto<LessonDto>> GetAllAsync(Guid courseId)
        {
            try
            {
                var course = await _courseRepository.GetAsync(courseId);
                var lessons = course.Lessons;

                if (lessons == null || lessons.Count == 0)
                {
                    return new ListResultDto<LessonDto>(new List<LessonDto>());
                }

                return new ListResultDto<LessonDto>(
                    ObjectMapper.Map<List<LessonDto>>(lessons)
                );
            }
            catch (EntityNotFoundException)
            {
                throw new UserFriendlyException("The course was not found.");
            }
            catch (Exception)
            {
                throw new UserFriendlyException("Failed to load lessons for the course.");
            }
        }

        public Task<LessonDto> CreateAsync(LessonDto input)
        {
            throw new NotImplementedException("You may only create a lesson from a Course. ");
        }
    }
}
