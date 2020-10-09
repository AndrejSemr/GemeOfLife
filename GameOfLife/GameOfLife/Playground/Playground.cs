
namespace GameOfLife.GameOfLife
{
    using System;
    using System.Linq;

    /// 
    /// Class simulates the playground
    /// 
    [Serializable]
    public class Playground : IPlayground
    {
        IGameRoles arrayChecker = new GameRoles();
        private int _playgroundRows;
        private int _playgroundColumns;
        private int[,] _playground;
        private int _iteration;

        public Playground(int [,] array, int iter)
        {
            _playground = array;
            _playgroundRows = array.GetLength(0);
            _playgroundColumns = array.GetLength(1);
            _iteration = iter;
        }
        public Playground(int rows, int columns)
        {
            if (rows <= 1 || columns <= 1) 
                throw new ArgumentOutOfRangeException("Row and Column size must be greater than 0");
            _playgroundRows = rows;
            _playgroundColumns = columns;
            _playground = new int[_playgroundRows, _playgroundColumns];
            _iteration = 0;
        }

        /// <summary>
        /// 
        ///     Method calls one iteration and increases iteration counter.
        ///     
        /// </summary>
        public void Iteration()
        {
            _playground = arrayChecker.DoGameOfLifeIteration(_playground, _playgroundRows, _playgroundColumns);
            _iteration++;
        }

        /// <summary>
        /// 
        ///     Method randomly fills playgrounds array with 1 or 0 values.
        /// 
        /// </summary>
        public void RandomlyFillArray()
        {
            Random random = new Random();
            for (int i = 0; i < _playgroundRows; i++)
            {
                for (int j = 0; j < _playgroundColumns; j++)
                {
                    _playground[i, j] = random.Next(0, 2);
                }
            }
        }

        /// <summary>
        /// 
        ///     Method return number of 'live' points.
        ///     
        /// </summary>
        /// <returns> 
        ///         int - number of live points 
        /// </returns>
        public int NumberOfLivePoints()
        {
            int sum = _playground.Cast<int>().Sum(); // how dose it work?!
            return sum;
        }

        /// <summary>
        ///     
        ///     Metnod return number of iteration.
        ///     
        /// </summary>
        /// <returns> Number iteration </returns>
        public int NumberOfIteration()
        {
            return _iteration;
        }

        /// <summary>
        /// 
        ///     Method return playground as an array of numbers.
        ///     
        /// </summary>
        /// <returns> 
        ///     int[,]  -   Playground array of numbers;
        /// </returns>
        public int[,] GetPlaygroundArray()
        {
            return _playground;
        }

    }
}
