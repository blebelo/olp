using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.UI;
using Microsoft.EntityFrameworkCore;
using OnlineLearningPlatform.Courses.Dto;
using OnlineLearningPlatform.Domain.Courses;
using OnlineLearningPlatform.Domain.Entities;
using OnlineLearningPlatform.Domain.Instructors;
using OnlineLearningPlatform.Domain.Quizzes;
using OnlineLearningPlatform.Domain.StudentProgresses;
using OnlineLearningPlatform.Domain.Students;
using OnlineLearningPlatform.Instructors.Dto;
using OnlineLearningPlatform.Lessons.Dto;
using OnlineLearningPlatform.Quizzes.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineLearningPlatform.Courses
{
    public class CourseAppService
        : AsyncCrudAppService<Course, CourseDto, Guid, PagedAndSortedResultRequestDto, CreateCourseDto, UpdateCourseDto>,
          ICourseAppService
    {
        private readonly IRepository<Quiz, Guid> _quizRepository;
        private readonly IRepository<Course, Guid> _courseRepository;
        private readonly IRepository<Student, Guid> _studentRepository;
        private readonly IRepository<Instructor, Guid> _instructorRepository;
        private readonly IRepository<StudentProgress, Guid> _progressRepository;

        public CourseAppService(
            IRepository<StudentProgress, Guid> progressRepository,
            IRepository<Quiz, Guid> quizRepository,
            IRepository<Course, Guid> repository,
            IRepository<Student, Guid> students,
            IRepository<Instructor, Guid> instructorRepository
            )
            : base(repository)
        {
            _quizRepository = quizRepository;
            _courseRepository = repository;
            _studentRepository = students;
            _instructorRepository = instructorRepository;
            _progressRepository = progressRepository;
        }

        public override async Task<CourseDto> CreateAsync(CreateCourseDto input)
        {
            Instructor instructor = await _instructorRepository.GetAsync(input.InstructorId);

            var course = ObjectMapper.Map<Course>(input);
            course.Instructor = instructor;
            course.EnrolledStudents = new List<Student>();
            course.Lessons = new List<Lesson>();

            await _courseRepository.InsertAsync(course);
            return ObjectMapper.Map<CourseDto>(course);
        }

        public override async Task<CourseDto> GetAsync(EntityDto<Guid> input)
        {
            var course = await _courseRepository.GetAsync(input.Id);
            return ObjectMapper.Map<CourseDto>(course);
        }

        public override async Task<PagedResultDto<CourseDto>> GetAllAsync(PagedAndSortedResultRequestDto input)
        {
            var totalCount = await _courseRepository.CountAsync();
            var items = await _courseRepository.GetAllListAsync();

            return new PagedResultDto<CourseDto>(
                totalCount,
                ObjectMapper.Map<List<CourseDto>>(items)
            );
        }

        public override async Task<CourseDto> UpdateAsync(UpdateCourseDto input)
        {
            var course = await _courseRepository.GetAsync(input.Id);
            course.Title = input.Title;
            course.Topic = input.Topic;
            course.Description = input.Description;

            await _courseRepository.UpdateAsync(course);
            return ObjectMapper.Map<CourseDto>(course);
        }

        public async Task EnrollStudentAsync(Guid courseId, Guid studentId)
        {
            var course = await _courseRepository.GetAsync(courseId);
            var student = await _studentRepository.GetAsync(studentId);
            var existingProgress = await _progressRepository.FirstOrDefaultAsync(sp => sp.StudentId == studentId && sp.CourseId == courseId);

            if (existingProgress != null)
            {
                throw new UserFriendlyException("Student is already enrolled in this course");
            }

            try 
            {
                course.EnrolledStudents.Add(student);
                student.EnrolledCourses.Add(course);
                var initialProgress = new StudentProgress
                {
                    StudentId = studentId,
                    CourseId = courseId,
                    IsCompleted = false,
                    CompletionPercentage = 0,
                    CompletedLessonIds = new List<Guid>(),
                    CompletedQuizIds = new List<Guid>()
                };

                await _courseRepository.UpdateAsync(course);
                await _studentRepository.UpdateAsync(student);  
                await _progressRepository.InsertAsync(initialProgress);
            } 
            catch (Exception ex) {
                throw new UserFriendlyException("Could Not Enroll Student", ex.Message);
            }
        }

        public async Task UnEnrollStudentAsync(Guid courseId, Guid studentId)
        {
            var student = await _studentRepository.GetAsync(studentId);
            var course = await _courseRepository.GetAsync(courseId);
            var progress = await _progressRepository.FirstOrDefaultAsync(
                p => p.StudentId == studentId && p.CourseId == courseId);

            if (progress == null)
            {
                throw new UserFriendlyException("Student is not enrolled in this course");
            }

            try
            {
                course.EnrolledStudents.Remove(student);
                student.EnrolledCourses.Remove(course);
                await _courseRepository.UpdateAsync(course);
                await _studentRepository.UpdateAsync(student);
                await _progressRepository.DeleteAsync(progress.Id);
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException("Could not unenroll student", ex.Message);
            }
        }

        public async Task AddLessonAsync(Guid courseId, LessonDto lessonDto)
        {
            var course = await _courseRepository.GetAsync(courseId);

            var lesson = ObjectMapper.Map<Lesson>(lessonDto);

            if (!course.Lessons.Any(l => l.Title == lesson.Title))
            {
                course.Lessons.Add(lesson);
                await _courseRepository.UpdateAsync(course);
            }
        }

        public async Task RemoveLessonAsync(Guid courseId, Guid lessonId)
        {
            var course = await _courseRepository.GetAsync(courseId);
            var lesson = course.Lessons.FirstOrDefault(l => l.Id == lessonId);
            if (lesson != null)
            {
                course.Lessons.Remove(lesson);
                await _courseRepository.UpdateAsync(course);
            }
        }

        public async Task AddQuizAsync(Guid courseId, CreateQuizDto quizDto)
        {
            var course = await _courseRepository.GetAsync(courseId);
            var quiz = ObjectMapper.Map<Quiz>(quizDto);
            quiz.CourseId = courseId;

            if (course.Quiz == null)
            {
                course.Quiz = quiz;
                await _quizRepository.InsertAsync(ObjectMapper.Map<Quiz>(quizDto));
                await _courseRepository.UpdateAsync(course);
            }
            else
            {
                throw new UserFriendlyException("This course already has a quiz.");
            }
        }

        public async Task RemoveQuizAsync(Guid courseId, Guid quizId)
        {
            var course = await _courseRepository.GetAsync(courseId);
            if (course.Quiz != null && course.Quiz.Id == quizId)
            {
                course.Quiz = null;
                _quizRepository.Delete(quizId);
                await _courseRepository.UpdateAsync(course);
            }
            else
            {
                throw new UserFriendlyException("The quiz you're trying to remove does not exist for this course.");
            }
        }
    }
}
