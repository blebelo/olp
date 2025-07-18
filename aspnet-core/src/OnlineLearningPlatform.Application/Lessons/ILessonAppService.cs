using Abp.Application.Services;
using Abp.Application.Services.Dto;
using OnlineLearningPlatform.Lessons.Dto;
using System;
using System.Threading.Tasks;

namespace OnlineLearningPlatform.Lessons
{
    public interface ILessonAppService : IApplicationService
    {
        Task<LessonDto> CreateAsync(CreateLessonDto input);
        Task<LessonDto> GetAsync(EntityDto<Guid> input);
        Task DeleteAsync(EntityDto<Guid> input);
        Task<ListResultDto<LessonDto>> GetAllAsync();
    }
}
