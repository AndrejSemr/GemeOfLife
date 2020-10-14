using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife.GameOfLife
{
    /// <summary>
    /// Class create an array of playgrounds for Game Of Life.
    /// </summary>
    [Serializable()]
    public class PlaygroundArray : IPlaygroundArray
    {
        public Playground[] playgroundArray { get; set; }
        public int NumberOfArrays { get; set; }

        /// <summary>
        /// Constructor to create an array of playgrounds.
        /// </summary>
        /// <param name="rows"> Playgrounds array number of rows. </param>
        /// <param name="columns"> Playgrounds array number of columns. </param>
        /// <param name="numberOfArrays"> Number of playgrounds. </param>
        public PlaygroundArray(int rows, int columns,int numberOfArrays)
        {
            NumberOfArrays = numberOfArrays;
            playgroundArray = new Playground[NumberOfArrays];

            for (int index = 0; index < NumberOfArrays; index++)
            {
                playgroundArray[index] = new Playground(rows,columns);
                playgroundArray[index].RandomlyFillArray();
            }
        }

        /// <summary>
        /// Method call one iteration for each Playground.
        /// </summary>
        public void Iteration()
        {
            for (int index = 0; index < NumberOfArrays; index++)
            {
                playgroundArray[index].Iteration();
            }
        }

        /// <summary>
        /// Method return number of living playgrounds.
        /// Living playground - Playground where at least 1 playground element 
        /// is equal to 1.
        /// </summary>
        /// <returns> int - Numner of living playground </returns>
        public int GetNumberOfLivingPlaygrounds()
        {
            int numberOfLivingPlaygrounds = 0;

            for (int index = 0; index < NumberOfArrays; index++)
            {

                if(playgroundArray[index].GetNumberOfLivePoints() > 0)
                {
                    numberOfLivingPlaygrounds++;
                }

            }

            return numberOfLivingPlaygrounds;
        }
    }
}