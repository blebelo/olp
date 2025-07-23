using Abp.Application.Services;
using Abp.Domain.Repositories;
using OnlineLearningPlatform.Domain.Quizzes;
using OnlineLearningPlatform.QuizAttempts.Dto;
using System;
using System.Threading.Tasks;

namespace OnlineLearningPlatform.QuizAttempts
{
    public class QuizAttemptAppService: ApplicationService, IQuizAttemptAppService
    {
        private readonly IRepository<QuizAttempt, Guid> _quizAttemptRepository;

        public QuizAttemptAppService(IRepository<QuizAttempt, Guid> quizAttemptRepository)
        {
            _quizAttemptRepository = quizAttemptRepository;
        }
        public Task<QuizAttemptDto> SubmitQuizAsync(QuizSubmissionDto input)
        {
            throw new System.NotImplementedException();
        }
    }
}
