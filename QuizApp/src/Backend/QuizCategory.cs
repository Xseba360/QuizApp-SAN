using System;
using System.Collections.Generic;

namespace QuizApp.Backend
{
    public class QuizCategory
    {
        private static readonly Random Random = new Random();
        private readonly List<QuizQuestion> _questions;

        public QuizCategory()
        {
            _questions = new List<QuizQuestion>();
        }

        public void AddQuestion(QuizQuestionModel quizQuestion)
        {
            _questions.Add(new QuizQuestion(quizQuestion.Question, quizQuestion.Answers,
                (byte) quizQuestion.CorrectAnswer));
        }

        public QuizQuestion GetRandomQuestion()
        {
            var index = Random.Next(_questions.Count);
            var question = _questions[index];
            _questions.RemoveAt(index);
            return question;
        }
    }
}