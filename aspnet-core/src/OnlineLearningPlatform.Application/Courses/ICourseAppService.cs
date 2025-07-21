using Abp.Application.Services;
using Abp.Application.Services.Dto;
using OnlineLearningPlatform.Courses.Dto;
using OnlineLearningPlatform.Instructors.Dto;
using OnlineLearningPlatform.Lessons.Dto;
using OnlineLearningPlatform.Quizzes.Dto;
using System;
using System.Threading.Tasks;

namespace OnlineLearningPlatform.Courses
{
    public interface ICourseAppService
        : IAsyncCrudAppService<CourseDto, Guid, PagedAndSortedResultRequestDto, CreateCourseDto, UpdateCourseDto>
    {
        Task EnrollStudentAsync(Guid courseId, Guid studentId);
        Task UnEnrollStudentAsync(Guid courseId, Guid studentId);
        Task AddLessonAsync(Guid courseId, LessonDto lesson);
        Task RemoveLessonAsync(Guid courseId, Guid lessonId);
        Task AddQuizAsync(Guid courseId, CreateQuizDto quiz);
        Task RemoveQuizAsync(Guid courseId, Guid quizId);
    }
}
