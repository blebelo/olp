using Abp.Application.Services;
using OnlineLearningPlatform.Students.Dto;
using System;

namespace OnlineLearningPlatform.Students
{
    public interface IStudentAppService : IAsyncCrudAppService<StudentDto, Guid, GetStudentsInput, CreateStudentDto, UpdateStudentDto>
    {

    }
}
