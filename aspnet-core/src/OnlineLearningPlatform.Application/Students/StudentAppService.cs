using Abp.Application.Services;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using Abp.UI;
using Microsoft.EntityFrameworkCore;
using OnlineLearningPlatform.Authorization.Users;
using OnlineLearningPlatform.Courses.Dto;
using OnlineLearningPlatform.Domain.Courses;
using OnlineLearningPlatform.Domain.Students;
using OnlineLearningPlatform.EmailService;
using OnlineLearningPlatform.Students.Dto;
using Sprache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineLearningPlatform.Students
{
    public class StudentAppService : AsyncCrudAppService<Student, StudentDto, Guid, GetStudentsInput, CreateStudentDto, UpdateStudentDto>, IStudentAppService
    {
        private readonly IRepository<Student, Guid> _studentRepository;
        private readonly IRepository<Course, Guid> _courseRepository;
        private readonly IRepository<User, long> _userRepository;
        private readonly StudentManager _studentManager;
        private readonly EmailAdminService _emailService;

        public StudentAppService(IRepository<Student, Guid> studentRepository, StudentManager studentManager, UserManager userManager, IRepository<Course, Guid> courseRepository, EmailAdminService emailService)
            : base(studentRepository)
        {
            _studentRepository = studentRepository;
            _studentManager = studentManager;
            _courseRepository = courseRepository;
            _emailService = emailService;

        }
        public override async Task<StudentDto> CreateAsync(CreateStudentDto input)
        {
            try
            {
                var newStudent = await _studentManager.CreateStudentAsync(
                    input.UserName,
                    input.Name,
                    input.Surname,
                    input.Email,
                    input.Password,
                    input.Interests,
                    input.AcademicLevel
                );

                // Send welcome email after successful creation
                await SendWelcomeEmailAsync(input.Email, input.Name, "Student");

                return ObjectMapper.Map<StudentDto>(newStudent);
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException("An error occurred while creating the student. Please try again.");
            }
        }


        private async Task SendWelcomeEmailAsync(string email, string name, string role)
        {
            var subject = "Welcome to Your Learning Journey! 🚀";
            var message = $@"Hey {name}! 

            Welcome to the future of education! You've just stepped into a realm where knowledge meets innovation, and learning transcends traditional boundaries. 

            As an Student, you're not just joining a platform – you're becoming part of a revolutionary movement that's reshaping how we share wisdom, inspire minds, and unlock human potential. Get ready to elevate your teaching to dimensions you never imagined possible.

            Your mission to transform lives through learning starts now. Let's create some educational magic together! ✨

            Stay inspired, stay innovative!
            The OLP Team";

            await _emailService.SendEmail(subject, email, name, message);
        }


        public async Task<StudentProfileDto> GetStudentProfileAsync()
        {

            //Find the student by the current user
            var student = await _studentRepository
                .GetAll()
                .Include(s => s.UserAccount)
                .FirstOrDefaultAsync(s => s.UserAccount != null && s.UserAccount.Id == AbpSession.UserId.Value);


            if (student == null)
                throw new UserFriendlyException("Student not found");
            return new StudentProfileDto
            {
                Id = student.Id,
                Name = student.UserAccount?.Name,
                Surname = student.UserAccount?.Surname,
                UserName = student.UserAccount?.UserName,
                Interests = student.Interests,
                AcademicLevel = student.AcademicLevel
            };
        }


        public async Task<StudentProfileDto> UpdateStudentProfileAsync(UpdateStudentDto input)
        {
            var student = await _studentRepository
                .GetAll()
                .Include(s => s.UserAccount)
                .FirstOrDefaultAsync(s => s.UserAccount != null && s.UserAccount.Id == AbpSession.UserId.Value);


            if (student == null)
            {
                throw new UserFriendlyException("Student profile not found.");
            }

            student.UserAccount.Name = input.Name;
            student.UserAccount.Surname = input.Surname;
            student.UserAccount.UserName = input.UserName;
            student.Interests = input.Interests;
            student.AcademicLevel = input.AcademicLevel;

            await _studentRepository.UpdateAsync(student);


            return new StudentProfileDto
            {
                Id = student.Id,
                Name = student.Name,
                Surname = student.Surname,
                UserName = student.UserName,
                Interests = student.Interests,
                AcademicLevel = student.AcademicLevel,
            };

        }


        public async Task<List<CourseDto>> GetStudentEnrolledCoursesAsync(Guid studentId)
        {
            try
            {
                var student = await _studentRepository.GetAsync(studentId);

                if (student?.EnrolledCourses == null || !student.EnrolledCourses.Any())
                    return new List<CourseDto>();

                var courseIds = student.EnrolledCourses
                    .Select(ec => ec.Id)
                    .Distinct()
                    .ToList();

                var courses = await _courseRepository.GetAllListAsync(c => courseIds.Contains(c.Id));

                return ObjectMapper.Map<List<CourseDto>>(courses);
            }
            catch (EntityNotFoundException)
            {
                throw new UserFriendlyException("Student not found.");
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException("An error occurred while retrieving enrolled courses.");
            }
        }

    }
}
