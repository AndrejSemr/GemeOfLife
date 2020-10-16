
namespace GameOfLife.GameOfLife
{
    /// <summary>
    /// Interface provides the necessary functionality for work with PlaygroundArray.
    /// </summary>
    public interface IPlaygroundArray
    {
        /// <summary>
        /// Array of playgrounds.
        /// </summary>
        public Playground[] PlaygroundArrays { get; set; }

        /// <summary>
        /// Number of elements in PlaygroundArrays.
        /// </summary>
        public int NumberOfArrays { get; set; }

        /// <summary>
        /// Method return number of living playgrounds.
        /// Living playground - Playground where at least 1 playground element 
        /// is equal to 1.
        /// </summary>
        /// <returns> int - Numner of live playground. </returns>
        public int GetNumberOfLivePlaygrounds();

        /// <summary>
        /// Method call one iteration for each Playground.
        /// </summary>
        public void Iteration();
    }
}
