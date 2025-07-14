using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using OnlineLearningPlatform.Domain.Students;
using OnlineLearningPlatform.Services.StudentServices.DTOs;

namespace OnlineLearningPlatform.Services.StudentServices
{
    public class StudentAppService : ApplicationService, IStudentAppService
    {
        private readonly StudentManager _studentManager;

        public StudentAppService(StudentManager studentManager)
        {
            _studentManager = studentManager;
        }
        public async Task<StudentDTO> RegisterStudentAsync(CreateStudentDTO input)
        {
            var student = await _studentManager.CreateStudentAsync(input.FirstName, input.LastName, input.EmailAddress, input.Password);
            return new StudentDTO
            {
                Id = student.Id,
                StudentId = student.StudentId,
                FirstName = student.User.Name,
                LastName = student.User.Surname,
                EmailAddress = student.User.EmailAddress,
                EnrollmentDate = student.EnrollmentDate
            };
        }
    }
}
