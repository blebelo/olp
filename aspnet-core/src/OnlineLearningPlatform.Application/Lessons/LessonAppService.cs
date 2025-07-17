using Abp.Application.Services;
using Abp.Domain.Repositories;
using OnlineLearningPlatform.Domain.Entities;
using OnlineLearningPlatform.Lessons.Dto;

namespace OnlineLearningPlatform.Lessons
{
    public class LessonAppService : AsyncCrudAppService<Lesson, CreateLessonDto, int>
    {
        private readonly IRepository<Lesson, int> _lessonRepository;
        public LessonAppService(IRepository<Lesson, int> lessonRepository)
            : base(lessonRepository)
        {
            _lessonRepository = lessonRepository;
        }

    }
}
