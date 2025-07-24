using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Abp.UI;
using OnlineLearningPlatform.Authorization.Users;
using System;
using System.Threading.Tasks;

namespace OnlineLearningPlatform.Domain.Students
{
    public class StudentManager : DomainService
    {
        private readonly IRepository<Student, Guid> _studentRepository;
        private readonly UserManager _userManager;

        public StudentManager(IRepository<Student, Guid> studentRepository, UserManager userManager)
        {
            _studentRepository = studentRepository;
            _userManager = userManager;
        }
        public async Task<Student> CreateStudentAsync(
                string username,
                string name,
                string surname,
                string email,
                string password,
                string interests,
                string academicLevel
            )
        {
            var newUser = new User
            {
                Name = name,
                Surname = surname,
                UserName = username,
                EmailAddress = email

            };

            var userCreationResult = await _userManager.CreateAsync(newUser, password);

            if (!userCreationResult.Succeeded)
            {
                throw new UserFriendlyException($"User creation failed");
            }
            await _userManager.AddToRoleAsync(newUser, "Student");

            var student = new Student
            {
                Name = name,
                Surname = surname,
                UserName = username,
                Email = email,
                UserAccount = newUser,
                Interests = interests,
                AcademicLevel = academicLevel
            };

            await _studentRepository.InsertAsync(student);

            return student;
        }

    }
}
