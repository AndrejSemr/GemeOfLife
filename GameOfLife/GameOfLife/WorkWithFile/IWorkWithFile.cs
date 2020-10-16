namespace GameOfLife.GameOfLife
{
    /// <summary>
    /// Interface for working with files sistem.
    /// </summary>
    public interface IWorkWithFile
    {
        /// <summary>
        /// Method save playgrounds to file.
        /// </summary>
        /// <param name="playgroundArray">Playground Array example.</param>
        public void WriteInformationInFile(IPlaygroundArray playgroundArray);

        /// <summary>
        /// Method reads information from file and return playground array and number of iteration.
        /// </summary>
        /// <returns> IPlaygroundArray - PlaygroundArray from file.  </returns>
        public IPlaygroundArray OpenFileAndGatInformation();

    }
}
