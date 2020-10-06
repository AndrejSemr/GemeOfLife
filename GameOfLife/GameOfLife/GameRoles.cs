namespace GameOfLife.GameOfLife
{
    ///
    ///  Class contains the rules of GameOfLife game and necessary methods..
    ///  .. for analyzing the state and make a decision;
    ///
    public class GameRoles
    {
        /// 
        /// Method perform ONE iteration;
        /// As parameters:
        ///    playgroundArray (int[,]) -   Playground array;
        ///    x_size   (int)           -   Playground number of rows;
        ///    y_size   (int)           -   Playground number of cilumns;
        /// Return:
        ///     int[,]  -   new playground array ( after Iteration) 
        ///     
        public int[,] DoGameOfLifeIteration(int[,] playgroundArray, int x_size, int y_size)
        {
            int[,] playgroundArrayAfterIteration = new int[x_size,y_size];

            for (int row = 0; row < x_size; row++)
            {
                for (int column = 0; column < y_size; column++)
                {
                    playgroundArrayAfterIteration[row, column] = CheckTheRules(playgroundArray, row, column, x_size, y_size);
                }
            }

            return playgroundArrayAfterIteration;
        }

        /// 
        /// Method checks calls against game rules;
        /// As parameters:
        ///    playgroundArray (int[,]) -   Playground array;
        ///    x_size   (int)           -   Playground number of rows;
        ///    y_size   (int)           -   Playground number of cilumns;
        ///    x_coord  (int)           -   The state we check now (by rows)
        ///    y_coord  (int)           -   The state we check now (by column)
        /// Return:
        ///     int  -   new status;
        ///     
        private int CheckTheRules(int[,] playgroundArray, int x_coord, int y_coord, int x_size, int y_size)
        {
            int sumOfNeighbors = CheckNeighbors(playgroundArray,  x_coord,  y_coord, x_size, y_size);
            int currentStatus = playgroundArray[x_coord, y_coord];

            if (currentStatus == 0 && sumOfNeighbors == 3) return 1;
            if ((currentStatus == 1) && ((sumOfNeighbors < 2) || (sumOfNeighbors > 3))) return 0;
            return currentStatus;

        }
        /// 
        /// Method return number of neighbors for current state;
        /// As parameters:
        ///    playgroundArray (int[,]) -   Playground array;
        ///    x_coord  (int)           -   The state we check now (by rows)
        ///    y_coord  (int)           -   The state we check now (by column)
        ///    x_size   (int)           -   Playground number of rows;
        ///    y_size   (int)           -   Playground number of cilumns;
        /// Return:
        ///     int  -  number of neighbors;
        ///     
        private int CheckNeighbors(int[,] playgroundArray, int x_coord,int y_coord , int x_size, int y_size)
        {
            int sumOfNeighbors = 0;
            int x = 0;
            int y = 0;

            for (int row = -1; row < 2; row++)
            {
                for (int column = -1; column < 2; column++)
                {
                    x = GetModulNumber(x_coord, row, x_size);
                    y = GetModulNumber(y_coord, column, y_size);
                    sumOfNeighbors += playgroundArray[x, y];
                }
            }

            sumOfNeighbors -= playgroundArray[x_coord, y_coord];

            return sumOfNeighbors;
        }
        /// 
        /// Method return modul number to avoid going out of array;
        /// As parameters:
        ///    coord(int)       -   current position;
        ///    loopValue(int)   -   offset/next coordinate to check
        ///    arrayLenght(int) -   array size/lenght/border
        /// Return:
        ///     int  -  modul number;
        /// 
        private int GetModulNumber(int coord, int offset , int arrayLenght)
        {
            return (coord + offset + arrayLenght) % arrayLenght;
        }
    }
}
