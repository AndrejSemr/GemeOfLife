using Newtonsoft.Json;
using System;

namespace GameOfLife.GameOfLife
{

    /// <summary>
    /// Class contains the rules of 'Game Of Life' and necessary methods
    /// for state analyz and make a decision.
    /// </summary>

    [Serializable()]
    public class GameRoles : IGameRoles
    {

        /// <summary>
        /// Method perform one 'Game of Life' iteration.
        /// </summary>
        /// <param name="playgroundArray"> Playground array. </param>
        /// <param name="x_size"> Playground number of rows. </param>
        /// <param name="y_size"> Playground number of cilumns. </param>
        /// <returns> int[,] - New array for Playground (after Iteration). </returns>
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

        /// <summary>
        /// Method checks calls against game rules.
        /// </summary>
        /// <param name="playgroundArray">  Playground array as array of Int. </param>
        /// <param name="arraysRowsNumber"> Playground number of rows. </param>
        /// <param name="arraysColumnsNumber"> Playground number of cilumns. </param>
        /// <param name="x_coord"> The state we check now (by rows). </param>
        /// <param name="y_coord"> The state we check now (by column). </param>
        /// <returns> int - new status ( 1 - life , 0 - emptiness ). </returns>
        private int CheckTheRules(int[,] playgroundArray, int x_coord, int y_coord, int arraysRowsNumber, int arraysColumnsNumber)
        {
            int sumOfNeighbors = CheckNeighbors(playgroundArray,  x_coord,  y_coord, arraysRowsNumber, arraysColumnsNumber);
            int currentStatus = playgroundArray[x_coord, y_coord];

            if (currentStatus == 0 && sumOfNeighbors == 3)
            {
                return 1;
            }

            if ((currentStatus == 1) && ((sumOfNeighbors < 2) || (sumOfNeighbors > 3)))
            {
                return 0;
            }
            
            return currentStatus;
        }

        /// <summary>
        /// Method return number of neighbors for current state.
        /// </summary>
        /// <param name="playgroundArray"> Playground array. </param>
        /// <param name="x_coord"> The state we check now (by rows). </param>
        /// <param name="y_coord"> The state we check now (by column). </param>
        /// <param name="arraysRowsNumber"> Playground array number of rows. </param>
        /// <param name="arraysColumnsNumber"> Playground array number of cilumns. </param>
        /// <returns> int - Number of neighbors for current state. </returns>
        private int CheckNeighbors(int[,] playgroundArray, int x_coord,int y_coord , int arraysRowsNumber, int arraysColumnsNumber)
        {
            int sumOfNeighbors = 0;
            int x = 0;
            int y = 0;

            for (int row = -1; row < 2; row++)
            {
                for (int column = -1; column < 2; column++)
                {
                    x = GetModulNumber(x_coord, row, arraysRowsNumber);
                    y = GetModulNumber(y_coord, column, arraysColumnsNumber);
                    sumOfNeighbors += playgroundArray[x, y];
                }
            }

            sumOfNeighbors -= playgroundArray[x_coord, y_coord];

            return sumOfNeighbors;
        }
        
        /// <summary>
        /// Method return modul number to avoid going out of array.
        /// </summary>
        /// <param name="coord"> Current position.</param>
        /// <param name="offset"> Offset/next coordinate to check. </param>
        /// <param name="arrayLenght"> Array size/lenght/border. </param>
        /// <returns> int - Next cell coordinate. </returns>
        private int GetModulNumber(int coord, int offset , int arrayLenght)
        {
            return (coord + offset + arrayLenght) % arrayLenght;
        }
    }
}
