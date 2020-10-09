using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace GameOfLife.GameOfLife
{
    class FileWriterBin : IWorkWithFile
    {
        private string Path = @"C:\Users\andrejs.semrjakovs\Downloads\MyTest.dat";

        /// <summary>
        /// 
        ///     Method reads information from file and return playground array and number of iteration.
        ///     
        /// </summary>
        /// <return>
        ///     <param name="playgroundArray"> playground array (from file) </param>
        ///     <param name="iteration"> number of iteration (from file) </param>
        /// </return>
        public void OpenFileAndGatInformation(out int[,] playgroundArray, out int iteration)
        {
            if (!File.Exists(Path))
            {
                Console.WriteLine("File not found \n {0}",Path);
            }

            BinaryFormatter binary = new BinaryFormatter();
            FileStream strem = new FileStream(Path, FileMode.Open);
            var obj = (Playground)binary.Deserialize(strem);

            playgroundArray = obj.GetPlaygroundArray();
            iteration = obj.NumberOfIteration();
            strem.Close();
        }

        /// <summary>
        /// 
        ///     Method writes playground to file (as binary form)
        /// 
        /// </summary>
        /// <param name="playground"> Playground </param>
        public void WriteInformationInFile(IPlayground playground)
        {
            if (File.Exists(Path))
            {
                File.Delete(Path);
            }

            BinaryFormatter binary = new BinaryFormatter();
            FileStream strem = new FileStream(Path, FileMode.Create);

            binary.Serialize(strem,playground);
            strem.Close();
        }
    }
}
