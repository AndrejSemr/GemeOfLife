using GameOfLife.GameOfLife;
using System.Collections.Generic;
using Xunit;
using System.IO.Abstractions.TestingHelpers;
using System.IO;
using Newtonsoft.Json;

namespace GameOfLifeTests
{
    /// <summary>
    /// Tests cover IWorkWithFile interface and his child
    /// </summary>
    public class FileWriter_Test
    {
        private string jsonForTest;

        public FileWriter_Test()
        {
            //jsonForTest = ("{'playgroundArray':[{'arrayChecker':{},'PlaygroundRows':10,'PlaygroundColumns':10,'PlaygriundGrid':[[1,1,0,0,1,0,0,1,0,1],[1,1,1,0,1,0,1,1,0,1],[1,0,1,0,1,1,0,0,1,1],[0,0,1,0,0,1,0,0,0,1],[1,0,0,1,1,0,1,1,1,0],[1,0,1,1,1,1,0,1,0,1],[0,1,1,0,1,1,1,1,0,0],[0,0,0,1,1,0,1,1,0,1],[1,0,1,1,0,0,0,0,0,0],[1,0,0,1,1,0,0,1,0,0]],'IterationNumber':0}],'NumberOfArrays':1}");
            string Path = @"C:\Users\andrejs.semrjakovs\Downloads\MyTest.json";
            jsonForTest = File.ReadAllText(Path);

        }

        [Fact]
        public void OpenFileAndGatInformation_TEST()
        {
            string Path = @"C:\Users\andrejs.semrjakovs\Downloads\MyTestt.json";
            var fileSystem = new MockFileSystem(new Dictionary<string, MockFileData>
            {
                { Path, jsonForTest }
            });
            FileWriterJSON fileWeiter = new FileWriterJSON(fileSystem,Path);

            PlaygroundArray arrayJsonSerialization = JsonConvert.DeserializeObject<PlaygroundArray>(jsonForTest);
            PlaygroundArray arrayFunctionTest = (PlaygroundArray)fileWeiter.OpenFileAndGatInformation();

            Assert.Equal(arrayJsonSerialization.NumberOfArrays,
                            arrayFunctionTest.NumberOfArrays);
            Assert.Equal(arrayJsonSerialization.playgroundArray[0].GetNumberOfIteration(),
                            arrayFunctionTest.playgroundArray[0].GetNumberOfIteration());
            Assert.Equal(arrayJsonSerialization.playgroundArray[0].GetNumberOfLivePoints(),
                            arrayFunctionTest.playgroundArray[0].GetNumberOfLivePoints());
            Assert.Equal(arrayJsonSerialization.playgroundArray[0].GetPlaygroundArray(),
                            arrayFunctionTest.playgroundArray[0].GetPlaygroundArray());
        }

        [Fact]
        public void WriteInformationInFile()
        {
            GameEngine gameEngine = new GameEngine();
            string Path = @"C:\Users\andrejs.semrjakovs\Downloads\MyTestTT.json";
            var fileSystem = new MockFileSystem(new Dictionary<string, MockFileData>
            {
                { Path, "" }
            });
            IPlaygroundArray playgroundArr = JsonConvert.DeserializeObject<PlaygroundArray>(jsonForTest);

            IWorkWithFile file = new FileWriterJSON(fileSystem, Path);
            file.WriteInformationInFile(playgroundArr);
            string text = fileSystem.File.ReadAllText(Path);

            Assert.Equal(text, jsonForTest);
        }

        [Fact]
        public void OpenFileAndGatInformation_FileNotExist_FileNotFoundException()
        {
            string Path = @"C:\Users\andrejs.semrjakovs\Downloads\MyTestt.json";
            var fileSystem = new MockFileSystem();
            IWorkWithFile file = new FileWriterJSON(fileSystem, Path);

            Assert.Throws<FileNotFoundException>(() => file.OpenFileAndGatInformation());
        }

        [Fact]
        public void CreateSaveDownload_CreateClassSaveItAndDownloadFromFile_True()
        {
            IPlaygroundArray expectedArray = new PlaygroundArray(10, 10, 1);
            string Path = @"C:\Users\andrejs.semrjakovs\Downloads\MyTestTT.json";
            var fileSystem = new MockFileSystem(new Dictionary<string, MockFileData>
            {
                { Path, "" }
            });
            IWorkWithFile file = new FileWriterJSON(fileSystem, Path);
            
            file.WriteInformationInFile(expectedArray);
            IPlaygroundArray actualArray = file.OpenFileAndGatInformation();

            Assert.Equal(expectedArray.NumberOfArrays,
                            actualArray.NumberOfArrays);
            Assert.Equal(expectedArray.playgroundArray[0].GetNumberOfIteration(),
                            actualArray.playgroundArray[0].GetNumberOfIteration());
            Assert.Equal(expectedArray.playgroundArray[0].GetNumberOfLivePoints(),
                            actualArray.playgroundArray[0].GetNumberOfLivePoints());
            Assert.Equal(expectedArray.playgroundArray[0].GetPlaygroundArray(),
                            actualArray.playgroundArray[0].GetPlaygroundArray());

        }
    }
}
