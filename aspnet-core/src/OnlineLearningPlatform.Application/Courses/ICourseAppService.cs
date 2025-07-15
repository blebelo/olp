using Abp.Application.Services;
using OnlineLearningPlatform.Courses.Dto;
using System;

namespace OnlineLearningPlatform.Courses
{
    public interface ICourseAppService : IAsyncCrudAppService<CreateCourseDto, Guid>
    { 
    }
}
