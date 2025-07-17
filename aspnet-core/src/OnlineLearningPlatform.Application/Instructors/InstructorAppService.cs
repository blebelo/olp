using Abp.Application.Services;
using Abp.Domain.Repositories;
using OnlineLearningPlatform.Domain.Entities;
using OnlineLearningPlatform.Instructors.Dto;
using System;
using System.Threading.Tasks;

namespace OnlineLearningPlatform.Instructors
{
    public class InstructorAppService : AsyncCrudAppService<Instructor, CreateInstructorDto, Guid>
    {
        private readonly InstructorManager _instructorManager;

        public InstructorAppService(
            IRepository<Instructor, Guid> repository,
            InstructorManager instructorManager
            ) : base(repository)
        {
            _instructorManager = instructorManager;
        }

        public override async Task<CreateInstructorDto> CreateAsync(CreateInstructorDto input)
        {
            var instructor = await _instructorManager.CreateInstructorAsync(
                input.UserName,
                input.Name,
                input.Surname,
                input.Email,
                input.Password,
                input.Bio,
                input.Profession);

            // Map the domain entity to the CreateInstructorDto.
            var dto = ObjectMapper.Map<CreateInstructorDto>(instructor);

            return dto;
        }
    }
}