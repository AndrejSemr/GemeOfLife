
namespace GameOfLife
{
    public interface IPlayground
    {
        public int NumberOfLivePoints();
        public int NumberOfIteration();
        public int[,] GetPlaygroundArray();
        public void Iteration();
    }
}
