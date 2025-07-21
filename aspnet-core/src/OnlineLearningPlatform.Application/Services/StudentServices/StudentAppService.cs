using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Abp.Application.Services;
using Abp.Domain.Repositories;
using Abp.Runtime.Session;
using Abp.UI;
using Microsoft.AspNetCore.Http.HttpResults;
using OnlineLearningPlatform.Authorization.Users;
using OnlineLearningPlatform.Courses;
using OnlineLearningPlatform.Domain.Courses;
using OnlineLearningPlatform.Domain.Entities;
using OnlineLearningPlatform.Domain.StudentCourses;
using OnlineLearningPlatform.Domain.Students;
using OnlineLearningPlatform.Services.StudentServices.Dto;

namespace OnlineLearningPlatform.Services.StudentServices
{
    public class StudentAppService : AsyncCrudAppService<Student, StudentDto, Guid, GetStudentsInput, CreateStudentDto, UpdateStudentDto>, IStudentAppService
    {
        private readonly IRepository<Student, Guid> _studentRepository;
        private readonly IRepository<Course, Guid> _courseRepository;
        private readonly IRepository<User, long> _userRepository;
        private IRepository<StudentCourse, Guid> _studentCourseRepository;
        private readonly UserManager _userManager;
        private readonly StudentManager _studentManager;
        private readonly ICourseAppService _courseAppService;

        public StudentAppService(IRepository<Student, Guid> studentRepository, StudentManager studentManager, UserManager userManager, IRepository<Course, Guid> courseRepository, IRepository<StudentCourse, Guid> studentCourseRepository) : base(studentRepository)
        {
            _userManager = userManager;
            _studentRepository = studentRepository;
            _studentManager = studentManager;
            _courseRepository = courseRepository;
            _studentCourseRepository = studentCourseRepository;
        }
        public override async Task<StudentDto> CreateAsync(CreateStudentDto input)
        {
            var createStudent = await _studentManager.CreateStudentAsync(input.UserName, input.Name, input.Surname, input.Email, input.Password, input.Interests, input.AcademicLevel);

            return new StudentDto
            {
                Id = createStudent.Id,
                Name = createStudent.Name,
                Surname = createStudent.Surname,
                Interests = createStudent.Interests,
                AcademicLevel = createStudent.AcademicLevel,
                EnrolledCoursesCount = 0, // Initially no courses are enrolled
                EnrolledCourses = new List<CourseDtos>()
            };
        }
        //Enrollment
        public async Task EnrollStudentInCourseAsync(Guid studentId, Guid courseId)
        {
            var student = await _studentRepository.GetAsync(studentId);
            if (student == null)
                throw new UserFriendlyException("Student not found");

            // Check if course exists
            var course = await _courseRepository.GetAsync(courseId);
            if (course == null)
                throw new UserFriendlyException("Course not found");

            var existingEnrollment = await _studentCourseRepository.FirstOrDefaultAsync(sc =>
                sc.StudentId == studentId && sc.CourseId == courseId);

            if (existingEnrollment != null)
                throw new UserFriendlyException("Student is already enrolled in this course");

            var studentCourse = new StudentCourse
            {
                StudentId = studentId,
                CourseId = courseId
            };

            await _studentCourseRepository.InsertAsync(studentCourse);
        }
        public async Task UnenrollStudentFromCourseAsync(Guid studentId, Guid courseId)
        {
            var enrollment = await _studentCourseRepository.FirstOrDefaultAsync(sc =>
                sc.StudentId == studentId && sc.CourseId == courseId);

            if (enrollment == null)
                throw new UserFriendlyException("Student is not enrolled in this course");

            await _studentCourseRepository.DeleteAsync(enrollment);
        }
        public async Task<List<CourseDtos>> GetStudentEnrolledCoursesAsync(Guid studentId)
        {
            var enrollments = await _studentCourseRepository.GetAllListAsync(sc => sc.StudentId == studentId);
            if (!enrollments.Any())
                return new List<CourseDtos>();

            var courseIds = enrollments.Select(sc => sc.CourseId).ToList();
            var courses = await _courseRepository.GetAllListAsync(c => courseIds.Contains(c.Id));

            // Map courses to DTOs
            return courses.Select(c => new CourseDtos
            {
                Id = c.Id,
                Title = c.Title,
                Topic = c.Topic,
                Description = c.Description,
                IsPublished = c.IsPublished,
                Instructor = c.Instructor
            }).ToList();
        }
    }
}
