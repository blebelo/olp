using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using OnlineLearningPlatform.Services.StudentServices.DTOs;

namespace OnlineLearningPlatform.Services.StudentServices
{
    public interface IStudentAppService : IApplicationService
    {
        Task<StudentDTO> RegisterStudentAsync(CreateStudentDTO input);
       // Task<StudentDTO> GetCurrentStudentAsync();
    }
}
