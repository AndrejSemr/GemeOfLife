
namespace GameOfLife.GameOfLife
{
    using System;
    using System.Linq;

    /// <summary>
    /// Class simulates the playground.
    /// </summary>
    [Serializable()]
    public class Playground : IPlayground
    {
        #region VariableDeclaration

        public IGameRoles arrayChecker;
        public int PlaygroundRows { get; set; }
        public int PlaygroundColumns { get; set; }
        public int[,] PlaygriundGrid { get; set; }
        public int IterationNumber { get; set; }

        #endregion
        /// <summary>
        /// Constructor for JSON Serialization/Deserialization.
        /// </summary>
        public Playground()
        {
            arrayChecker = new GameRoles();
        }

        #region Constructors
        /// <summary>
        /// Constructor creates a playground based on ready array and iteration number.
        /// </summary>
        /// <param name="array"> Ready array for Playground array. </param>
        /// <param name="ireration"> Iteration number. </param>
        public Playground(int [,] array, int ireration)
        {
            PlaygriundGrid = array;
            PlaygroundRows = array.GetLength(0);
            PlaygroundColumns = array.GetLength(1);
            IterationNumber = ireration;
            arrayChecker = new GameRoles();
        }

        /// <summary>
        /// Constructor creates a playground based on rows and cilumns.
        /// </summary>
        /// <param name="rows">Number of rows in new Playground.</param>
        /// <param name="columns">Number of rows in new Playground.</param>
        public Playground(int rows, int columns)
        {
            if (rows <= 1 || columns <= 1) 
                throw new ArgumentOutOfRangeException("Row and Column size must be greater than 0");

            PlaygroundRows = rows;
            PlaygroundColumns = columns;
            PlaygriundGrid = new int[PlaygroundRows, PlaygroundColumns];
            IterationNumber = 0;
            arrayChecker = new GameRoles();
            RandomlyFillArray();
        }
        #endregion

        /// <summary>
        /// Method calls one iteration and increases iteration counter.
        /// </summary>
        public void Iteration()
        {
            PlaygriundGrid = arrayChecker.DoGameOfLifeIteration(PlaygriundGrid, PlaygroundRows, PlaygroundColumns);
            IterationNumber++;
        }

        /// <summary>
        ///  Method randomly fills playgrounds array with 1 (life) or 0 (free) values.
        /// </summary>
        private void RandomlyFillArray()
        {
            Random random = new Random();

            for (int i = 0; i < PlaygroundRows; i++)
            {

                for (int j = 0; j < PlaygroundColumns; j++)
                {
                    PlaygriundGrid[i, j] = random.Next(0, 2);
                }

            }
        }

        /// <summary>
        /// Method return number of 'live' points.
        /// </summary>
        /// <returns> int - Number of live points. </returns>
        public int GetNumberOfLivePoints()
        {
            int sum = PlaygriundGrid.Cast<int>().Sum();
            return sum;
        }

        /// <summary>
        /// Metnod return number of iteration.
        /// </summary>
        /// <returns> int - Iteration number. </returns>
        public int GetNumberOfIteration()
        {
            return IterationNumber;
        }

        /// <summary>
        /// Method return playground as an array of numbers.
        /// </summary>
        /// <returns> int[,] - Playground array as array of int. </returns>
        public int[,] GetPlaygroundArray()
        {
            return PlaygriundGrid;
        }

    }
}
