using System;
using System.IO;
using System.Text.Json;
using QuizApp.Backend;

namespace QuizApp.Cli
{
    public class QuizManagerCli
    {
        private readonly bool _endOnFirstFailure;
        private readonly int _maxQuestionsAsked;
        private readonly int _maxQuestionsPerCategory;
        private readonly QuizPointCountModes _quizPointCountModes = QuizPointCountModes.Equal;
        private readonly int[] _rewardPerCategory = Array.Empty<int>();
        private readonly QuizCategory[] _questions;

        private int _currentPoints;
        private int _currentQuestionAnswered;
        private int _currentQuestionAnsweredThisCategory;
        public QuizManagerCli()
        {
            const string fileName = "questions.json";
            var jsonString = File.ReadAllText(fileName);
            var configFile = JsonSerializer.Deserialize<QuizConfigFileModel>(jsonString);
            if (configFile == null) return;
            if (configFile.Config.MaxQuestionsAsked > 0)
            {
                _maxQuestionsAsked = configFile.Config.MaxQuestionsAsked;
            }
            if (configFile.Config.MaxQuestionsPerCategory > 0)
            {
                _maxQuestionsPerCategory = configFile.Config.MaxQuestionsPerCategory;
            }
            _rewardPerCategory = configFile.Config.RewardPerCategory;
            _endOnFirstFailure = configFile.Config.EndOnFirstFailure;
            _quizPointCountModes = (QuizPointCountModes)configFile.Config.PointCountMode;
            _questions = Array.Empty<QuizCategory>();
            foreach (var question in configFile.Questions)
            {
                if (_questions.Length < question.Category + 1)
                {
                    Array.Resize(ref _questions, question.Category+1);
                }
                _questions[question.Category] ??= new QuizCategory();
                _questions[question.Category].AddQuestion(question);
            }
        }
        public void BeginQuiz(int category)
        {
            if (_questions[category] == null)
            {
                Console.WriteLine("Quiz category does not exist!");
                return;
            }

            _currentPoints = 0;
            _currentQuestionAnswered = 0;
            _currentQuestionAnsweredThisCategory = 0;
            while (true)
            {

                Console.WriteLine($"Points: {_currentPoints}");
                if (_maxQuestionsAsked > 0)
                {
                    if (_currentQuestionAnswered >= _maxQuestionsAsked)
                    {
                        return;
                    }
                }
                if (_maxQuestionsPerCategory > 0)
                {
                    if (_currentQuestionAnsweredThisCategory >= _maxQuestionsPerCategory)
                    {
                        category++;
                        _currentQuestionAnsweredThisCategory = 0;
                    }
                }
                var question = _questions[category].GetRandomQuestion();

                if (question == null)
                {
                    category++;
                    _currentQuestionAnsweredThisCategory = 0;

                    if (_questions.Length <= category)
                    {
                        return;
                    }
                    Console.WriteLine(category);
                    question = _questions[category].GetRandomQuestion();
                    if (question == null)
                    {
                        return;
                    }
                }
                _currentQuestionAnswered++;
                _currentQuestionAnsweredThisCategory++;
                if (AskQuestion(question))
                {
                    switch (_quizPointCountModes)
                    {
                        case QuizPointCountModes.Equal:
                            _currentPoints++;
                            break;
                        case QuizPointCountModes.CategoryMult:
                            _currentPoints += category + 1;
                            break;
                        case QuizPointCountModes.CustomPerCategory:
                            _currentPoints += _rewardPerCategory[category];
                            break;
                        default:
                            _currentPoints++;
                            break;
                    }
                    
                }
                else
                {
                    if (!_endOnFirstFailure) continue;
                    Console.WriteLine("You lost!");
                    return;
                }
            }
        }


        private static bool AskQuestion(QuizQuestion question)
        {
            
            Console.WriteLine(question.Question);
            for (byte i = 0; i < question.Answers.Length; i++)
            {
                Console.WriteLine($"{i+1} - {question.Answers[question.ArrayIndexToPrintedId[i]]}");
            }
            return ProcessAnswer(question);
            
        }
        
        private static bool ProcessAnswer(QuizQuestion question)
        {
            while (true)
            {
                var s = Console.ReadLine();
                if (s == null) continue;
                try
                {
                    var result = byte.Parse(s);
                    if (result > 0 && result <= question.Answers.Length)
                    {
                        return question.AnswerQuestion(result);
                    }
                }
                catch (Exception)
                {
                    // ignored
                }
            }
        }
    }
}