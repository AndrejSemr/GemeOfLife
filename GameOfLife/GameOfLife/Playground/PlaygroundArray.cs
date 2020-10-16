namespace GameOfLife.GameOfLife
{
    using System;

    /// <summary>
    /// Class create an array of playgrounds for Game Of Life.
    /// </summary>
    [Serializable()]
    public class PlaygroundArray : IPlaygroundArray
    {
        /// <summary>
        /// Array of playgrounds.
        /// </summary>
        public Playground[] PlaygroundArrays { get; set; }

        /// <summary>
        /// Number of elements in PlaygroundArrays.
        /// </summary>
        public int NumberOfArrays { get; set; }

        #region Constructors

        /// <summary>
        /// Constructor to create an array of playgrounds.
        /// </summary>
        /// <param name="rows"> Playgrounds array number of rows. </param>
        /// <param name="columns"> Playgrounds array number of columns. </param>
        /// <param name="numberOfArrays"> Number of playgrounds. </param>
        public PlaygroundArray(int rows, int columns,int numberOfArrays)
        {
            NumberOfArrays = numberOfArrays;
            PlaygroundArrays = new Playground[NumberOfArrays];

            for (var index = 0; index < NumberOfArrays; index++)
            {
                PlaygroundArrays[index] = new Playground(rows,columns);
            }
        }

        /// <summary>
        /// Constructor for JSON Serialization/Deserialization.
        /// </summary>
        public PlaygroundArray()
        {
        }

        #endregion

        /// <summary>
        /// Method call one iteration for each Playground.
        /// </summary>
        public void Iteration()
        {
            for (var index = 0; index < NumberOfArrays; index++)
            {
                PlaygroundArrays[index].Iteration();
            }
        }

        /// <summary>
        /// Method return number of living playgrounds.
        /// Living playground - Playground where at least 1 playground element 
        /// is equal to 1.
        /// </summary>
        /// <returns> int - Numner of live playgrounds </returns>
        public int GetNumberOfLivePlaygrounds()
        {
            int numberOfLivingPlaygrounds = 0;

            for (var index = 0; index < NumberOfArrays; index++)
            {

                if(PlaygroundArrays[index].GetNumberOfLivePoints() > 0)
                {
                    numberOfLivingPlaygrounds++;
                }

            }

            return numberOfLivingPlaygrounds;
        }
    }
}