using System;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Abp.Domain.Services;
using OnlineLearningPlatform.Authorization.Users;

namespace OnlineLearningPlatform.Domain.Students
{
    public class StudentManager : DomainService
    {
        private readonly UserManager _userManager;
        private readonly IRepository<Student, Guid> _studentRepository;

        public StudentManager(UserManager userManager, IRepository<Student, Guid> studentRepository)
        {
            _studentRepository = studentRepository;
            _userManager = userManager;
        }
        public async Task<Student> CreateStudentAsync(string firstName, string surname, string email, string password)
        {
            var user = new User
            {
                UserName = email,
                Name = firstName,
                Surname = surname,
                EmailAddress = email,
               // Password = password,
                IsEmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, password);
            if(!result.Succeeded)
            {
                throw new Exception("Failed to create user: " + string.Join(", ", result.Errors.Select(e => e.Description)));
            }

            await _userManager.AddToRoleAsync(user, "student");

            var student = new Student
            {
                UserId = user.Id,
                StudentId = Guid.NewGuid().ToString(), // Generate a unique StudentId
                EnrollmentDate = DateTime.Now
            };

            await _studentRepository.InsertAsync(student);
            await CurrentUnitOfWork.SaveChangesAsync();

            return student;
        }
        public async Task<Student> GetStudentByUserIdAsync(long userId)
        {
            return await _studentRepository.FirstOrDefaultAsync(s => s.UserId == userId);
        }  
    }
}
