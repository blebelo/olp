using Abp.Application.Services;
using Abp.Domain.Repositories;
using Abp.UI;
using Microsoft.AspNetCore.Identity;
using OnlineLearningPlatform.Authorization.Users;
using OnlineLearningPlatform.Domain.Instructor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineLearningPlatform.Domain.Instructors;

namespace OnlineLearningPlatform.InstructorsApp
{
    public class InstructorAppService: AsyncCrudAppService<Instructor, InstructorDto, Guid>
    {

        private readonly UserManager<User> _userManager;
        private readonly IRepository<Instructor, Guid> _instructorRepository;

        public InstructorAppService(
            UserManager<User> userManager,
            IRepository<Instructor, Guid> instructorRepository) : base(instructorRepository)
        {
            _userManager = userManager;
            _instructorRepository = instructorRepository;
        }


        // Remember to refactor
        public async Task CreateInstructorAsync(InstructorDto input)
        {

            var user = new User
            {
                UserName = input.UserName,
                Name = input.UserName,
                Surname = input.Surname,
                EmailAddress = input.Email
            };



            var result = await _userManager.CreateAsync(user, input.Password);

            if (!result.Succeeded)
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                throw new UserFriendlyException("Failed to create user: " + errors);
            }


            //Assign role
            await _userManager.AddToRoleAsync(user, "Instructor");

            //Create Instructor entity
            var instructor = new Instructor
            {
                User = user,
                Bio = input.Bio
            };

            //Save Instructor
            await _instructorRepository.InsertAsync(instructor);

            //Log success
            Logger.Info($"Instructor {user.UserName} registered successfully with ID {instructor.Id}");
        }
}
    
}
