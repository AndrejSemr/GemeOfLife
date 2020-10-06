
namespace GameOfLife.GameOfLife
{
    /// <summary>
    /// 
    /// Class for game managing
    /// 
    /// </summary>
    class GameEngine
    {
        // Create a new playground and pass it to game logic
        // Start the game;
        public void Start()
        {
            GamePlayground gamePlayground = new GamePlayground();
            GameLogic gameLog = new GameLogic(gamePlayground);
            gameLog.GameStartMenu();

        }
    }
}
