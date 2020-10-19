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

            string Path = @"Resurses/MyTest.json";
            jsonForTest = File.ReadAllText(Path);

        }

        #region FileWriterJSON_Tests

        [Fact]
        public void JSON_OpenFileAndGatInformation_DeserializeJSONandGetInformationFromFile_ArraysAreSame()
        {
            // Dec
            string Path = @"Resurses\MyTest.json";
            var fileSystem = new MockFileSystem(new Dictionary<string, MockFileData>
            {
                { Path, jsonForTest }
            });
            FileWriterJSON fileWeiter = new FileWriterJSON(fileSystem,Path);

            // Act
            PlaygroundArray arrayJsonSerialization = JsonConvert.DeserializeObject<PlaygroundArray>(jsonForTest);
            PlaygroundArray arrayFunctionTest = (PlaygroundArray)fileWeiter.OpenFileAndGatInformation();

            //Assert
            Assert.Equal(arrayJsonSerialization.NumberOfArrays,
                            arrayFunctionTest.NumberOfArrays);
            Assert.Equal(arrayJsonSerialization.PlaygroundArrays[0].IterationNumber,
                            arrayFunctionTest.PlaygroundArrays[0].IterationNumber);
            Assert.Equal(arrayJsonSerialization.PlaygroundArrays[0].GetNumberOfLivePoints(),
                            arrayFunctionTest.PlaygroundArrays[0].GetNumberOfLivePoints());
            Assert.Equal(arrayJsonSerialization.PlaygroundArrays[0].GetPlaygroundArray(),
                            arrayFunctionTest.PlaygroundArrays[0].GetPlaygroundArray());
        }

        [Fact]
        public void JSON_WriteInformationInFile_SerializateObjectAndSaveIt_JSONSAreSame()
        {
            GameEngine gameEngine = new GameEngine();
            string Path = @"Resurses\MyTest.json";
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
        public void JSON_OpenFileAndGatInformation_FileNotExist_FileNotFoundException()
        {
            string Path = @"Lala.txt";
            var fileSystem = new MockFileSystem();
            IWorkWithFile file = new FileWriterJSON(fileSystem, Path);

            Assert.Throws<FileNotFoundException>(() => file.OpenFileAndGatInformation());
        }

        [Fact]
        public void JSON_CreateSaveDownload_CreateClassSaveItAndDownloadFromFile_True()
        {
            IPlaygroundArray expectedArray = new PlaygroundArray(10, 10, 1);
            string Path = @"Resurses\MyTest.json";
            var fileSystem = new MockFileSystem(new Dictionary<string, MockFileData>
            {
                { Path, "" }
            });
            IWorkWithFile file = new FileWriterJSON(fileSystem, Path);
            
            file.WriteInformationInFile(expectedArray);
            IPlaygroundArray actualArray = file.OpenFileAndGatInformation();

            Assert.Equal(expectedArray.NumberOfArrays,
                            actualArray.NumberOfArrays);
            Assert.Equal(expectedArray.PlaygroundArrays[0].IterationNumber,
                            actualArray.PlaygroundArrays[0].IterationNumber);
            Assert.Equal(expectedArray.PlaygroundArrays[0].GetNumberOfLivePoints(),
                            actualArray.PlaygroundArrays[0].GetNumberOfLivePoints());
            Assert.Equal(expectedArray.PlaygroundArrays[0].GetPlaygroundArray(),
                            actualArray.PlaygroundArrays[0].GetPlaygroundArray());

        }

        #endregion

        #region FileWriterBin_Tests

        [Fact]
        public void Bin_CreateSaveDownload_CreateClassSaveItAndDownloadFromFile_True()
        {
            IPlaygroundArray expectedArray = new PlaygroundArray(10, 10, 1);
            string Path = @"Resurses\MyTest.bin";
            var fileSystem = new MockFileSystem(new Dictionary<string, MockFileData>
            {
                { Path, "" }
            });
            IWorkWithFile file = new FileWriterBin(fileSystem, Path);

            file.WriteInformationInFile(expectedArray);
            IPlaygroundArray actualArray = file.OpenFileAndGatInformation();

            Assert.Equal(expectedArray.NumberOfArrays,
                            actualArray.NumberOfArrays);
            Assert.Equal(expectedArray.PlaygroundArrays[0].IterationNumber,
                            actualArray.PlaygroundArrays[0].IterationNumber);
            Assert.Equal(expectedArray.PlaygroundArrays[0].GetNumberOfLivePoints(),
                            actualArray.PlaygroundArrays[0].GetNumberOfLivePoints());
            Assert.Equal(expectedArray.PlaygroundArrays[0].GetPlaygroundArray(),
                            actualArray.PlaygroundArrays[0].GetPlaygroundArray());

        }

        [Fact]
        public void Bin_OpenFileAndGatInformation_FileNotExist_FileNotFoundException()
        {
            string Path = @"Lala.txt";
            var fileSystem = new MockFileSystem();
            IWorkWithFile file = new FileWriterBin(fileSystem, Path);

            Assert.Throws<FileNotFoundException>(() => file.OpenFileAndGatInformation());
        }

        #endregion

        //[Fact]
        //public void PrepareExsampels()
        //{
        //    GameEngine gameEngine = new GameEngine();
        //    string Path = @"Resurses/MyTest.json";
        //    var playgroundArr = new PlaygroundArray(10, 10, 1);

        //    IWorkWithFile file = new FileWriterJSON(Path);
        //    file.WriteInformationInFile(playgroundArr);
        //}
    }
}
