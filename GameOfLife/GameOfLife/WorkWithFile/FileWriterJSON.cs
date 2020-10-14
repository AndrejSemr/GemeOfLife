namespace GameOfLife.GameOfLife
{
    using System;
    using System.IO;
    using System.Text.Json;
    using System.Text.Json.Serialization;
    using Newtonsoft.Json;


    /// <summary>
    /// Class for work with JSON file.
    /// </summary>
    class FileWriterJSON: IWorkWithFile
    {
        private string Path = @"C:\Users\andrejs.semrjakovs\Downloads\MyTest.json";

        /// <summary>
        /// Method reads information from JSON file and return playground array and number of iteration.
        /// </summary>
        /// <return> IPlaygroundArray - PlaygroundArray from file. </return>
        public IPlaygroundArray OpenFileAndGatInformation()
        {
            if (!File.Exists(Path))
            {
                Console.WriteLine("File not found \n {0}", Path);
                throw new FileNotFoundException();
            }

            string jsoneText = File.ReadAllText(Path);
            var obj = JsonConvert.DeserializeObject<PlaygroundArray>(jsoneText);
            return obj;
        }

        /// <summary>
        /// Method save playgrounds to file (as JSON form).
        /// </summary>
        /// <param name="playgroundArray"> Playground Array example. </param>
        public void WriteInformationInFile(IPlaygroundArray playgroundArray)
        {
            if (File.Exists(Path))
            {
                File.Delete(Path);
            }

            var jsonObject = JsonConvert.SerializeObject(playgroundArray);
            File.WriteAllText(Path, jsonObject);
            Console.WriteLine("Successfully saved");
        }
    }
}
