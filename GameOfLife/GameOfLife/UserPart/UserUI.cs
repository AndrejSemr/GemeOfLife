
namespace GameOfLife.GameOfLife
{
    using System;
    using System.Linq;

    /// <summary>
    /// Class for displaying information (console).
    /// </summary>
    public class UserUI
    {

        /// <summary>
        /// Method asks User if he/she wants to save the result on file.
        /// </summary>
        /// <returns>int - User's answer. </returns>
        public int ShowSaveMenu()
        {
            string menuText = "Do you want to save result?\n";
            menuText += "1 - Yes \n";
            menuText += "2 - No";
            Console.WriteLine(menuText);
           
            return SelectValueInReange(1, 2, "");
        }

        /// <summary>
        /// Method shows menu items and asks user to enter menu item.
        /// </summary>
        /// <returns> int - Number of selected item from start menu. </returns>
        public int StartMenuItem()
        {
            Console.Clear();
            string menuInfo = "Select option: \n";
            menuInfo += "1 - Select size and fill playground randomly. \n";
            menuInfo += "2 - Take a ready array from file. \n";

            Console.Write(menuInfo);
            return SelectValueInReange(1, 2, "");
        }

        /// <summary>
        /// Method asks the User to select arrays ID from arrays.
        /// Selected arrays ID should NOT be repeated.
        /// </summary>
        /// <param name="numbersOfArrays"> Number of created arrays. </param>
        /// <param name="maxNumberOfSelectedItems"> Number of elements that should be selected.</param>
        /// <returns> int[] - Arrays of selected ID </returns>
        public int[] SelectPlaygroundsID(int numbersOfArrays, int maxNumberOfSelectedItems)
        {
            Console.Clear();
            string menuInfo = "Please enter the number of the Playgrounds \n";
                menuInfo += "witch you would like to see.("+ maxNumberOfSelectedItems + " Playgrounds) \n";
            Console.Write(menuInfo);

            int index = 0;
            int[] arrayOfPlaygroundsNumber = new int[maxNumberOfSelectedItems];

            while (index < maxNumberOfSelectedItems)
            {
                string infroForSelection = "Enter " + index + " elenebt [0:" + numbersOfArrays + "]";
                int tmp = SelectValueInReange(0, numbersOfArrays, infroForSelection);
                bool check = false;
                check = arrayOfPlaygroundsNumber.Any(arrayItem => arrayItem == tmp);

                if (!check)
                {
                    arrayOfPlaygroundsNumber[index] = tmp;
                    index++;
                }
                else
                {
                    Console.WriteLine("You entered an already registred playground!");
                }

            }

            return arrayOfPlaygroundsNumber;
           
        }
        /// ||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||

        /// <summary>
        /// Method to display selected Playgrounds.
        /// </summary>
        /// <param name="gamePlaygroundArrays"> Arrays of playgrounds; </param>
        /// <param name="arrayWithSelectedPlaygrounds"> Array with selected playgrounds ID; </param>
        public void DisplayPlaygroundArray(IPlaygroundArray gamePlaygroundArrays,int[] arrayWithSelectedPlaygrounds)
        {
            Console.Clear();

            for (int index = 0; index < arrayWithSelectedPlaygrounds.Length; index++)
            {
                DisplayPlayground(gamePlaygroundArrays.playgroundArray[index]);
            }

            Console.WriteLine("Number of living playgrounds: {0}", gamePlaygroundArrays.GetNumberOfLivingPlaygrounds());
            Console.WriteLine("Press 'Esc' to end the game.");
        }

        //public void TESTDisplayPlaygroundArray(IPlaygroundArray gamePlaygroundArrays)
        //{
        //    Console.Clear();

        //    for (int index = 0; index < gamePlaygroundArrays.NumberOfArrays; index++)
        //    {
        //        DisplayPlayground(gamePlaygroundArrays.playgroundArray[index]);
        //    }

        //    Console.WriteLine("Number of living playgrounds: {0}", gamePlaygroundArrays.GetNumberOfLivingPlaygrounds());
        //    Console.WriteLine("Press 'Esc' to end the game.");
        //}

        /// <summary>
        /// Methode display playground, iteration number and number of live points.
        /// </summary>
        /// <param name="gamePlayground"> Playground </param>
        public void DisplayPlayground(IPlayground gamePlayground)
        {
            Drow(gamePlayground.GetPlaygroundArray()); 
            WriteInformationAboutPlayground(gamePlayground.GetNumberOfLivePoints(), gamePlayground.GetNumberOfIteration());
            
        }

        /// <summary>
        /// Method write iteration number and number of live points.
        /// </summary>
        /// <param name="numberOfLivePoints"> Number of live points. </param>
        /// <param name="numberOfIteration"> Iteration number. </param>
        private void WriteInformationAboutPlayground(int numberOfLivePoints, int numberOfIteration)
        {
            Console.WriteLine("Live points number: " + numberOfLivePoints + "\t" +
                          "Iteration: " + numberOfIteration);
        }
        
        /// <summary>
        /// Methods display playground on console.
        /// </summary>
        /// <param name="playgroundArray"> Playground array</param>
        public void Drow(int[,] playgroundArray)
        {
            for (int i = 0; i < playgroundArray.GetLength(0); i++)
            {
                for (int j = 0; j < playgroundArray.GetLength(1); j++)
                {
                    if (playgroundArray[i, j] == 0)
                    {
                        Console.Write("{0,3}", ".");
                    }
                    else
                    {
                        Console.Write("{0,3}", playgroundArray[i, j]);
                    }
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Method asks User to enter size of the playground (rows and columns) and numbers of games (Number of arrays);
        /// </summary>
        /// <return>
        /// <param name="row"> Number of rows. </param>
        /// <param name="column"> Numeber of colums. </param>
        /// <param name="numberOfGame"> How many elements to create in Playground Array.</param>
        /// </return>
        public void EnterPlaygroundSize(out int row, out int column,out int numberOfGame)
        {
            Console.Clear();
            row = SelectValueInReange(1,Int32.MaxValue,"Enter number of rows [1:"+ Int32.MaxValue + "]");
            Console.Clear();
            column = SelectValueInReange(1, Int32.MaxValue, "Enter number of columns [1:" + Int32.MaxValue + "]");
            Console.Clear();
            numberOfGame = SelectValueInReange(8, Int32.MaxValue, "Enter number of playgrounds [8:" + Int32.MaxValue + "]");
            Console.Clear();
        }

        /// <summary>
        /// Method wait for specified key to be pressed.
        /// </summary>
        /// <param name="exitButtin"> Key that should be pressed. </param>
        public void KeyLogerToExit(ConsoleKey exitButtin)
        {
            do
            {
            } while (exitButtin != Console.ReadKey().Key);
        }

        /// <summary>
        /// Method controls that the entered number was in the specified range.
        /// </summary>
        /// <param name="min"> Range minimum. </param>
        /// <param name="max"> Range maximum. </param>
        /// <param name="information"> Message. </param>
        /// <returns> int - Number that is in specified range. </returns>
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
        /// Method writes information to User and asks for an integer number.
        /// </summary>
        /// <param name="informationToUser"> Information for User about number.</param>
        /// <returns> int - integer number entered by user. </returns>
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
