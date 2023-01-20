using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace Logger.Tests
{

     
    [TestClass]
    public class LogFactoryTests
    {

        string filePath = "C:\\Users\\Jordan\\test-folder\\School\\Classes\\371.2\\log.txt";


        // Check to see if it has a name 
        [TestMethod]
        public void SetClassName()
        {
            // Arrange
            LogFactory factory = new LogFactory();

            // Act
            factory.setFactoryName("FactoryName"); 

            // Assert
            Assert.AreEqual("FactoryName", factory.getFactoryName());
        }


        [TestMethod]
        public void TestFileLoggerCreation_TrueIfNotNull()
        {
            // Arrange
            LogFactory factory = new LogFactory();
            factory.ConfigureFileLogger(filePath);

            // Act
            FileLogger fileLogger = (FileLogger)factory.CreateLogger("FileLogger");

            // Assert
            Assert.IsNotNull(fileLogger);
        }

        [TestMethod]
        public void TestConfigureFileLogger_TrueIfPathGetsSet()
        {
            // Arrange
            LogFactory factory = new LogFactory();
            factory.CreateLogger("FileLogger");

            // Act
            factory.ConfigureFileLogger(filePath);


            // Assert
            Assert.AreEqual(filePath, factory.GetFileLoggerPath()); 
            

        }

        [TestMethod]
        public void TestCreateLogger_SucceedIfReturnsNullWithEmptyFilePath()
        {
            // Arrange
            LogFactory factory = new LogFactory();


            // Act
            FileLogger fileLogger = (FileLogger)factory.CreateLogger("FileLogger");

            // Assert
            Assert.IsNull(factory.GetFileLoggerPath());
            Assert.IsNull(fileLogger);

        }
    }
}
