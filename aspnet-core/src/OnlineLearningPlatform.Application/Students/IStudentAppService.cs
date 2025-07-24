using Abp.Application.Services;
using OnlineLearningPlatform.Courses.Dto;
using OnlineLearningPlatform.Students.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineLearningPlatform.Students
{
    public interface IStudentAppService : IAsyncCrudAppService<StudentDto, Guid, GetStudentsInput, CreateStudentDto, UpdateStudentDto>
    {

        Task<StudentProfileDto> GetStudentProfileAsync();

        Task<StudentProfileDto> UpdateStudentProfileAsync(UpdateStudentDto input);

        public Task<ICollection<CourseDto>> GetCoursesAsync(long userId);
    }
}
