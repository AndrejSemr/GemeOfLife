namespace GameOfLife.GameOfLife
{
    public interface IGameRoles
    {
        public int[,] DoGameOfLifeIteration(int[,] playgroundArray, int x_size, int y_size);
    }
}
