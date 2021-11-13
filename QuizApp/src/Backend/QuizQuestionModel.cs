using System.Diagnostics.CodeAnalysis;

namespace QuizApp.Backend
{
    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
    public class QuizQuestionModel
    {
        /// <summary>
        /// The category ID of the question
        /// </summary>
        public int Category { get; set; }
        /// <summary>
        /// Text of the question
        /// </summary>
        public string Question { get; set; }
        /// <summary>
        /// Array of possible answers
        /// </summary>
        public string[] Answers { get; set; }
        /// <summary>
        /// Index of the correct answer from the questions above
        /// </summary>
        public int CorrectAnswer { get; set; }
    }
}