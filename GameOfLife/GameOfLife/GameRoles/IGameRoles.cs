namespace GameOfLife.GameOfLife
{
    /// <summary>
    /// Interface provides the necessary functionality for work with GameRoles.
    /// </summary>
    public interface IGameRoles
    {
        /// <summary>
        /// Method perform one 'Game of Life' iteration.
        /// </summary>
        /// <param name="playgroundArray"> Playground array as array of Int. </param>
        /// <param name="x_size"> Playground number of rows. </param>
        /// <param name="y_size"> Playground number of cilumns. </param>
        /// <returns>   int[,] - New array for Playground (after Iteration). </returns>
        public int[,] DoGameOfLifeIteration(int[,] playgroundArray, int x_size, int y_size);
    }
}
