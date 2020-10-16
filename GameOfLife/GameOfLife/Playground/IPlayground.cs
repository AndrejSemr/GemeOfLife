
namespace GameOfLife
{
    /// <summary>
    /// Interface provides the necessary functionality for work with Playground.
    /// </summary>
    public interface IPlayground
    {
        #region VariableDeclaration

        /// <summary>
        /// Number of playground rows.
        /// </summary>
        public int PlaygroundRows { get; set; }

        /// <summary>
        /// Number of playground comunns.
        /// </summary>
        public int PlaygroundColumns { get; set; }

        /// <summary>
        /// Playground grid.
        /// </summary>
        public int[,] PlaygriundGrid { get; set; }

        /// <summary>
        /// Iteration number.
        /// </summary>
        public int IterationNumber { get; set; }

        #endregion

        /// <summary>
        /// Method return number of 'live' points.
        /// </summary>
        /// <returns> int - Number of live points. </returns>
        public int GetNumberOfLivePoints();

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
