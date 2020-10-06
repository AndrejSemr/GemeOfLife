
namespace GameOfLife.GameOfLife
{
    using System;
    using System.Linq;

    /// 
    /// Class simulates the playground
    /// 
    public class Playground
    {
        GameRoles arrayChecker = new GameRoles();

        private int _playgroundX;
        private int _playgroundY;
        private int[,] _playground;
        public int iteration;

        public Playground(int [,] array, int iter)
        {
            _playground = array;
            _playgroundX = array.GetLength(0);
            _playgroundY = array.GetLength(1);
            iteration = iter;
        }

        public Playground(int x, int y)
        {
            if (x <= 0 || y <= 0) 
                throw new ArgumentOutOfRangeException("Row and Column size must be greater than 0");
            _playgroundX = x;
            _playgroundY = y;
            _playground = new int[_playgroundX, _playgroundY];
            iteration = 0;
        }

        ///
        /// Method calls one iteration;
        /// 
        public void Iteration()
        {
            _playground = arrayChecker.DoGameOfLifeIteration(_playground, _playgroundX, _playgroundY);
        }
        ///
        /// Method drow playground array;
        /// 
        public void Drow()
        {
            for (int i = 0; i < _playgroundX; i++)
            {
                for (int j = 0; j < _playgroundY; j++)
                {
                    if(_playground[i, j] == 0) Console.Write("{0,3}", ".");
                    else Console.Write("{0,3}",_playground[i,j]);
                }
                Console.WriteLine();
            }
        }

        public void RandomlyFillArray()
        {
            Random random = new Random();
            for (int i = 0; i < _playgroundX; i++)
                for (int j = 0; j < _playgroundY; j++)
                    _playground[i,j] = random.Next(0, 2);
        }
        ///
        /// Method return number of 'live' points
        /// Return
        ///     int  -   PNumber of 'live' points
        public int NumberOfLivePoints()
        {
            int sum = _playground.Cast<int>().Sum(); // how dose it work?!
            return sum;
        }

        ///
        /// Method return playground as an array of numbers 
        /// Return
        ///     int[,]  -   Playground array of numbers;
        public int[,] getPlaygroundArray()
        {
            return _playground;
        }
    }
}
