using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife.GameOfLife
{
    /// <summary>
    /// Interface is associated with PlaygroundArray class.
    /// Provides necessary functionality.
    /// </summary>
    public interface IPlaygroundArray
    {
        public Playground[] playgroundArray { get; set; }
        public int NumberOfArrays { get; set; }

        /// <summary>
        /// Method return number of living playgrounds.
        /// Living playground - Playground where at least 1 playground element 
        /// is equal to 1.
        /// </summary>
        /// <returns> int - Numner of living playground. </returns>
        public int GetNumberOfLivingPlaygrounds();

        /// <summary>
        /// Method call one iteration for each Playground.
        /// </summary>
        public void Iteration();
    }
}
