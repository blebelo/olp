using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using OnlineLearningPlatform.Services.StudentServices.Dto;

namespace OnlineLearningPlatform.Services.StudentServices
{
    public interface IStudentAppService : IAsyncCrudAppService<CreateStudentDto, Guid, GetStudentsInput, CreateStudentDto, UpdateStudentDto>
    {
        Task EnrollStudentInCourseAsync(Guid studentId, Guid courseId);
        Task UnenrollStudentFromCourseAsync(Guid studentId, Guid courseId);
        Task<List<CourseDtos>> GetStudentEnrolledCoursesAsync(Guid studentId);
        // Task<List<CourseDto>> GetAvailableCoursesForStudentAsync(Guid studentId);
    }
}
