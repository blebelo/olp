using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Microsoft.Extensions.Logging;
using OnlineLearningPlatform.Authorization.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLearningPlatform.Domain.Entities
{
    public class InstructorManager: DomainService
    {
        private readonly IRepository<User, long> _userRepository;
        private readonly IRepository<Instructor, Guid> _instructorRepository;
        private readonly UserManager _userManager;

        public InstructorManager(
            IRepository<Instructor, Guid> repository,
            IRepository<User, long> userRepository,
            UserManager userManager
            )
        {
            _instructorRepository = repository;
            _userManager = userManager;
            _userRepository = userRepository;
        }

        public async Task<Instructor> CreateInstructorAsync(string username, string name, string surname, string email, string password, string bio, string profession)
        {
            var newUser = new User
            {
                UserName = username,
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
                throw new Abp.UI.UserFriendlyException("Failed to create user: " + errorMsg);
            }
            // Create the instructor
            var instructor = new Instructor
            {
                UserAccount = newUser,
                Bio = bio,
                Profession = profession
            };
            return await _instructorRepository.InsertAsync(instructor);
        }
    }
}
