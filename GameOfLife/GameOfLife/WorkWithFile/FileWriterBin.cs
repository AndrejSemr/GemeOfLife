
namespace GameOfLife.GameOfLife
{
    using System;
    using System.IO;
    using System.IO.Abstractions;
    using System.Runtime.Serialization.Formatters.Binary;

    /// <summary>
    /// Class for work with binary file.
    /// </summary>
    public class FileWriterBin : IWorkWithFile
    {
        private string _path;
        private IFileSystem _fileSystem;
    
        #region Constructor

        /// <summary>
        /// Constructor for tests.
        /// </summary>
        /// <param name="fileSystem"> FileStrym interface. </param>
        public FileWriterBin(IFileSystem fileSystem)
        {
            this._fileSystem = fileSystem;
            _path = @"C:\Users\andrejs.semrjakovs\Downloads\PlaygroundArraySave.bin";
        }

        /// <summary>
        /// Constructor for tests.
        /// </summary>
        /// <param name="fileSystem"> FileStrym interface. </param>
        /// <param name="path"> Path to file. </param>
        public FileWriterBin(IFileSystem fileSystem, string path)
        {
            _path = path;
            this._fileSystem = fileSystem;
        }

        /// <summary>
        /// Constructor initiates work with file (witch poecified path)
        /// </summary>
        public FileWriterBin(string path) : this(fileSystem: new FileSystem())
        {
            _path = path;
        }

        #endregion

        /// <summary>
        /// Method reads information from file and return playground array and number of iteration.
        /// </summary>
        /// <return> IPlaygroundArray - PlaygroundArray from file. </return>
        public IPlaygroundArray OpenFileAndGatInformation()
        {
            if (!File.Exists(_path))
            {
                throw new FileNotFoundException();
            }

            BinaryFormatter binary = new BinaryFormatter();
            FileStream strem = new FileStream(_path, FileMode.Open);
            var obj = (IPlaygroundArray)binary.Deserialize(strem);
            strem.Close();

            return obj;
        }

        /// <summary>
        /// Method save playgrounds to file (as binary form).
        /// </summary>
        /// <param name="playgroundArray"> Playground Array example. </param>
        public void WriteInformationInFile(IPlaygroundArray playgroundArray)
        {
            if (_fileSystem.File.Exists(_path))
            {
                _fileSystem.File.Delete(_path);
            }

            BinaryFormatter binary = new BinaryFormatter();
            FileStream strem = new FileStream(_path, FileMode.Create);
            binary.Serialize(strem, playgroundArray);
            strem.Close();
        }
    }
}
