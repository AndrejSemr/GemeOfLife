namespace GameOfLife
{
    using global::GameOfLife.GameOfLife;
    /// <summary>
    /// Class starts the game class
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Method start programm
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        { 
            GameEngine gameEngin = new GameEngine();
            gameEngin.Start();
        }
    }
}



