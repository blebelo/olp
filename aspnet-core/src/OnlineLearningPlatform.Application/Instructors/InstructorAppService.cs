using Abp.Application.Services;
using Abp.Domain.Repositories;
using Abp.UI;
using OnlineLearningPlatform.Authorization.Users;
using OnlineLearningPlatform.Courses.Dto;
using OnlineLearningPlatform.Domain.Instructors;
using OnlineLearningPlatform.Instructors.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineLearningPlatform.Instructors
{
    public class InstructorAppService : AsyncCrudAppService<Instructor, CreateInstructorDto, Guid>, IInstructorAppService
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

        public async Task<ICollection<CourseDto>> GetCoursesAsync(Guid instructorId)
        {
            var instructor = await _instructorRepository.GetAsync(instructorId);
            var courses = instructor.CoursesCreated;

            if (courses == null || courses.Count == 0)
            {
                throw new UserFriendlyException("No courses found for this instructor.");
            }
            var listOfCourses = ObjectMapper.Map<List<CourseDto>>(courses);

            return listOfCourses;
        }
    }
}
