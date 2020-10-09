namespace GameOfLife.GameOfLife
{
    using System;
    using System.Threading;

    /// <summary>
    ///     Class for game managing.
    /// </summary>
    class GameEngine
    {
        UserUI userUI = new UserUI();

        public void Start()
        {
            Playground gamePlayground = userUI.CreatePlayground();
            userUI.Drow(gamePlayground.GetPlaygroundArray());
            TimerCallback tm = new TimerCallback(GameLifeCycle);
            Timer timer = new Timer(tm, gamePlayground, 0, 2000);
            EscapeIsNotPressed(ConsoleKey.Escape);
            timer.Dispose();
            userUI.ShowLastMenu(gamePlayground);

        }
        /// <summary>
        ///     Method wait for specified key to be pressed
        /// </summary>
        private void EscapeIsNotPressed(ConsoleKey exitButtin)
        {
            do
            {
            } while (exitButtin != Console.ReadKey().Key);
        }

        /// <summary>
        ///     Method responsible for game process
        /// </summary>
        /// <param name="playgroundObj"> Playground as object </param>
        private void GameLifeCycle(object playgroundObj)
        {
            IPlayground playground = (IPlayground)playgroundObj;
            playground.Iteration();
            userUI.DisplayPlayground(playground);
        }
    }
}

//Thread gameLogicThread = new Thread(gameLog.GameLifeCycleStart);
//Thread userDisplay = new Thread(new ParameterizedThreadStart(userUI.DisplayPlayground));
//gameLogicThread.Start();
//userDisplay.Start(gameLog);
//gameLog.cycleOfLifeContinue = userUI.TimeToStop();
//userUI.StopDisplayPlayground();