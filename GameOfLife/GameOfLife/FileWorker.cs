namespace GameOfLife.GameOfLife
{
    using System.IO;


    /// 
    /// Class is created to work with file :
    ///     Get information from file;
    ///     Write information in file;
    /// 

    public class FileWorker
    {
        // Path to the game save file
        private string Path = @"C:\Users\andrejs.semrjakovs\Downloads\MyTest.txt";

        ///
        /// Method writes information to file
        /// Playground (Playground)
        /// Playground Row (int)
        /// Playground Column (int)
        /// Return: Nothing
        public void WriteInformationInFile(Playground playground,int row, int column)
        {
            File.Create(Path).Close();
            StreamWriter sw;
            sw = File.AppendText(Path);
            // Serialication??!!
            int[,] array = playground.getPlaygroundArray();

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
            gameStatus += "Iteration number;" + 1 + ";";
            gameStatus += "Number of live;" + 2 + ";";
            sw.WriteLine(gameStatus);
            sw.Close();
        }

        /// 
        /// Method return playground array and iteration number from game save file;
        /// 
        public void OpenFileAndGatInformation(out int[,] playgroundArray, out int iteration)
        {
            string fileContent;
            fileContent = File.ReadAllText(Path);

            string[] splitInfopartAndArray = fileContent.Split('#');

            GetInfoPart(splitInfopartAndArray[1], out iteration);
            playgroundArray = GetIntArrayFromString(splitInfopartAndArray[0]);
        }

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

        private void GetInfoPart(string text, out int iteration)
        {
            string[] iterationAndLives = text.Split(';');
            iteration = int.Parse(iterationAndLives[1]);
        }
    
    }
}
