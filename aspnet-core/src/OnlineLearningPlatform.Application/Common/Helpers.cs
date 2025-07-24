using Abp.Domain.Repositories;
using OnlineLearningPlatform.Domain.Quizzes;
using OnlineLearningPlatform.Domain.Results;
using OnlineLearningPlatform.QuizAttempts.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineLearningPlatform.Common
{
    public class Helpers
    {
        public static async Task<Result> GradeQuiz(QuizAttemptDto submission, IRepository<Quiz, Guid> quizRepo)
        {
            var quiz = await quizRepo.GetAsync(submission.QuizId);

            var result = new Result
            {
                Score = 0,
                CorrectAnswers = new List<string>(),
                IncorrectAnswers = new List<string>()
            };

            if (submission.StudentAnswers == null || quiz.AnswerOptions == null)
            {
                return result;
            }

            var studentAnswersList = new List<string>(submission.StudentAnswers);
            var quizAnswersList = new List<AnswerOption>(quiz.AnswerOptions);

            for (int i = 0; i < Math.Min(studentAnswersList.Count, quizAnswersList.Count); i++)
            {
                var studentAnswer = studentAnswersList[i];
                var correctAnswer = quizAnswersList[i].CorrectAnswer;

                if (string.Equals(studentAnswer, correctAnswer, StringComparison.OrdinalIgnoreCase))
                {
                    result.Score++;
                    result.CorrectAnswers.Add(studentAnswer);
                }
                else
                {
                    result.IncorrectAnswers.Add(studentAnswer);
                }
            }

            return result;
        }
    }
}