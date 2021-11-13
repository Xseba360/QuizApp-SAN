using System.Diagnostics.CodeAnalysis;

namespace QuizApp.Backend
{
    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
    public class QuizConfigFileModel
    {
        public QuizConfigModel Config { get; set; }
        public QuizQuestionModel[] Questions { get; set; }
    }
}