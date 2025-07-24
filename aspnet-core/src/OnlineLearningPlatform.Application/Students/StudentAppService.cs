using Abp.Application.Services;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using Abp.UI;
using Microsoft.EntityFrameworkCore;
using OnlineLearningPlatform.Authorization.Users;
using OnlineLearningPlatform.Courses.Dto;
using OnlineLearningPlatform.Domain.Courses;
using OnlineLearningPlatform.Domain.Entities;
using OnlineLearningPlatform.Domain.Quizzes;
using OnlineLearningPlatform.Domain.StudentProgresses;
using OnlineLearningPlatform.Domain.Students;
using OnlineLearningPlatform.Lessons.Dto;
using OnlineLearningPlatform.Quizzes.Dto;
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

        public StudentAppService(
            IRepository<Student, Guid> studentRepository, 
            StudentManager studentManager, 
            UserManager userManager, 
            IRepository<Course, Guid> courseRepository
            )
            : base(studentRepository)
        {
            _studentRepository = studentRepository;
            _studentManager = studentManager;
            _courseRepository = courseRepository;
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


                return ObjectMapper.Map<StudentDto>(newStudent);
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException("An error occurred while creating the student. Please try again.");
            }
        }

        public async Task<StudentProfileDto> GetStudentProfileAsync()
        {
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

        public async Task<ICollection<CourseDto>> GetCoursesAsync(long userId)
        {
            var student = await _studentRepository
                .GetAllIncluding(s => s.UserAccount, s => s.EnrolledCourses)
                .FirstOrDefaultAsync(s => s.UserAccount != null && s.UserAccount.Id == userId);


            var courses = student.EnrolledCourses;

            if (courses == null || courses.Count == 0)
            {
                throw new UserFriendlyException("No courses found for this instructor.");
            }
            var listOfCourses = new List<CourseDto>();

            foreach (var course in courses)
            {
                try
                {
                    var dto = new CourseDto
                    {
                        Id = course.Id,
                        Title = course.Title,
                        Topic = course.Topic,
                        Description = course.Description,
                        IsPublished = course.IsPublished,
                        Instructor = course.Instructor != null
                            ? $"{course.Instructor.Name} {course.Instructor.Surname}"
                            : "No Instructor",
                        EnrolledStudents = course.EnrolledStudents != null
                            ? course.EnrolledStudents.Select(s => $"{s.Name} {s.Surname}").ToList()
                            : new List<string>(),
                        Lessons = course.Lessons != null
                            ? ObjectMapper.Map<List<LessonDto>>(course.Lessons)
                            : new List<LessonDto>(),
                        Quiz = course.Quiz != null
                            ? ObjectMapper.Map<QuizDto>(course.Quiz)
                            : null
                    };

                    listOfCourses.Add(dto);
                }
                catch (Exception ex)
                {
                    throw new UserFriendlyException($"Failed to map Course ID: {course.Id}. Reason: {ex.Message}");
                }

            }
            return listOfCourses;
        }

    }
}
