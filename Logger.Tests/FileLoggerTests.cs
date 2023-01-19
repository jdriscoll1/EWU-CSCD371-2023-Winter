using Microsoft.VisualStudio.TestPlatform.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Logger.Tests
{
    [TestClass]
    public class FileLoggerTests
    {
        [TestMethod]
        public void TestInstantiateFileLogger()
        {
            // Arrange
            FileLogger logger;
            string filePath= "C:\\Users\\Jordan\\test-folder\\School\\Classes\\371.2\\txt.log";
            // Act
            logger = new FileLogger(filePath);


            // Assert
            Assert.IsInstanceOfType(logger, typeof(FileLogger)); 


        }

        public void TestInsertDateTimeIntoLoggerObject() {
            // Arrange
            FileLogger logger;
            string filePath = "C:\\Users\\Jordan\\test-folder\\School\\Classes\\371.2\\txt.log";
            logger = new FileLogger(filePath);

            // Act
            DateTime dateTime = new DateTime();


            // Assert
            Assert.AreEqual(dateTime, logger.DateTime);

        }
        
    }
}
