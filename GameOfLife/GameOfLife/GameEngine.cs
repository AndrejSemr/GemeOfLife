namespace GameOfLife.GameOfLife
{
    using System;
    using System.Threading;

    /// <summary>
    /// Class for game managing.
    /// </summary>
    public class GameEngine
    {

        private IUserUI _userUI = new UserUI();
        private PlaygroundArray _gamePlaygroundArray;
        private int[] _arrayWithSelectedPlaygrounds;
        private IWorkWithFile _fileWorker;
        private string _path = @"C:\Users\andrejs.semrjakovs\Downloads\PlaygroundArraySave.json";

        /// <summary>
        /// Method starts game process.
        /// </summary>
        public void Start()
        {
            _fileWorker = new FileWriterJSON(_path);
            int typeOfPlaygroundCreation = _userUI.StartMenuItem();
            int howMuchCanSelect = CreatePlaygroundArrayForSelectedMenuItem(typeOfPlaygroundCreation);
            _arrayWithSelectedPlaygrounds = _userUI.SelectPlaygroundsID(_gamePlaygroundArray.NumberOfArrays, howMuchCanSelect);

            TimerCallback tm = new TimerCallback(GameLifeCycle);
            Timer timer = new Timer(tm, null, 0, 1000);

            _userUI.KeyLogerToExit(ConsoleKey.Escape);
            timer.Dispose();

            int selectedOption = _userUI.ShowSaveMenu();
            SaveGameOrNo(selectedOption);

        }

        /// <summary>
        /// Create PlaygroundArray for selected menu item.
        /// </summary>
        /// <param name="selectedMenuItem"> Selected menu item</param>
        /// <returns> int - Number how many playgrounds on screen can choose.</returns>
        private int CreatePlaygroundArrayForSelectedMenuItem(int selectedMenuItem)
        {
            int howManyPlaygroundsCanSelect = 0;

            if (selectedMenuItem == 1)
            {
                int rows;
                int column;
                int numberOfGame;
                _userUI.EnterPlaygroundSize(out rows, out column, out numberOfGame);
                _gamePlaygroundArray = new PlaygroundArray(rows, column, numberOfGame);
                howManyPlaygroundsCanSelect = numberOfGame;
            }
            else
            {
                try
                {
                    _gamePlaygroundArray = (PlaygroundArray)_fileWorker.OpenFileAndGatInformation();
                    howManyPlaygroundsCanSelect = _gamePlaygroundArray.NumberOfArrays;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("File does not exist.(Error: {0})", ex);
                    CreatePlaygroundArrayForSelectedMenuItem(1);
                }
            }

            if (howManyPlaygroundsCanSelect > 8)
            {
                return 8;
            }
            return howManyPlaygroundsCanSelect;
        }

        /// <summary>
        /// Method responsible for game process
        /// </summary>
        /// <param name="playgroundObj"> Playground as object </param>
        private void GameLifeCycle(object tmp)
        {
            _gamePlaygroundArray.Iteration();
            _userUI.DisplayPlaygroundArray(_gamePlaygroundArray, _arrayWithSelectedPlaygrounds);
        }

        /// <summary>
        /// Method saves playground to file or display a massage that playground
        /// is not saved.
        /// </summary>
        /// <param name="selectedOption"> Selected option (1- save file / else - no).</param>
        private void SaveGameOrNo(int selectedOption)
        {
            if(selectedOption == 1)
            {
                _fileWorker.WriteInformationInFile(_gamePlaygroundArray);
                _userUI.SendMessageToUser("File saved successfully.");
            }
            else
            {
                _userUI.SendMessageToUser("File is not saved.");
            }
        }

    }
}