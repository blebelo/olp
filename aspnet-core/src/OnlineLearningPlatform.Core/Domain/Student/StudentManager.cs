using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Abp.Domain.Services;
using OnlineLearningPlatform.Authorization.Users;
using OnlineLearningPlatform.Domain.Entities;

namespace OnlineLearningPlatform.Domain.Student
{
    public class StudentManager : DomainService
    {
        private readonly IRepository<User, long> _userRepository;
        private readonly IRepository<Student, Guid> _studentRepository;
        private readonly IRepository<Course, Guid> _courseRepository;
        private readonly UserManager _userManager;

        public StudentManager(IRepository<User, long> userRepository, IRepository<Course, Guid> courseRepository, IRepository<Student, Guid> studentRepository, UserManager userManager)
        {
            _studentRepository = studentRepository;
            _userRepository = userRepository;
            _userManager = userManager;
            _courseRepository = courseRepository;
        }
        public async Task<Student> CreateStudentAsync(string username, string name, string surname, string email, string password, string interests, string academicLevel)
        {
            var newUser = new User
            {
                UserName = username,
                Name = name,
                Surname = surname,
                EmailAddress = email
                //IsActive = true,
                //IsEmailConfirmed = true // Assuming email confirmation is required
            };
            newUser.SetNormalizedNames();

            var createUserResult = await _userManager.CreateAsync(newUser, password);
            if (!createUserResult.Succeeded)
            {
                var errorMsg = string.Join(", ", createUserResult.Errors.Select(e => e.Description));
                throw new Abp.UI.UserFriendlyException("Failed to create user: " + errorMsg);
            }
            await _userManager.AddToRoleAsync(newUser, "Student");

            var student = new Student
            {
                UserAccount = newUser,
                Interests = interests,
                AcademicLevel = academicLevel
            };
            await _studentRepository.InsertAsync(student);
            return student;
        }

    }
}
