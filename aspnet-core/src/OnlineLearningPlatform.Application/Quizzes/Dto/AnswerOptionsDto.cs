using System.Collections.Generic;

namespace OnlineLearningPlatform.Quizzes.Dto
{
    public class AnswerOptions
    {
        public int QuestionIndex { get; set; }
        public ICollection<string> Options { get; set; }
    }
}
