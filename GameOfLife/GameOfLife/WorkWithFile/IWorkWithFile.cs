namespace GameOfLife.GameOfLife
{
    public interface IWorkWithFile
    {
        public void WriteInformationInFile(IPlayground playground);
        public void OpenFileAndGatInformation(out int[,] playgroundArray, out int iteration);
    }
}
