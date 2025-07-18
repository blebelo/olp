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

    }
}
