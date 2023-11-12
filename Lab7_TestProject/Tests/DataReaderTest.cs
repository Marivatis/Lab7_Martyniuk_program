using Lab7_Martyniuk_program;

namespace Lab7_TestProject.Tests
{
    [TestClass]
    public class DataReaderTest
    {
        string? folderPath;
        FileManager expectedFileManager;

        [TestInitialize]
        public void TestInitialize()
        {
            folderPath = "D:\\Работы ВУЗ\\Курс 2.1\\ООП\\ЛР 7\\Tests Saved Files\\";

            expectedFileManager = new FileManager(10)
            {
                new MyFile("File 88", FileType.docx, 124, new DateTime(2006, 03, 31)),
                new MyFile("File 71", FileType.png, 695, new DateTime(2004, 11, 02))
            };
        }

        [TestMethod]
        public void ReadFromJsonFile_ValidFileInfo() 
        {
            // Arrange
            FileManager fileManager = new FileManager(10);

            string path = folderPath + "Test File Valid Info.json";

            // Act
            DataReader.ReadFromJsonFile(path, ref fileManager);

            // Assert
            Assert.AreEqual(2, fileManager.Count);
            Assert.AreEqual(expectedFileManager[0].GetHashCode(), fileManager[0].GetHashCode());
        }

        [TestMethod]
        public void ReadFromJsonFile_InvalidFileInfo() 
        {
            // Arrange
            FileManager fileManager = new FileManager(10);

            string path = folderPath + "Test File Invalid Info.json";

            // Act
            DataReader.ReadFromJsonFile(path, ref fileManager);

            // Assert
            Assert.AreEqual(0, fileManager.Count);
        }

        [TestMethod]
        public void ReadFromJsonFile_EmptyFileInfo()
        {
            // Arrange
            FileManager fileManager = new FileManager(10);

            string path = folderPath + "Test File Empty.json";

            // Act
            DataReader.ReadFromJsonFile(path, ref fileManager);

            // Assert
            Assert.AreEqual(0, fileManager.Count);
        }

        [TestMethod]
        public void ReadFromCsvFile_ValidFileInfo()
        {
            // Arrange
            FileManager fileManager = new FileManager(10);

            string path = folderPath + "Test File Valid Info.csv";

            // Act
            DataReader.ReadFromCsvFile(path, ref fileManager);

            // Assert
            Assert.AreEqual(2, fileManager.Count);
            Assert.AreEqual(expectedFileManager[0].GetHashCode(), fileManager[0].GetHashCode());
        }

        [TestMethod]
        public void ReadFromCsvFile_InvalidFileInfo()
        {
            // Arrange
            FileManager fileManager = new FileManager(10);

            string path = folderPath + "Test File Invalid Info.csv";

            // Act
            DataReader.ReadFromCsvFile(path, ref fileManager);

            // Assert
            Assert.AreEqual(0, fileManager.Count);
        }

        [TestMethod]
        public void ReadFromCsvFile_EmptyFileInfo()
        {
            // Arrange
            FileManager fileManager = new FileManager(10);

            string path = folderPath + "Test File Empty.csv";

            // Act
            DataReader.ReadFromCsvFile(path, ref fileManager);

            // Assert
            Assert.AreEqual(0, fileManager.Count);
        }
    }
}
