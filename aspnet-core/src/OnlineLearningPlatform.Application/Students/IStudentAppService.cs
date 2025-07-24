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

        Task<List<CourseDto>> GetStudentEnrolledCoursesAsync(Guid studentId);

        Task EnrollStudentInCourseAsync(Guid studentId, Guid courseId);

        Task UnenrollStudentFromCourseAsync(Guid studentId, Guid courseId);
    }
}
