using Lab7_Martyniuk_program;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lab7_TestProject.Tests
{
    [TestClass]
    public class MyFileTest
    {
        private string? fileInfo;

        [TestInitialize]
        public void ParseAndTryParse_ValidInput_TestInitialize()
        {
            // Arrange
            fileInfo = "New File 1 | jpeg | 537 | 09.12.2013";
        }

        [TestMethod]
        public void Parse_ValidInput_ReturnsMyFile()
        {
            // Act
            MyFile result = MyFile.Parse(fileInfo);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("New File 1", result.Name);
            Assert.AreEqual(FileType.jpeg, result.Type);
            Assert.AreEqual(537, result.Size);
            Assert.AreEqual(new DateTime(2013, 12, 09), result.CreationDate);
        }

        [TestMethod]
        public void Parse_NullInput_ThrowsNullReferenceException()
        {
            // Arrange
            string? input = null;

            // Act & Assert
            Assert.ThrowsException<NullReferenceException>(() => MyFile.Parse(input));
        }

        [TestMethod]
        public void Parse_InvalidInputFormat_ThrowsFormatException()
        {
            // Arrange
            string input = "Invalid Input";

            // Act & Assert
            Assert.ThrowsException<FormatException>(() => MyFile.Parse(input));
        }

        [TestMethod]
        public void Parse_InvalidName_ThrowsFormatException()
        {
            // Arrange
            string input = "New_File_1 | jpeg | 537 | 09.12.2013";

            // Act & Assert
            Assert.ThrowsException<FormatException>(() => MyFile.Parse(input));
        }

        [TestMethod]
        public void Parse_InvalidType_ThrowsArgumentException()
        {
            // Arrange
            string input = "New File 1 | cpp | 537 | 09.12.2013";

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => MyFile.Parse(input));
        }

        [TestMethod]
        public void Parse_InvalidSize_ThrowsOverflowException()
        {
            // Arrange
            string input = "New File 1 | jpeg | 2000 | 09.12.2013";

            // Act & Assert
            Assert.ThrowsException<OverflowException>(() => MyFile.Parse(input));
        }

        [TestMethod]
        public void Parse_InvalidDateFormat_ThrowsFormatException()
        {
            // Arrange
            string input = "New File 1 | jpeg | 537 | 09-12-2013";

            // Act & Assert
            Assert.ThrowsException<FormatException>(() => MyFile.Parse(input));
        }

        [TestMethod]
        public void TryParse_ValidInput_ReturnsMyFile()
        {
            // Arrange

            //Act
            bool result = MyFile.TryParse(fileInfo, out MyFile file);

            //Assert
            Assert.IsNotNull(file);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TryParse_InvalidInput_ReturnsFalse()
        {
            // Arrange 
            string input = "Invalid input";

            // Act 
            bool result = MyFile.TryParse(input, out MyFile file);

            // Assert
            Assert.IsFalse(result);
            Assert.IsNull(file);
        }

        [TestMethod]
        public void ToString_ValidFormat()
        {
            // Arrange
            MyFile file = new MyFile("File 1", FileType.jpeg, 123, new DateTime(2023, 07, 17));

            // Act
            string result = file.ToString();
            string expected = "File 1 | jpeg | 123  | 17.07.2023";

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}