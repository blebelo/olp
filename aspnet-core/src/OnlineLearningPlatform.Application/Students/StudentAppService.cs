using Abp.Application.Services;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using Abp.UI;
using OnlineLearningPlatform.Authorization.Users;
using OnlineLearningPlatform.Courses;
using OnlineLearningPlatform.Courses.Dto;
using OnlineLearningPlatform.Domain.Courses;
using OnlineLearningPlatform.Domain.Students;
using OnlineLearningPlatform.Students.Dto;
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

        public StudentAppService(IRepository<Student, Guid> studentRepository, StudentManager studentManager, UserManager userManager, IRepository<Course, Guid> courseRepository)
            : base(studentRepository)
        {
            _studentRepository = studentRepository;
            _studentManager = studentManager;
            _courseRepository = courseRepository;
        }
        public override async Task<StudentDto> CreateAsync(CreateStudentDto input)
        {
            Logger.Info($"Creating a new student with input: {input}");
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

                return ObjectMapper.Map<StudentDto>(newStudent);
            }
            catch (Exception ex)
            {
                Logger.Error("Failed to create student", ex);
                throw new UserFriendlyException("An error occurred while creating the student. Please try again.");
            }
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
                Logger.Error($"Failed to retrieve enrolled courses for student ID: {studentId}", ex);
                throw new UserFriendlyException("An error occurred while retrieving enrolled courses.");
            }
        }

    }
}
