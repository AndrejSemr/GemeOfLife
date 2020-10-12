
namespace GameOfLife
{
    public interface IPlayground
    {
        public int PlaygroundRows { get; set; }
        public int PlaygroundColumns{get; set; }
        public int[,] PlaygriundGrid { get; set; }
        public int IterationNumber { get; set; }
        public int GetNumberOfLivePoints();
        public int GetNumberOfIteration();
        public int[,] GetPlaygroundArray();
        public void Iteration();
    }
}
