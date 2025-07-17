using Abp.Domain.Repositories;
using Abp.UI;
using Microsoft.Extensions.Logging;
using OnlineLearningPlatform.Authorization.Users;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineLearningPlatform.Domain.Entities
{
    public class InstructorManager
    {
        private readonly IRepository<Instructor, Guid> _instructorRepository;
        private readonly UserManager _userManager;
        private readonly ILogger<InstructorManager> _logger;

        public InstructorManager(
            IRepository<Instructor, Guid> instructorRepository,
            UserManager userManager,
            ILogger<InstructorManager> logger)
        {
            _instructorRepository = instructorRepository;
            _userManager = userManager;
            _logger = logger;
        }

        public async Task<Instructor> CreateInstructorAsync(
            string userName,
            string name,
            string surname,
            string email,
            string password,
            string bio,
            string profession)
        {
            _logger.LogInformation("Creating instructor with username: {UserName}", userName);

            var newUser = new User
            {
                UserName = userName,
                Name = name,
                Surname = surname,
                EmailAddress = email,
                IsActive = true,
                IsEmailConfirmed = true,
            };
            newUser.SetNormalizedNames();

            // Create the user
            var createUserResult = await _userManager.CreateAsync(newUser, password);
            if (!createUserResult.Succeeded)
            {
                var errorMsg = string.Join(", ", createUserResult.Errors.Select(e => e.Description));
                throw new UserFriendlyException("User creation failed: " + errorMsg);
            }

            // Assign the Instructor role
            var roleResult = await _userManager.AddToRoleAsync(newUser, "Instructor");
            if (!roleResult.Succeeded)
            {
                var errorMsg = string.Join(", ", roleResult.Errors.Select(e => e.Description));
                throw new UserFriendlyException("Role assignment failed: " + errorMsg);
            }

            // Check if instructor already exists for new user
            var existingInstructor = await _instructorRepository.FirstOrDefaultAsync(
                x => x.UserAccount != null && x.UserAccount.Id == newUser.Id
            );
            if (existingInstructor != null)
            {
                throw new UserFriendlyException("An instructor record already exists for this user.");
            }

            var instructor = new Instructor
            {
                Name = name,
                Surname = surname,
                Bio = bio,
                Profession = profession,
                UserAccount = newUser
            };

            await _instructorRepository.InsertAsync(instructor);

            return instructor;
        }
    }
}