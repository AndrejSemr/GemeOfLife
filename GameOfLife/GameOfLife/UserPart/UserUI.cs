
namespace GameOfLife.GameOfLife
{
    using System;

    /// <summary>
    /// 
    ///     Class for displaying information (console)
    ///     
    /// </summary>
    public class UserUI
    {
        private FileWorker _fileWorker = new FileWorker();

        /// <summary>
        /// 
        ///     Method create Playground accortind to the selected action:
        ///         1)  Create Playground based on entered data (rows and colums)
        ///         2)  Read array and iteration number from file and create Playground
        ///         
        /// </summary>
        /// <returns> Playdround </returns>
        public Playground CreatePlayground()
        {
            int startPlan = GetMenuItem();

            if (startPlan == 1)
            {
                return CreatePlaygroundByEnteredDataAndFillItByRandom();
            }

            return ReadArrayFromFile();
        }
        /// <summary>
        /// 
        ///     Method asks User if he/she wants to save the result
        ///
        /// </summary>
        /// <param name="playground"> Playground for saving </param>
        public void ShowLastMenu(Playground playground)
        {
            string menuText = "Do you want to save result?\n";
            menuText += "1 - Yes \n";
            menuText += "2 - No";
            Console.WriteLine(menuText);
            
            int answer = SelectValueInReange(1,2,"");
            if (answer == 1)
            {
                _fileWorker.WriteInformationInFile(playground);
            }
            else
            {
                Console.WriteLine("File is not saved");
            }
        }

        /// ||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||

        /// <summary>
        /// 
        ///     Methode display playground, iteration number and number of live points
        ///     
        /// </summary>
        /// <param name="gamePlayground"> Playground </param>
        public void DisplayPlayground(IPlayground gamePlayground)
        {
            Console.Clear();
            Drow(gamePlayground.GetPlaygroundArray()); /// REWRITE
            Console.WriteLine("Live points number: " + gamePlayground.NumberOfLivePoints() + "\t" +
                          "Iteration: " + gamePlayground.NumberOfIteration());
            Console.WriteLine("Press 'Esc' to end the game.");
        }

        /// <summary>
        /// 
        ///     Read array and iteration number from file and create Playground
        ///     
        /// </summary>
        /// <returns> Playground </returns>
        private Playground ReadArrayFromFile()
        {
            int[,] array;
            int iteration;

            _fileWorker.OpenFileAndGatInformation(out array, out iteration);
            return new Playground(array, iteration);
        }

        /// <summary>
        /// 
        ///     Create Playground based on entered data (rows and colums)
        ///     
        /// </summary>
        /// <returns> Playground </returns>
        private Playground CreatePlaygroundByEnteredDataAndFillItByRandom()
        {
            Console.Clear();
            int row;
            int column;
            EnterPlaygroundSize(out row, out column);
            Playground playground = new Playground(row, column);
            playground.RandomlyFillArray();
            return playground;
        }
        
        public void Drow(int[,] playground)
        {
            for (int i = 0; i < playground.GetLength(0); i++)
            {
                for (int j = 0; j < playground.GetLength(1); j++)
                {
                    if (playground[i, j] == 0)
                    {
                        Console.Write("{0,3}", ".");
                    }
                    else
                    {
                        Console.Write("{0,3}", playground[i, j]);
                    }
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        ///     Method return the number of selected item from menu first menu.
        /// </summary>
        /// <returns></returns>
        private int GetMenuItem()
        {
            Console.Clear();
            string menuInfo = "Select option: \n";
            menuInfo += "1 - Select size and fill playground randomly. \n";
            menuInfo += "2 - Take a ready array from file. \n";

            Console.Write(menuInfo);
            return SelectValueInReange(1,2,"");
        }

        /// <summary>
        /// 
        ///     Method asks User to enter size of the playground (rows and columns)
        ///         
        /// </summary>
        /// <return>
        ///     <param name="row"> number of rows </param>
        ///     <param name="column"> numeber of colums </param>
        /// </return>
        private void EnterPlaygroundSize(out int row, out int column)
        {
            row = SelectValueInReange(1,Int32.MaxValue,"Enter number of rows");
            Console.Clear();
            column = SelectValueInReange(1, Int32.MaxValue, "Enter number of rows");
            Console.Clear();
        }

        /// <summary>
        /// 
        ///     Method controls that the entered number was in the specified range.
        ///     
        /// </summary>
        /// <param name="min"> Range minimum </param>
        /// <param name="max"> Range maximum </param>
        /// <param name="information"> The message | Write "" if there is no explanation for input </param>
        /// <returns> 
        ///     Number that is in specified range 
        /// </returns>
        private int SelectValueInReange(int min, int max, string information)
        {
            Console.WriteLine(information);
            int selectedItem = IntegerInput("Enter value:");

            if ((selectedItem >= min) && (max >= selectedItem))
            {
                return selectedItem;
            }
            return SelectValueInReange(max, min, "Selected item is out of range");
        }

        /// <summary>
        /// 
        ///     Method writes information to User and asks for an integer number;
        ///     
        /// </summary>
        /// <param name="informationToUser"> (string) - information for User about integer; </param>
        /// <returns>
        ///     int - integer number entered by user
        /// </returns>
        private int IntegerInput(string informationToUser)
        {
            Console.WriteLine(informationToUser);
            string intAsAText = Console.ReadLine();
            int inputInt;
            bool parsRezult = int.TryParse(intAsAText, out inputInt);

            if (parsRezult)
            {
                return inputInt;
            }
            return IntegerInput("Wrong number entered! Try again.");
        }
    }
}
