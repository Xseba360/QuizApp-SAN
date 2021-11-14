namespace QuizApp.Backend
{
    /// <summary>
    /// <ul>
    ///     <li>Equal -> All questions are treated the same</li>
    ///     <li>CategoryMult -> Points are added based on category</li>
    ///     <li>CustomPerCategory -> Reward is based on the custom category points array</li>
    /// </ul>
    /// </summary>
    internal enum QuizPointCountModes
    {
        Equal,
        CategoryMult,
        CustomPerCategory,
    }
}