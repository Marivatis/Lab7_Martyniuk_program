using Lab7_Martyniuk_program;

namespace Lab7_TestProject.Tests
{
    [TestClass]
    public class DataWriterTest
    {
        string? folderPath;

        [TestInitialize]
        public void TestInitialize()
        {
            folderPath = "D:\\Работы ВУЗ\\Курс 2.1\\ООП\\ЛР 7\\Tests Saved Files\\";
        }

        [TestMethod]
        public void WriteToJsonFile_Success()
        {
            // Arrange
            FileManager fileManager = new FileManager(10);

            fileManager.Add(fileManager.CreateRandomly());
            fileManager.Add(fileManager.CreateRandomly());

            string path = folderPath + "Test File 1.json";

            // Act
            bool result = DataWriter.WriteToJsonFile(fileManager, path);

            // Assert
            Assert.IsTrue(result);
            Assert.IsTrue(File.Exists(path));

            // Clean up
            File.Delete(path);
        }

        [TestMethod]
        public void WriteToJsonFile_RewritingFile()
        {
            // Arrange
            FileManager fileManager = new FileManager(10);

            fileManager.Add(fileManager.CreateRandomly());
            fileManager.Add(fileManager.CreateRandomly());

            string path = folderPath + "Test File 1.json";

            // Act
            bool result = DataWriter.WriteToJsonFile(fileManager, path);

            // Assert
            Assert.IsTrue(result);
            Assert.IsTrue(File.Exists(path));

            // Act
            result = DataWriter.WriteToJsonFile(fileManager, path);

            // Assert
            Assert.IsTrue(result);
            Assert.IsTrue(File.Exists(path));

            // Clean up
            File.Delete(path);
        }

        [TestMethod]
        public void WriteToJsonFile_EmptyFileManager()
        {
            // Arrange
            FileManager fileManager = new FileManager(10);
            
            string path = folderPath + "Test File 1.json";

            // Act
            bool result = DataWriter.WriteToJsonFile(fileManager, path);

            // Assert
            Assert.IsFalse(result);
            Assert.IsFalse(File.Exists(path));
        }                

        [TestMethod]
        public void WriteToJsonFile_NullFileManager() 
        {
            // Arragne
            string path = folderPath + "Test File 1.json";

            // Act
            bool result = DataWriter.WriteToJsonFile(null, path);

            // Assert
            Assert.IsFalse(result);
            Assert.IsFalse(File.Exists(path));
        }

        [TestMethod]
        public void WriteToCsvFile_Success()
        {
            // Arrange
            FileManager fileManager = new FileManager(10);

            fileManager.Add(fileManager.CreateRandomly());
            fileManager.Add(fileManager.CreateRandomly());

            string path = folderPath + "Test File 2.csv";

            // Act
            bool result = DataWriter.WriteToCsvFile(fileManager, path);

            // Assert
            Assert.IsTrue(result);
            Assert.IsTrue(File.Exists(path));

            // Clean up
            File.Delete(path);
        }

        [TestMethod]
        public void WriteToCsvFile_RewritingFile()
        {
            // Arrange
            FileManager fileManager = new FileManager(10);

            fileManager.Add(fileManager.CreateRandomly());
            fileManager.Add(fileManager.CreateRandomly());

            string path = folderPath + "Test File 2.csv";

            // Act
            bool result = DataWriter.WriteToCsvFile(fileManager, path);

            // Assert
            Assert.IsTrue(result);
            Assert.IsTrue(File.Exists(path));

            // Act
            result = DataWriter.WriteToCsvFile(fileManager, path);

            // Assert
            Assert.IsTrue(result);
            Assert.IsTrue(File.Exists(path));

            // Clean up
            File.Delete(path);
        }

        [TestMethod]
        public void WriteToCsvFile_EmptyFileManager()
        {
            // Arrange
            FileManager fileManager = new FileManager(10);

            string path = folderPath + "Test File 2.csv";

            // Act
            bool result = DataWriter.WriteToCsvFile(fileManager, path);

            // Assert
            Assert.IsFalse(result);
            Assert.IsFalse(File.Exists(path));
        }

        [TestMethod]
        public void WriteToCsvFile_NullFileManager()
        {
            // Arragne
            string path = folderPath + "Test File 2.csv";

            // Act
            bool result = DataWriter.WriteToCsvFile(null, path);

            // Assert
            Assert.IsFalse(result);
            Assert.IsFalse(File.Exists(path));
        }
    }
}

