using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using OnlineLearningPlatform.Courses.Dto;
using System.Threading.Tasks;
using OnlineLearningPlatform.Lessons.Dto;

namespace OnlineLearningPlatform.Courses
{
    public interface ICourseAppService
        : IAsyncCrudAppService<CourseDto, Guid, PagedAndSortedResultRequestDto, CreateCourseDto, UpdateCourseDto>
    {
        Task EnrollStudentAsync(Guid courseId, string student);
        Task UnEnrollStudentAsync(Guid courseId, string student);
        Task AddLessonAsync(Guid courseId, LessonDto lesson);
        Task RemoveLessonAsync(Guid courseId, Guid lessonId);

    }
}
