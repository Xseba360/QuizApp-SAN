using System.Diagnostics.CodeAnalysis;

namespace QuizApp.Backend
{
    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
    public class QuizConfigModel
    {
        /// <summary>
        /// If 0 or lower, there is no limit.
        /// If above 0, when this amount is reached, the quiz is over.
        /// </summary>
        public int MaxQuestionsAsked { get; set; } 
        
        /// <summary>
        /// End the quiz on first failure
        /// </summary>
        public bool EndOnFirstFailure { get; set; } 
        
        /// <summary>
        /// If 0 or lower, all questions need to be answered before proceeding to the next category.
        /// If above 0, this amount of questions need to be <b>ANSWERED</b> before proceeding the next category.
        /// </summary>
        public int MaxQuestionsPerCategory { get; set; } 
        
        /// <summary>
        /// <ul>
        ///     <li>0 -> All questions get equal amount of points</li>
        ///     <li>1 -> The question points are multiplied by current category id + 1 <br>For example</br>
        ///         <ul>
        ///             <li>category 0 -> point multiplier = 1</li>
        ///             <li>category 5 -> point multiplier = 6</li>
        ///         </ul>
        ///     </li>
        ///     <li>2 -> The RewardPerCategory</li>
        /// </ul>
        /// </summary>
        /// <seealso cref="QuizPointCountModes"/>
        /// <seealso cref="RewardPerCategory"/>
        public int PointCountMode { get; set; }
        
        /// <summary>
        /// Index is Category ID. Value is Reward that is added to current winnings.<br></br>
        /// For example:<br></br>
        /// Current winnings are 40000<br></br>
        /// We want the total winnings on next question to be 75000 so we write the reward as 35000<br></br>
        /// </summary>
        public int[] RewardPerCategory { get; set; } 
    }
}