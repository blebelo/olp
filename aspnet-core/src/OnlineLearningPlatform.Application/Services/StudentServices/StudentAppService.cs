using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Domain.Repositories;
using OnlineLearningPlatform.Authorization.Users;
using OnlineLearningPlatform.Courses;
using OnlineLearningPlatform.Domain.Courses;
using OnlineLearningPlatform.Domain.Students;
using OnlineLearningPlatform.Services.StudentServices.Dto;

namespace OnlineLearningPlatform.Services.StudentServices
{
    public class StudentAppService : AsyncCrudAppService<Student, CreateStudentDto, Guid>
    {
        private readonly IRepository<Student, Guid> _studentRepository;
        private readonly IRepository<Course, Guid> _courseRepository;
        private readonly IRepository<User, long> _userRepository;
        private readonly UserManager _userManager;
        private readonly StudentManager _studentManager;
        private readonly ICourseAppService _courseAppService;

        public StudentAppService(IRepository<Student, Guid> studentRepository, StudentManager studentManager):base(studentRepository) 
        {
            _studentRepository = studentRepository;
            _studentManager = studentManager;
        }
        public override async Task<CreateStudentDto> CreateAsync(CreateStudentDto input)
        {
            var createStudent = await _studentManager.CreateStudentAsync(input.UserName, input.Name, input.Surname, input.Email, input.Password, input.Interests, input.AcademicLevel);

            return input;
        }
        
    }
}
