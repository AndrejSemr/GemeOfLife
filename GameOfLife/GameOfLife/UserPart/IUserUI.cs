using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife.GameOfLife
{
    interface IUserUI
    {
        /// <summary>
        /// Method wait for specified key to be pressed.
        /// </summary>
        /// <param name="exitButtin"> Key that should be pressed. </param>
        public void KeyLogerToExit(ConsoleKey exitButtin);

        /// <summary>
        /// Method asks User if he/she wants to save the result to file.
        /// </summary>
        /// <returns> int - User's answer. </returns>
        public int ShowSaveMenu();

        /// <summary>
        /// Method shows menu items and asks user to enter menu item.
        /// </summary>
        /// <returns> int - Number of selected item from start menu. </returns>
        public int StartMenuItem();

        /// <summary>
        /// Method asks the User to select arrays ID from arrays.
        /// Selected arrays ID should NOT be repeated.
        /// </summary>
        /// <param name="numbersOfArrays"> Number of created arrays. </param>
        /// <param name="maxNumberOfSelectedItems"> Number of elements that should be selected.</param>
        /// <returns> int[] - Arrays of selected ID </returns>
        public int[] SelectPlaygroundsID(int numbersOfArrays, int maxNumberOfSelectedItems);

        /// <summary>
        /// Method to display selected Playgrounds.
        /// </summary>
        /// <param name="gamePlaygroundArrays"> Arrays of playgrounds; </param>
        /// <param name="arrayWithSelectedPlaygrounds"> Array with selected playgrounds ID; </param>
        public void DisplayPlaygroundArray(IPlaygroundArray gamePlaygroundArrays, int[] arrayWithSelectedPlaygrounds);

        /// <summary>
        /// Method asks User to enter size of the playground (rows and columns) and 
        /// numbers of games (Number of arrays);
        /// </summary>
        /// <return>
        /// <param name="row"> Number of rows. </param>
        /// <param name="column"> Numeber of colums. </param>
        /// <param name="numberOfGame"> How many elements to create in Playground Array.</param>
        /// </return>
        public void EnterPlaygroundSize(out int row, out int column, out int numberOfGame);

        /// <summary>
        /// Method send a message to user.
        /// </summary>
        /// <param name="message"> Message to user. </param>
        public void SendMessageToUser(string message);

    }
}
