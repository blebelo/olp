using Abp.Application.Services;
using Abp.Domain.Repositories;
using OnlineLearningPlatform.Domain.Entities;
using OnlineLearningPlatform.Lessons.Dto;
using System.Threading.Tasks;
using Abp.UI;
using Abp.Application.Services.Dto;
using System;

namespace OnlineLearningPlatform.Lessons
{
    public class LessonAppService : AsyncCrudAppService<Lesson, CreateLessonDto, Guid>
    {
        private readonly IRepository<Lesson, Guid> _lessonRepository;

        public LessonAppService(IRepository<Lesson, Guid> lessonRepository)
            : base(lessonRepository)
        {
            _lessonRepository = lessonRepository;
        }

        public override async Task<CreateLessonDto> CreateAsync(CreateLessonDto input)
        {
            var newLesson = new Lesson
            {
                Title = input.Title,
                Description = input.Description,
                VideoLink = input.VideoLink,
                Instructor = input.Instructor,
                IsCompleted = input.isCompleted,
                StudyMaterialLinks = input.StudyMaterialLinks
            };

            await _lessonRepository.InsertAsync(newLesson);

            return input;
        }


    }
}
