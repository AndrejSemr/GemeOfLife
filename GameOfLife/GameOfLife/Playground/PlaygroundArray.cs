using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife.GameOfLife
{
    [Serializable()]
    public class PlaygroundArray : IPlaygroundArray
    {
        public Playground[] playgroundArray { get; set; }
        public int NumberOfArrays { get; set; }

        public PlaygroundArray(int rows, int comuns,int arrayLength)
        {
            NumberOfArrays = arrayLength;
            playgroundArray = new Playground[NumberOfArrays];

            for (int index = 0; index < NumberOfArrays; index++)
            {
                playgroundArray[index] = new Playground(rows,comuns);
                playgroundArray[index].RandomlyFillArray();
            }
        }

        /// <summary>
        /// Method call one iteration for each Playground;
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