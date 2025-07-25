﻿using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using Abp.UI;
using OnlineLearningPlatform.Domain.Courses;
using OnlineLearningPlatform.Domain.Quizzes;
using OnlineLearningPlatform.Quizzes.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineLearningPlatform.Quizzes
{
    public class QuizAppService
        : AsyncCrudAppService<Quiz, QuizDto, Guid, PagedAndSortedResultRequestDto, CreateQuizDto, QuizDto>,
          IQuizAppService
    {
        private readonly IRepository<Quiz, Guid> _quizRepository;

        public QuizAppService(IRepository<Quiz, Guid> quizRepository, IRepository<Course, Guid> courseRepository)
            : base(quizRepository)
        {
            _quizRepository = quizRepository;
        }


        public override async Task<QuizDto> GetAsync(EntityDto<Guid> input)
        {
            try
            {
                var quiz = await _quizRepository.GetAsync(input.Id);
                if (quiz == null)
                    throw new EntityNotFoundException(typeof(Quiz), input.Id);

                return ObjectMapper.Map<QuizDto>(quiz);
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException("Error retrieving quiz. Please try again later.", ex);
            }
        }

        public override async Task<PagedResultDto<QuizDto>> GetAllAsync(PagedAndSortedResultRequestDto input)
        {
            try
            {
                var totalCount = await _quizRepository.CountAsync();
                var items = await _quizRepository.GetAllListAsync();

                return new PagedResultDto<QuizDto>(
                    totalCount,
                    ObjectMapper.Map<List<QuizDto>>(items)
                );
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException("Error retrieving quizzes list. Please try again later.", ex);
            }
        }

        public override async Task<QuizDto> UpdateAsync(QuizDto input)
        {
            try
            {
                var quiz = await _quizRepository.GetAsync(input.Id);

                if (quiz == null)
                    throw new EntityNotFoundException(typeof(Quiz), input.Id);

                quiz.Name = input.Name;
                quiz.Description = input.Description;
                quiz.Duration = input.Duration;
                quiz.PassingScore = input.PassingScore;
                quiz.AnswerOptions = ObjectMapper.Map<List<AnswerOption>>(input.AnswerOptions);
                quiz.Questions = input.Questions;

                await _quizRepository.UpdateAsync(quiz);

                return ObjectMapper.Map<QuizDto>(quiz);
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException("Error updating quiz. Please try again later.", ex);
            }
        }
    }
}
