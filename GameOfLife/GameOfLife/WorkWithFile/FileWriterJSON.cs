
namespace GameOfLife.GameOfLife
{
    using System.IO;
    using Newtonsoft.Json;
    using System.IO.Abstractions;

    /// <summary>
    /// Class for work with JSON file.
    /// </summary>
    public class FileWriterJSON: IWorkWithFile
    {
        private string _path;
        private IFileSystem _fileSystem;

        #region Constructors

        /// <summary>
        /// Constructor for tests.
        /// </summary>
        /// <param name="fileSystem"> FileStrym interface. </param>
        public FileWriterJSON(IFileSystem fileSystem)
        {
            this._fileSystem = fileSystem;
            _path = @"C:\Users\andrejs.semrjakovs\Downloads\PlaygroundArraySave.json";
        }

        /// <summary>
        /// Constructor for tests.
        /// </summary>
        /// <param name="fileSystem"> FileStrym interface. </param>
        /// <param name="path"> Path to file. </param>
        public FileWriterJSON(IFileSystem fileSystem, string path)
        {
            _path = path;
            this._fileSystem = fileSystem;
        }

        /// <summary>
        /// Constructor initiates work with file (witch poecified path)
        /// </summary>
        public FileWriterJSON(string path) : this(fileSystem: new FileSystem())
        {
            _path = path;
        }

        #endregion

        /// <summary>
        /// Method reads information from JSON file and return playground array and number of iteration.
        /// </summary>
        /// <return> IPlaygroundArray - PlaygroundArray from file. </return>
        public IPlaygroundArray OpenFileAndGatInformation()
        {
            if (!_fileSystem.File.Exists(_path))
            { 
                throw new FileNotFoundException();
            }

            string jsoneText = _fileSystem.File.ReadAllText(_path);
            var obj = JsonConvert.DeserializeObject<PlaygroundArray>(jsoneText);
            return obj;
        }

        /// <summary>
        /// Method save playgrounds to file (as JSON form).
        /// </summary>
        /// <param name="playgroundArray"> Playground Array example. </param>
        public void WriteInformationInFile(IPlaygroundArray playgroundArray)
        {
            if (_fileSystem.File.Exists(_path))
            {
                _fileSystem.File.Delete(_path);
            }

            var jsonObject = JsonConvert.SerializeObject(playgroundArray);
            _fileSystem.File.WriteAllText(_path, jsonObject);
        }
    }
}
