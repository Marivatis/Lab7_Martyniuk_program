using Lab7_Martyniuk_program;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7_TestProject.Tests
{
    [TestClass]
    public class FileManagerTest
    {
        private MyFile file = new MyFile();

        [TestInitialize]
        public void Initialize() 
        {
            file.Name = "File XX";
            file.Type = FileType.mp4;
            file.Size = 100;
            file.CreationDate = DateTime.Today;
        }

        [TestMethod]
        public void Add_ValidInput()
        {
            // Arramge
            FileManager files = new FileManager(10);

            // Act
            files.Add(file);

            // Assert
            Assert.AreEqual(1, files.Count);
            CollectionAssert.Contains(files, file);
        }

        [TestMethod]
        public void Add_DuplicateInput_ThrowsDuplicateNameException()
        {
            // Arrange
            FileManager files = new FileManager(10);

            // Act
            files.Add(file);

            // Act & Assert
            Assert.ThrowsException<DuplicateNameException> (() => files.Add(file));
        }

        [TestMethod]
        public void Add_CapacityOverflowInput_ThrowsOverflowException()
        {
            // Arrange
            FileManager files = new FileManager(1);

            // Act
            files.Add(file);

            // Act & Assert
            Assert.ThrowsException<OverflowException> (() => files.Add(file, true));
        }

        [TestMethod]
        public void RemoveAt_ValidInput()
        {
            // Arrange
            FileManager files = new FileManager(10);

            // Act
            files.Add(file);
            files.RemoveAt(0);

            // Assert
            Assert.AreEqual(0, files.Count);
            CollectionAssert.DoesNotContain(files, file);
        }

        [TestMethod]
        public void RemoveAt_InvalidIndexInput_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            FileManager files = new FileManager(10);

            // Act & Assert
            Assert.ThrowsException<ArgumentOutOfRangeException> (() => files.RemoveAt(0));
        }

        [TestMethod]
        public void Find_InputName_ReturnsFileInManager()
        {
            // Arrange
            FileManager files = new FileManager(10);
            MyFile file1 = new MyFile { Name = "File 1" };
            MyFile file2 = new MyFile { Name = "File 2" };

            files.Add(file);
            files.Add(file1);
            files.Add(file2);

            // Act
            FileManager result = files.Find("File 1");

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
            CollectionAssert.Contains(result, file1);
        }

        [TestMethod]
        public void Find_InputName_ReturnsAllFilesInManager()
        {
            // Arrange
            FileManager files = new FileManager(10);
            MyFile file1 = new MyFile { Name = "File 1", Type = FileType.docx };
            MyFile file2 = new MyFile { Name = "File 1", Type = FileType.png };

            files.Add(file);
            files.Add(file1);
            files.Add(file2);

            // Act
            FileManager result = files.Find("File 1");

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
            CollectionAssert.Contains(result, file1);
            CollectionAssert.Contains(result, file2);
        }

        [TestMethod]
        public void Find_InputName_ReturnsNull()
        {
            // Arrange
            FileManager files = new FileManager(10);

            files.Add(file);

            // Act
            FileManager result = files.Find("File 1");

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void Find_InputType_ReturnsFileInManager()
        {
            // Arrange
            FileManager files = new FileManager(10);
            MyFile file1 = new MyFile { Type = FileType.flac };
            MyFile file2 = new MyFile { Type = FileType.pdf };

            files.Add(file);
            files.Add(file1);
            files.Add(file2);

            // Act
            FileManager result = files.Find(FileType.flac);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
            CollectionAssert.Contains(result, file1);
        }

        [TestMethod]
        public void Find_InputType_ReturnsAllFilesInManager()
        {
            // Arrange
            FileManager files = new FileManager(10);
            MyFile file1 = new MyFile { Name = "File 21", Type = FileType.png };
            MyFile file2 = new MyFile { Name = "File 12", Type = FileType.png };

            files.Add(file);
            files.Add(file1);
            files.Add(file2);

            // Act
            FileManager result = files.Find(FileType.png);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
            CollectionAssert.Contains(result, file1);
            CollectionAssert.Contains(result, file2);
        }

        [TestMethod]
        public void Find_InputType_ReturnsNull()
        {
            // Arrange
            FileManager files = new FileManager(10);

            files.Add(file);

            // Act
            FileManager result = files.Find(FileType.mp3);

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void Find_InputSize_ReturnsFileInManager()
        {
            // Arrange
            FileManager files = new FileManager(10);
            MyFile file1 = new MyFile { Name = "File 13", Size = 222 };
            MyFile file2 = new MyFile { Name = "File 31", Size = 190 };

            files.Add(file);
            files.Add(file1);
            files.Add(file2);

            // Act
            FileManager result = files.Find(222);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
            CollectionAssert.Contains(result, file1);
        }

        [TestMethod]
        public void Find_InputSize_ReturnsAllFilesInManager()
        {
            // Arrange
            FileManager files = new FileManager(10);
            MyFile file1 = new MyFile { Name = "File 21", Size = 220 };
            MyFile file2 = new MyFile { Name = "File 12", Size = 220 };

            files.Add(file);
            files.Add(file1);
            files.Add(file2);

            // Act
            FileManager result = files.Find(220);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
            CollectionAssert.Contains(result, file1);
            CollectionAssert.Contains(result, file2);
        }

        [TestMethod]
        public void Find_InputSize_ReturnsNull()
        {
            // Arrange
            FileManager files = new FileManager(10);

            files.Add(file);

            // Act
            FileManager result = files.Find(111);

            // Assert
            Assert.IsNull(result);
        }
    }
}
