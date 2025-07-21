using Abp.Application.Services;
using Abp.Application.Services.Dto;
using OnlineLearningPlatform.Quizzes.Dto;
using System;

namespace OnlineLearningPlatform.Quizzes
{
     public interface IQuizAppService: IAsyncCrudAppService<QuizDto, Guid, PagedAndSortedResultRequestDto, CreateQuizDto, QuizDto>
    {
    }
}
