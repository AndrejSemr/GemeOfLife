namespace GameOfLife
{
    using global::GameOfLife.GameOfLife;
    /// <summary>
    /// Class starts the game class
    /// </summary>
    public class Program
    {
        static void Main(string[] args)
        { 
            GameEngine gameEngin = new GameEngine();
            gameEngin.Start();
        }
    }
}



