using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Abp.UI;
using Microsoft.AspNetCore.Identity;
using OnlineLearningPlatform.Authorization.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLearningPlatform.Domain.Instructors
{
    public class InstructorManager: DomainService
    {
        private readonly IRepository<Instructor, Guid> _instructorRepository;
        private readonly UserManager _userManager;

        public InstructorManager(UserManager userManager, IRepository<Instructor, Guid> instructorRepository)
        {
            _userManager = userManager;
            _instructorRepository = instructorRepository;
        }

        public async Task<Instructor> CreateInstructorAsync(
                string name,
                string surname,
                string username,
                string email,
                string password,
                string bio,
                string profession
            )
        {
            var user = new User
            {
                Name = name,
                Surname = surname,
                UserName = username,
                EmailAddress = email
            };

            var userCreationResult = await _userManager.CreateAsync(user, password);

            if (!userCreationResult.Succeeded)
            {
                throw new UserFriendlyException($"User creation failed");
            }

            await _userManager.AddToRoleAsync(user, "Instructor");

            Instructor instructor = new Instructor
            {
                Bio = bio,
                Profession = profession,
                UserAccount = user
            };

            await _instructorRepository.InsertAsync(instructor);

            return instructor;
        }
    }
}
