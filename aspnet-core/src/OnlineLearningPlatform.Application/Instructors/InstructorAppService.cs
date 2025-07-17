using Abp.Application.Services;

using Abp.Domain.Repositories;
using Abp.UI;
using Microsoft.Extensions.Logging;
using OnlineLearningPlatform.Authorization.Roles;
using OnlineLearningPlatform.Authorization.Users;
using OnlineLearningPlatform.Domain.Entities;
using OnlineLearningPlatform.Instructors.Dto;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineLearningPlatform.Instructors
{
    public class InstructorAppService : AsyncCrudAppService<Instructor, CreateInstructorDto, Guid>
    {

        private readonly IRepository<Instructor, Guid> _instructorRepository;
        private readonly UserManager _userManager;
        private readonly ILogger<InstructorAppService> _logger;

        public InstructorAppService(
            IRepository<Instructor, Guid> repository,
            IRepository<User, long> userRepository,
            UserManager userManager,
            RoleManager roleManager,
            ILogger<InstructorAppService> logger
            )
            : base(repository)
        {
            _instructorRepository = repository;
            _userManager = userManager;
            _logger = logger;
        }

        public override async Task<CreateInstructorDto> CreateAsync(CreateInstructorDto input)
        {
            _logger.LogInformation("Starting instructor creation for username: {UserName}", input.UserName);

            var newUser = new User
            {
                UserName = input.UserName,
                Name = input.Name,
                Surname = input.Surname,
                EmailAddress = input.Email,
                IsActive = true,
                IsEmailConfirmed = true,
            };
            newUser.SetNormalizedNames();


            //Create the user
            var createUserResult = await _userManager.CreateAsync(newUser, input.Password);
            if (!createUserResult.Succeeded)
            {
                var errorMsg = string.Join(", ", createUserResult.Errors.Select(e => e.Description));

                throw new UserFriendlyException("User creation failed: " + errorMsg);
            }

            //var createUserResult = await _instructorManager.CreateInstructorAsync(input.UserName, input.Name, input.Surname, input.Email, input.Password, input.Bio, input.Profession);





            // Assign the Instructor role
            var roleResult = await _userManager.AddToRoleAsync(newUser, "Instructor");
            if (!roleResult.Succeeded)
            {
                var errorMsg = string.Join(", ", roleResult.Errors.Select(e => e.Description));
                throw new UserFriendlyException("Role assignment failed: " + errorMsg);
            }






            // Check if instructor already exists for new user
            var existingInstructor = await _instructorRepository.FirstOrDefaultAsync(x => x.UserAccount != null && x.UserAccount.Id == newUser.Id);
            if (existingInstructor != null)
            {
                throw new UserFriendlyException("An instructor record already exists for this user.");
            }

            var instructor = new Instructor
            {
                Name = input.Name,
                Surname = input.Surname,
                Bio = input.Bio,
                Profession = input.Profession,
                UserAccount = newUser
            };

            await _instructorRepository.InsertAsync(instructor);



            return input;
        }
    }
}