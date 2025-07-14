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
                EnrollmentDate = student.EnrollmentDate,
            };
        }
        //public async Task<StudentDTO> GetCurrentStudentAsync()
        //{
        //    var userId = AbpSession.UserId;
        //    if (!userId.HasValue)
        //    {
        //        throw new Exception("User is not logged in.");
        //    }
        //    var student = await _studentManager.GetStudentByUserIdAsync(userId.Value);
        //    if (student == null)
        //    {
        //        throw new Exception("Student not found for the current user.");
        //    }
        //    return new StudentDTO
        //    {
        //        StudentId = student.Id.ToString(),
        //        FirstName = student.User.Name,
        //        LastName = student.User.Surname,
        //        EmailAddress = student.User.EmailAddress,
        //        EnrollmentDate = student.EnrollmentDate,
        //        // UserId = student.UserId
        //    };
           }
}
