using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using OnlineLearningPlatform.Services.StudentServices.Dto;

namespace OnlineLearningPlatform.Services.StudentServices
{
    public interface IStudentAppService : IAsyncCrudAppService<CreateStudentDto, Guid>
    {
        ////Dashboard
        //Task<StudentDashboardDto> GetDashboardAsync();

        ////Enrollment
        //Task<bool> EnrollInCourseAsync(EnrollInCourseDto input);
        //Task<bool> UnenrollFromCourseAsync(Guid course);

        ////Student Info
        //Task<StudentDto> GetCurrentStudentAsync();
       
        //Task<List<CourseDto>> GetMyCoursesAsync();
    }
}
