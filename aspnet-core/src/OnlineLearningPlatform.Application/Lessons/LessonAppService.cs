using Abp.Application.Services;
using Abp.Domain.Repositories;
using OnlineLearningPlatform.Domain.Entities;
using OnlineLearningPlatform.Lessons.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;

namespace OnlineLearningPlatform.Lessons
{
    public class LessonAppService : ApplicationService, ILessonAppService
    {
        private readonly IRepository<Lesson, Guid> _lessonRepository;

        public LessonAppService(IRepository<Lesson, Guid> lessonRepository)
        {
            _lessonRepository = lessonRepository;
        }

        public async Task<LessonDto> CreateAsync(CreateLessonDto input)
        {
            var lesson = ObjectMapper.Map<Lesson>(input);
            await _lessonRepository.InsertAsync(lesson);
            return ObjectMapper.Map<LessonDto>(lesson);
        }

        public async Task<LessonDto> GetAsync(EntityDto<Guid> input)
        {
            var lesson = await _lessonRepository.GetAsync(input.Id);
            return ObjectMapper.Map<LessonDto>(lesson);
        }

        public async Task DeleteAsync(EntityDto<Guid> input)
        {
            await _lessonRepository.DeleteAsync(input.Id);
        }

        public async Task<ListResultDto<LessonDto>> GetAllAsync()
        {
            var lessons = await _lessonRepository.GetAllListAsync();
            return new ListResultDto<LessonDto>(ObjectMapper.Map<List<LessonDto>>(lessons));
        }
    }
}
