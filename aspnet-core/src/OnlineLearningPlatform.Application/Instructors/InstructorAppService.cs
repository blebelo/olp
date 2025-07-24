using Abp.Application.Services;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.UI;
using Microsoft.EntityFrameworkCore;
using OnlineLearningPlatform.Authorization.Users;
using OnlineLearningPlatform.Courses.Dto;
using OnlineLearningPlatform.Domain.Instructors;
using OnlineLearningPlatform.Instructors.Dto;
using OnlineLearningPlatform.Lessons.Dto;
using OnlineLearningPlatform.Quizzes.Dto;
using Sprache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineLearningPlatform.Instructors
{
    public class InstructorAppService : AsyncCrudAppService<Instructor, CreateInstructorDto, Guid>
    {
        private readonly IRepository<Instructor, Guid> _instructorRepository;
        private readonly UserManager _userManager;
        private readonly InstructorManager _instructorManager;

        public InstructorAppService(
            IRepository<Instructor, Guid> repository,
            UserManager userManager,
            InstructorManager instructorManager
            )
            : base(repository)
        {
            _instructorRepository = repository;
            _userManager = userManager;
            _instructorManager = instructorManager;
        }

        public override async Task<CreateInstructorDto> CreateAsync(CreateInstructorDto input)
        {

            var createInstructor = await _instructorManager.CreateInstructorAsync(input.Name, input.Surname, input.UserName, input.Email, input.Password, input.Bio, input.Profession);

            return input;
        }


        [AbpAuthorize]
        public async Task<InstructorProfileDto> GetMyProfileAsync()
        {
            if (!AbpSession.UserId.HasValue)
            {
                throw new UserFriendlyException("User is not logged in.");
            }

            // Find instructor linked to current user
            var instructor = await _instructorRepository
            .GetAll()
            .Include(x => x.UserAccount)
            .FirstOrDefaultAsync(x => x.UserAccount != null && x.UserAccount.Id == AbpSession.UserId.Value);

            if (instructor == null)
            {
                throw new UserFriendlyException("Instructor profile not found.");
            }

            var email = instructor.UserAccount?.EmailAddress;

            return new InstructorProfileDto
            {
                Id = instructor.Id,
                Name = instructor.UserAccount?.Name,
                Surname = instructor.UserAccount?.Surname,
                UserName = instructor.UserAccount?.UserName,
                Email = instructor.UserAccount?.EmailAddress,
                Bio = instructor.Bio,
                Profession = instructor.Profession
            };
        }
        public async Task<InstructorProfileDto> UpdateMyProfileAsync(UpdateInstructorProfileDto input)
        {
            if (!AbpSession.UserId.HasValue)
            {
                throw new UserFriendlyException("User is not logged in.");
            }


            var instructor = await _instructorRepository
            .GetAll()
            .Include(x => x.UserAccount)
            .FirstOrDefaultAsync(x => x.UserAccount != null && x.UserAccount.Id == AbpSession.UserId.Value);

            if (instructor == null)
            {
                throw new UserFriendlyException("Instructor profile not found.");
            }


            instructor.UserAccount.Name = input.Name;
            instructor.UserAccount.Surname = input.Surname;
            instructor.UserAccount.UserName = input.UserName;
            instructor.Bio = input.Bio;
            instructor.Profession = input.Profession;

            // Update email on User entity
            if (!string.IsNullOrWhiteSpace(input.Email) && instructor.UserAccount != null)
            {
                instructor.UserAccount.EmailAddress = input.Email;
                instructor.UserAccount.IsEmailConfirmed = false;
            }

            await _instructorRepository.UpdateAsync(instructor);


            return new InstructorProfileDto
            {
                Id = instructor.Id,
                Name = instructor.UserAccount?.Name,
                Surname = instructor.UserAccount?.Surname,
                UserName = instructor.UserAccount?.UserName,
                Email = instructor.UserAccount?.EmailAddress,
                Bio = instructor.Bio,
                Profession = instructor.Profession
            };
        }

        public async Task<ICollection<CourseDto>> GetCoursesAsync(long userId)
        {
            var instructor = await _instructorRepository
                .GetAllIncluding(i => i.UserAccount, i => i.CoursesCreated)
                .FirstOrDefaultAsync(i => i.UserAccount != null && i.UserAccount.Id == userId);


            var courses = instructor.CoursesCreated;

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
