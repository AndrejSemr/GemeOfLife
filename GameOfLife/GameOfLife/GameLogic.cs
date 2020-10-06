using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace GameOfLife.GameOfLife
{
    ///
    /// This Class contains GameOfLife logic and connect its components; 
    /// 

    public class GameLogic
    {
        // Dep. Injection ??

        private FileWorker _fileWorker = new FileWorker();
        private GamePlayground _game;
        private Playground _playground;


        public GameLogic(GamePlayground game)
        {
            _game = game;
            _playground = game.playground;
        }

        /// 
        /// Method simulates the game's life cycle;
        /// As parameters:
        ///     Playground (Playground) - User playground for this game cycle;
        ///
        public void GameLifeCycle(Playground playground)
        {

            do
            {
                Console.Clear();
                playground.Drow();

                // Go to UI class : TO DO
                Console.Write("Live points number: " + playground.NumberOfLivePoints() + "\t" +
                              "Iteration: " + playground.iteration++);

                playground.Iteration();
                Thread.Sleep(1000);

            } while (true); // - Demo

            //} while (Console.ReadKey().Key != ConsoleKey.Escape);

        }

        /// 
        /// Method asks User to enter size of the playground 
        /// Return:
        ///     row (int)       - number of rows 
        ///     column (int)    - numeber of colums
        ///
        public void EnterPlaygroundSize(out int row, out int column)
        {
            row = IntegerInput("Enter number of rows");
            Console.Clear();
            column = IntegerInput("Enter number of columns");
            Console.Clear();
        }

        /// 
        /// Method writes information to User and asks for an integer number;
        /// AS parameter: 
        ///     informationToUser (string) - a small information for User about integer;
        /// Return:
        ///     int - integer number entered by user
        ///
        public int IntegerInput(string informationToUser)
        {
            Console.WriteLine(informationToUser);
            string intAsAText = Console.ReadLine();
            int inputInt;
            bool parsRezult = int.TryParse(intAsAText, out inputInt);

            if (parsRezult) return inputInt;
            return IntegerInput("Wrong number entered! Try again.");
        }

        /// 
        /// Sequence of actions to start and the game
        /// 
        public void GameStartMenu()
        {
            // Go To UI part?
            string menuInfo = "Select option: \n";
            menuInfo += "1 - Select size and fill playground randomly. \n";
            menuInfo += "2 - Take a ready array from file. \n";
            
            Console.Write(menuInfo);
            int i = IntegerInput("Enter value:");

            if (i == 1)
            {
                Console.Clear();
                int row;
                int column;
                EnterPlaygroundSize(out row, out column);
                _playground = new Playground(row, column);
                _playground.RandomlyFillArray();

            }
            else if (i == 2)
            {
                int[,] array;
                int iteration;

                _fileWorker.OpenFileAndGatInformation(out array, out iteration);
                _playground = new Playground(array, iteration);

            }
            else GameStartMenu();
            GameLifeCycle(_playground);
        }
    }
}
