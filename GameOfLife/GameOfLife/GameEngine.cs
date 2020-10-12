namespace GameOfLife.GameOfLife
{
    using System;
    using System.Threading;

    /// <summary>
    /// Class for game managing.
    /// </summary>
    public class GameEngine
    {
        private  UserUI userUI = new UserUI();
        private PlaygroundArray gamePlaygroundArray;
        private IWorkWithFile _fileWorker = new FileWriterBin();
        private int[] arrayWithSelectedPlaygrounds;
        //private PlaygroundArray TESTsaveArray;  // array of links to original 8 : performance?
        
        /// <summary>
        /// Method starts game process.
        /// </summary>
        public void Start()
        {

            int typeOfPlaygroundCreation = userUI.StartMenuItem();
            int howMuchCanSelect = CreatePlaygroundArrayForSelectedMenuItem(typeOfPlaygroundCreation);
            arrayWithSelectedPlaygrounds = userUI.SelectPlaygroundsID(gamePlaygroundArray.NumberOfArrays, howMuchCanSelect);
            //TESTsaveArray = ReturnLinks(gamePlaygroundArray);

            TimerCallback tm = new TimerCallback(GameLifeCycle);
            Timer timer = new Timer(tm, null, 0, 1000);
            userUI.KeyLogerToExit(ConsoleKey.Escape);
            timer.Dispose();
            int isSaveGame = userUI.ShowSaveMenu();
            if(isSaveGame == 1)
            {
                _fileWorker.WriteInformationInFile(gamePlaygroundArray);
            }

        }

        /// <summary>
        /// Create PlaygroundArray for selected menu item from UI part.
        /// </summary>
        /// <param name="typeOfPlaygroundCreation"> Selected menu item</param>
        private int CreatePlaygroundArrayForSelectedMenuItem(int typeOfPlaygroundCreation)
        {
            int howMuchCanSelect = 0;
            if (typeOfPlaygroundCreation == 1)
            {
                int rows;
                int column;
                int numberOfGame;
                userUI.EnterPlaygroundSize(out rows, out column, out numberOfGame);
                gamePlaygroundArray = new PlaygroundArray(rows, column, numberOfGame);
                howMuchCanSelect = numberOfGame;
            }
            else
            {
                gamePlaygroundArray = (PlaygroundArray)_fileWorker.OpenFileAndGatInformation();
                howMuchCanSelect = gamePlaygroundArray.NumberOfArrays;
            }

            if (howMuchCanSelect > 8)
            {
                return 8;
            }
            return howMuchCanSelect;
        }


        /// <summary>
        /// Method responsible for game process
        /// </summary>
        /// <param name="playgroundObj"> Playground as object </param>
        private void GameLifeCycle(object tmp)
        {
            gamePlaygroundArray.Iteration();
            userUI.DisplayPlaygroundArray(gamePlaygroundArray, arrayWithSelectedPlaygrounds);
            //userUI.TESTDisplayPlaygroundArray(TESTsaveArray);
        }

        /////////////////////////////////////////////////////////////////
        
        //public PlaygroundArray ReturnLinks (PlaygroundArray playgroundArray)
        //{
        //    PlaygroundArray playground = new PlaygroundArray(playgroundArray.playgroundArray.GetLength(0),
        //                                                      playgroundArray.playgroundArray.GetLength(1),
        //                                                      myarray.Length);
        //
        //    for (int i = 0; i < arrayWithSelectedPlaygrounds.Length; i++)
        //    {
        //        int index = arrayWithSelectedPlaygrounds[i];
        //        playground.playgroundArray[i] = playgroundArray.playgroundArray[index];
        //    }

        //    return playground;
        //}

    }
}