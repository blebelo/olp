using Abp.Application.Services;
using Abp.Domain.Repositories;
using Abp.UI;
using OnlineLearningPlatform.Authorization.Users;
using OnlineLearningPlatform.Domain.Entities;
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

            var createUserResult = await _userManager.CreateAsync(newUser, input.Password);
            if (!createUserResult.Succeeded)
            {
                throw new UserFriendlyException("User creation failed: " + string.Join(", ", createUserResult.Errors));
            }


            /*
             * 
             * HUGE BUG
            //await _userManager.AddToRoleAsync(newUser, "Instructor");
            */
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

            await _instructorRepository.InsertAsync(instructor);

            return input;
        }

    }
}
