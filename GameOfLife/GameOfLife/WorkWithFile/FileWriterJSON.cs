using System.IO.Abstractions;

namespace GameOfLife.GameOfLife
{
    using System.IO;
    using Newtonsoft.Json;


    /// <summary>
    /// Class for work with JSON file.
    /// </summary>
    public class FileWriterJSON: IWorkWithFile
    {
        private string Path;
        private IFileSystem fileSystem;

        #region Constructors
        /// <summary>
        /// Constructor for tests.
        /// </summary>
        /// <param name="fileSystem"> FileStrym interface. </param>
        public FileWriterJSON(IFileSystem fileSystem)
        {
            this.fileSystem = fileSystem;
            Path = @"C:\Users\andrejs.semrjakovs\Downloads\MyTest.json";
        }

        /// <summary>
        /// Constructor for tests.
        /// </summary>
        /// <param name="fileSystem"> FileStrym interface. </param>
        /// <param name="path"> Path to file. </param>
        public FileWriterJSON(IFileSystem fileSystem, string path)
        {
            Path = path;
            this.fileSystem = fileSystem;
        }

        /// <summary>
        /// Original constructor. Used in code.
        /// </summary>
        public FileWriterJSON() : this(fileSystem: new FileSystem())
        {
            Path = @"C:\Users\andrejs.semrjakovs\Downloads\MyTest.json";
        }
        #endregion

        /// <summary>
        /// Method reads information from JSON file and return playground array and number of iteration.
        /// </summary>
        /// <return> IPlaygroundArray - PlaygroundArray from file. </return>
        public IPlaygroundArray OpenFileAndGatInformation()
        {
            if (!fileSystem.File.Exists(Path))
            { 
                throw new FileNotFoundException();
            }

            string jsoneText = fileSystem.File.ReadAllText(Path);
            var obj = JsonConvert.DeserializeObject<PlaygroundArray>(jsoneText);
            return obj;
        }

        /// <summary>
        /// Method save playgrounds to file (as JSON form).
        /// </summary>
        /// <param name="playgroundArray"> Playground Array example. </param>
        public void WriteInformationInFile(IPlaygroundArray playgroundArray)
        {
            if (fileSystem.File.Exists(Path))
            {
                fileSystem.File.Delete(Path);
            }

            var jsonObject = JsonConvert.SerializeObject(playgroundArray);
            fileSystem.File.WriteAllText(Path, jsonObject);
        }
    }
}
