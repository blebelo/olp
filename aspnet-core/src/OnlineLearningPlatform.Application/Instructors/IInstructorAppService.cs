using Abp.Application.Services;
using OnlineLearningPlatform.Courses.Dto;
using OnlineLearningPlatform.Instructors.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineLearningPlatform.Instructors
{
    public interface IInstructorAppService: IAsyncCrudAppService<CreateInstructorDto, Guid>
    {
        public Task<ICollection<CourseDto>> GetCoursesAsync(long userId);
    }
}
