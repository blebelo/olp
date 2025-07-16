using Abp.Application.Services;
using Abp.Domain.Repositories;
using Abp.UI;
using Microsoft.Extensions.Logging;
using OnlineLearningPlatform.Authorization.Roles;
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
        private readonly RoleManager _roleManager;
        private readonly ILogger<InstructorAppService> _logger;
        private readonly InstructorManager _instructorManager;

        public InstructorAppService(
            IRepository<Instructor, Guid> repository,
            IRepository<User, long> userRepository,
            UserManager userManager,
            RoleManager roleManager,
            ILogger<InstructorAppService> logger,
            InstructorManager instructorManager
            )
            : base(repository)
        {
            _instructorRepository = repository;
            _userManager = userManager;
            _userRepository = userRepository;
            _roleManager = roleManager;
            _logger = logger;
            _instructorManager = instructorManager;
        }

        public override async Task<CreateInstructorDto> CreateAsync(CreateInstructorDto input)
        {

            return input;
        }
    }
}