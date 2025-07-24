using Abp.Application.Services;
using Abp.Application.Services.Dto;
using OnlineLearningPlatform.Lessons.Dto;
using System;
using System.Threading.Tasks;

namespace OnlineLearningPlatform.Lessons
{
    public interface ILessonAppService : IApplicationService
    {
        Task<LessonDto> CreateAsync(LessonDto input);
        Task<LessonDto> GetAsync(Guid input);
        Task DeleteAsync(Guid input);
        Task<ListResultDto<LessonDto>> GetAllAsync(Guid courseId);
        Task MarkComplete(CompleteLessonDto input);
    }
}
