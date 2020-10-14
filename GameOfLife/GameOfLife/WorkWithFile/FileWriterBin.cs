
namespace GameOfLife.GameOfLife
{
    using System;
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;

    /// <summary>
    /// Class for work with binary file.
    /// </summary>
    class FileWriterBin : IWorkWithFile
    {
        private string Path = @"C:\Users\andrejs.semrjakovs\Downloads\MyTest.dat";

        /// <summary>
        /// Method reads information from file and return playground array and number of iteration.
        /// </summary>
        /// <return> IPlaygroundArray - PlaygroundArray from file. </return>
        public IPlaygroundArray OpenFileAndGatInformation()
        {
            if (!File.Exists(Path))
            {
                Console.WriteLine("File not found \n {0}",Path);
                throw new FileNotFoundException();
            }

            BinaryFormatter binary = new BinaryFormatter();
            FileStream strem = new FileStream(Path, FileMode.Open);
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
            if (File.Exists(Path))
            {
                File.Delete(Path);
            }

            BinaryFormatter binary = new BinaryFormatter();
            FileStream strem = new FileStream(Path, FileMode.Create);
            binary.Serialize(strem, playgroundArray);
            strem.Close();
            Console.WriteLine("Successfully saved");
        }
    }
}
