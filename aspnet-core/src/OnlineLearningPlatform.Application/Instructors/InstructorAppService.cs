using Abp.Application.Services;
using Abp.Domain.Repositories;
using Abp.UI;
using OnlineLearningPlatform.Authorization.Users;
using OnlineLearningPlatform.Domain.Instructors;
using OnlineLearningPlatform.Instructors.Dto;
using System;
using System.Threading.Tasks;

namespace OnlineLearningPlatform.Instructors
{
    public class InstructorAppService : AsyncCrudAppService<Instructor, CreateInstructorDto, Guid>
    {
        private readonly IRepository<Instructor, Guid> _instructorRepository;
        private readonly UserManager _userManager;
        public InstructorAppService(
            IRepository<Instructor, Guid> repository,
            UserManager userManager
            )
            : base(repository)
        {
            _instructorRepository = repository;
            _userManager = userManager;
        }

        public override async Task<CreateInstructorDto> CreateAsync(CreateInstructorDto input)
        {
            var newUser = new User
            {
                UserName = input.UserName,
                Name = input.Name,
                Surname = input.Surname,
                EmailAddress = input.Email,
                IsActive = true
            };
            Logger.Info($"Creating new user: {newUser.UserName} with email: {newUser.EmailAddress}");

            var createUserResult = await _userManager.CreateAsync(newUser, input.Password);
            if (!createUserResult.Succeeded)
            {
                Logger.Error($"Failed to create user: {newUser.UserName}. Errors: {string.Join(", ", createUserResult.Errors)}");
                throw new UserFriendlyException("User creation failed: " + string.Join(", ", createUserResult.Errors));
            }

            Logger.Info($"User created successfully: {newUser.UserName}");
            var instructor = new Instructor
            {
                Name = input.Name,
                Surname = input.Surname,
                UserName = input.UserName,
                Email = input.Email,
                Password = input.Password,
                Bio = input.Bio,
                Profession = input.Profession,
                UserAccount = newUser
            };
            Logger.Info($"Creating instructor: {instructor.Name} {instructor.Surname} with profession: {instructor.Profession}");

            await _instructorRepository.InsertAsync(instructor);
            Logger.Info($"Instructor created successfully: {instructor.Name} {instructor.Surname}");

            return input;
        }

    }
}
