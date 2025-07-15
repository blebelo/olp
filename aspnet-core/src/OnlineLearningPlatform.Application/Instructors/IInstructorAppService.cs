using Abp.Application.Services;
using OnlineLearningPlatform.Instructors.Dto;
using System;

namespace OnlineLearningPlatform.Instructors
{
    public interface IInstructorAppService: IAsyncCrudAppService<CreateInstructorDto, Guid>
    {
    }
}
