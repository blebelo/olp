using Abp.Application.Services;
using Abp.Domain.Repositories;
using Abp.UI;
using OnlineLearningPlatform.Common;
using OnlineLearningPlatform.Domain.Quizzes;
using OnlineLearningPlatform.Domain.StudentProgresses;
using OnlineLearningPlatform.Domain.Students;
using OnlineLearningPlatform.QuizAttempts.Dto;
using System;
using System.Threading.Tasks;

namespace OnlineLearningPlatform.QuizAttempts
{
    public class QuizAttemptAppService: ApplicationService, IQuizAttemptAppService
    {
        private readonly IRepository<QuizAttempt, Guid> _quizAttemptRepository;
        private readonly IRepository<Quiz, Guid> _quizRepository;
        private readonly IRepository<Student, Guid> _studentRepository;
        private readonly IRepository<StudentProgress, Guid> _progressRepository;

        public QuizAttemptAppService(
            IRepository<QuizAttempt, Guid> quizAttemptRepository,
            IRepository<Quiz, Guid> quizRepository,
            IRepository<Student, Guid> studentRepository,
            IRepository<StudentProgress, Guid> progressRepository
            )
        {
            _quizAttemptRepository = quizAttemptRepository;
            _quizRepository = quizRepository;
            _studentRepository = studentRepository;
            _progressRepository = progressRepository;

        }
        public async Task<QuizAttemptDto> SubmitQuizAsync(QuizAttemptDto quizAttempt)
        {
            try
            {
                if (quizAttempt == null)
                {
                    throw new ArgumentNullException(nameof(quizAttempt), "Quiz attempt cannot be null.");
                }

                var results = await Helpers.GradeQuiz(quizAttempt, _quizRepository);
                var newQuizAttempt = ObjectMapper.Map<QuizAttempt>(quizAttempt);
                await _quizAttemptRepository.InsertAsync(newQuizAttempt);
                return ObjectMapper.Map<QuizAttemptDto>(newQuizAttempt);
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException("An error occurred while submitting the quiz attempt. Please try again.", ex);
            }

        }
    }
}
