using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using Abp.UI;
using OnlineLearningPlatform.Domain.Courses;
using OnlineLearningPlatform.Domain.Entities;
using OnlineLearningPlatform.Domain.StudentProgresses;
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
        private readonly IRepository<StudentProgress, Guid> _progressRepository;

        public LessonAppService(
            IRepository<Lesson, Guid> lessonRepository, 
            IRepository<Course, Guid> courseRepository,
            IRepository<StudentProgress, Guid> progressRepository)
        {
            _courseRepository = courseRepository;
            _lessonRepository = lessonRepository;
            _progressRepository = progressRepository;
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

        public async Task MarkComplete(CompleteLessonDto input)
        {
            try
            {
                var lesson = await _lessonRepository.GetAsync(input.lessonId);

                var progress = await _progressRepository.FirstOrDefaultAsync(
                    p => p.StudentId == input.studentId && p.CourseId == lesson.Course.Id);

                if (progress == null)
                {
                    throw new UserFriendlyException("Student is not enrolled in this course.");
                }

                if (progress.CompletedLessonIds.Contains(input.lessonId))
                {
                    throw new UserFriendlyException("Lesson is already marked as complete.");
                }

                progress.CompletedLessonIds.Add(input.lessonId);

                await UpdateCompletionPercentage(progress, lesson.Course.Id);

                await _progressRepository.UpdateAsync(progress);
            }
            catch (EntityNotFoundException)
            {
                throw new UserFriendlyException("The lesson or student was not found.");
            }
            catch (UserFriendlyException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException("Could not mark lesson as complete.");
            }
        }

        private async Task UpdateCompletionPercentage(StudentProgress progress, Guid courseId)
        {
            var totalLessons = await _lessonRepository.CountAsync(l => l.Course.Id == courseId);
            var completedCount = progress.CompletedLessonIds.Count;

            progress.CompletionPercentage = totalLessons > 0 ? (double)completedCount / totalLessons * 100 : 0;

            if (completedCount == totalLessons && totalLessons > 0)
            {
                progress.IsCompleted = true;
            }
        }
        public Task<LessonDto> CreateAsync(LessonDto input)
        {
            throw new NotImplementedException("You may only create a lesson from a Course. ");
        }
    }
}
