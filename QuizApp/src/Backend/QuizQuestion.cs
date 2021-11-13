using System;
using System.Linq;

namespace QuizApp.Backend
{
    public class QuizQuestion
    {
        public readonly string Question;
        public readonly string[] Answers;
        private readonly byte _correctAnswer;
        private readonly byte[] _printedIdToArrayIndex;
        public readonly byte[] ArrayIndexToPrintedId;

        public QuizQuestion(string question, string[] answers, byte correctAnswer)
        {
            Question = question;
            Answers = answers;
            _correctAnswer = correctAnswer;

            _printedIdToArrayIndex = new byte[Answers.Length];
            ArrayIndexToPrintedId = new byte[Answers.Length];
            var rnd = new Random();
            for (var i = 0; i < Answers.Length; i++)
            {
                _printedIdToArrayIndex[i] = (byte) (i + 1);
            }

            _printedIdToArrayIndex = _printedIdToArrayIndex.OrderBy(_ => rnd.Next()).ToArray();
            for (var i = 0; i < _printedIdToArrayIndex.Length; i++)
            {
                ArrayIndexToPrintedId[_printedIdToArrayIndex[i] - 1] = (byte) i;
            }
        }

        public bool AnswerQuestion(byte answerIndex)
        {
            return answerIndex == _printedIdToArrayIndex[_correctAnswer];
        }
    }
}