using Abp.Application.Services;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.UI;
using Microsoft.EntityFrameworkCore;
using OnlineLearningPlatform.Authorization.Users;
using OnlineLearningPlatform.Courses.Dto;
using OnlineLearningPlatform.Domain.Instructors;
using OnlineLearningPlatform.EmailService;
using OnlineLearningPlatform.Instructors.Dto;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Threading.Tasks;

namespace OnlineLearningPlatform.Instructors
{
    public class InstructorAppService : AsyncCrudAppService<Instructor, CreateInstructorDto, Guid>
    {
        private readonly IRepository<Instructor, Guid> _instructorRepository;
        private readonly UserManager _userManager;
        private readonly InstructorManager _instructorManager;
        private readonly EmailAdminService _emailAdminService;

        public InstructorAppService(
            IRepository<Instructor, Guid> repository,
            UserManager userManager,
            InstructorManager instructorManager,
             EmailAdminService emailService
            )
            : base(repository)
        {
            _instructorRepository = repository;
            _userManager = userManager;
            _instructorManager = instructorManager;
            _emailAdminService = emailService;
        }

        public override async Task<CreateInstructorDto> CreateAsync(CreateInstructorDto input)
        {

            var createInstructor = await _instructorManager.CreateInstructorAsync(input.Name, input.Surname, input.UserName, input.Email, input.Password, input.Bio, input.Profession);

            // Send welcome email after successful creation
            await SendWelcomeEmailAsync(input.Email, input.Name, "Instructor");

            return input;
        }

        private async Task SendWelcomeEmailAsync(string email, string name, string role)
        {
            var subject = "Welcome to Your Teaching Journey! 🚀";
            var message = $@"Hey {name}! 

            Welcome to the future of education! You've just stepped into a realm where knowledge meets innovation, and teaching transcends traditional boundaries. 

            As an Instructor, you're not just joining a platform – you're becoming part of a revolutionary movement that's reshaping how we share wisdom, inspire minds, and unlock human potential. Get ready to elevate your teaching to dimensions you never imagined possible.

            Your mission to transform lives through learning starts now. Let's create some educational magic together! ✨

            Stay inspired, stay innovative!
            The OLP Team";

            await _emailAdminService.SendEmail(subject, email, name, message);
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

        [AbpAuthorize]
        public async Task<ICollection<CourseDto>> GetCoursesAsync(long userId)
        {
            
            var instructor = await _instructorRepository.GetAll().Include(x => x.UserAccount)
            .FirstOrDefaultAsync(x => x.UserAccount != null && x.UserAccount.Id == userId);

            var courses = instructor.CoursesCreated;

            if (courses == null || courses.Count == 0)
            {
                throw new UserFriendlyException("No courses found for this instructor.");
            }
            var listOfCourses = ObjectMapper.Map<List<CourseDto>>(courses);

            return listOfCourses;
        }
    }

}
