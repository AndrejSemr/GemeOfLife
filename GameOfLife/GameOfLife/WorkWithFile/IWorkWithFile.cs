namespace GameOfLife.GameOfLife
{
    public interface IWorkWithFile
    {
        public void WriteInformationInFile(IPlaygroundArray playgroundArray);
        public IPlaygroundArray OpenFileAndGatInformation();
    }
}
