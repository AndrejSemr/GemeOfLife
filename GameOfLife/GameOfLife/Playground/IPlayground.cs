
namespace GameOfLife
{
    /// <summary>
    /// Interface provides the necessary functionality for work with Playground.
    /// </summary>
    public interface IPlayground
    {
        #region VariableDeclaration

        public int PlaygroundRows { get; set; }
        public int PlaygroundColumns{get; set; }
        public int[,] PlaygriundGrid { get; set; }
        public int IterationNumber { get; set; }

        #endregion

        /// <summary>
        /// Method return number of 'live' points.
        /// </summary>
        /// <returns> int - Number of live points. </returns>
        public int GetNumberOfLivePoints();

        /// <summary>
        /// Metnod return number of iteration.
        /// </summary>
        /// <returns> int - Iteration number. </returns>
        public int GetNumberOfIteration();

        /// <summary>
        /// Method return playground as an array of numbers.
        /// </summary>
        /// <returns> int[,] - Playground array as array of int. </returns>
        public int[,] GetPlaygroundArray();

        /// <summary>
        /// Method calls one iteration and increases iteration counter.
        /// </summary>
        public void Iteration();
    }
}
