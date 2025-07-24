using Abp.Application.Services;
using OnlineLearningPlatform.QuizAttempts.Dto;
using System.Threading.Tasks;

namespace OnlineLearningPlatform.QuizAttempts
{
    public interface IQuizAttemptAppService: IApplicationService
    {
        public Task<QuizAttemptDto> SubmitQuizAsync(QuizSubmissionDto quizAttempt);
    }
}
