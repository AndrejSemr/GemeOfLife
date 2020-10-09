using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace GameOfLife.GameOfLife
{
    /// <summary>
    /// 
    ///     Class is created to work with file:
    ///         1)  Get information from file;
    ///         2)  Write information in file;
    ///         
    /// </summary>
    public class FileWorker
    {
        // Path to the game save file
        private string Path = @"C:\Users\andrejs.semrjakovs\Downloads\MyTest.txt";


        /// <summary>
        ///     
        ///     Method writes information to file.
        ///     
        /// </summary>
        /// <param name="playground"> Playground </param>
        public void WriteInformationInFile(IPlayground playground)
        {
            File.Create(Path).Close();
            StreamWriter sw;
            sw = File.AppendText(Path);
            // Serialication??!!
            int[,] array = playground.GetPlaygroundArray();
            int row = array.GetLength(0);
            int column = array.GetLength(1);

            for (int i = 0; i < row; i++)
            {
                string arrayLine = "";
                for (int j = 0; j < column; j++)
                {
                    arrayLine += array[i, j].ToString();
                    if (j < column-1) arrayLine += ",";
                    else arrayLine += ";";
                }
                sw.WriteLine(arrayLine);
            }

            string gameStatus = "# ";
            gameStatus += "Iteration number;" + playground.NumberOfIteration() + ";";
            gameStatus += "Number of live;" + playground.NumberOfLivePoints() + ";";
            sw.WriteLine(gameStatus);
            sw.Close();
        }

        /// <summary>
        /// 
        ///     Method return playground array and iteration number from game save file;
        ///     
        /// </summary>
        /// <return>
        ///     <param name="playgroundArray"> Int array of ints that corresponds to Playground </param>
        ///     <param name="iteration"> Number of iteration </param>
        /// </return>
        public void OpenFileAndGatInformation(out int[,] playgroundArray, out int iteration)
        {
            string fileContent;
            fileContent = File.ReadAllText(Path);

            string[] splitInfopartAndArray = fileContent.Split('#');

            GetInfoPart(splitInfopartAndArray[1], out iteration);
            playgroundArray = GetIntArrayFromString(splitInfopartAndArray[0]);
        }

        /// <summary>
        /// 
        ///     Method create int array from text line.
        ///     
        /// </summary>
        /// <param name="text"> Text line of numbers</param>
        /// <returns> 
        ///     int [,] - Playground array from file. 
        /// </returns>
        private int[,] GetIntArrayFromString(string text)
        {
            string[] stringArray = text.Split(";");
                int intArrayRow = stringArray.Length-1;
            string[] arrayLine = stringArray[0].Split(',');
                int intArrayColumn = arrayLine.Length;
            int[,] intArray = new int[intArrayRow, intArrayColumn];

            for (int i = 0; i < intArrayRow; i++)
            {
                arrayLine = stringArray[i].Split(',');
                for (int j = 0; j < intArrayColumn; j++)
                {
                    intArray[i, j] = int.Parse(arrayLine[j]);
                }
            }

            return intArray;
        }

        /// <summary>
        ///
        ///     Method return number of iteration from text line.
        ///
        /// </summary>
        /// <param name="text"> Text line </param>
        /// <return>
        ///     <param name="iteration"> Iteration number </param>
        /// </return>
        private void GetInfoPart(string text, out int iteration)
        {
            string[] iterationAndLives = text.Split(';');
            iteration = int.Parse(iterationAndLives[1]);
        }
    
    }
}
