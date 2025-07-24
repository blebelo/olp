using Abp.Domain.Repositories;
using OnlineLearningPlatform.Domain.Quizzes;
using OnlineLearningPlatform.Domain.Results;
using OnlineLearningPlatform.QuizAttempts.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineLearningPlatform.Common
{
    public class Helpers
    {
        public static async Task<Result> GradeQuiz(QuizSubmissionDto submission, IRepository<Quiz, Guid> quizRepo)
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

            var studentAnswersList = submission.StudentAnswers.ToList();
            var quizAnswersList = quiz.AnswerOptions.ToList();

            int questionsToGrade = studentAnswersList.Count;

            for (int i = 0; i < questionsToGrade; i++)
            {
                var studentAnswer = studentAnswersList[i];
                var answerOption = quizAnswersList[i];

                var correctAnswer = answerOption.PossibleAnswers.ElementAt(answerOption.CorrectAnswer);

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