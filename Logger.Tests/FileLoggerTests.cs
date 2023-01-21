using Microsoft.VisualStudio.TestPlatform.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO; 

namespace Logger.Tests
{
    [TestClass]
    public class FileLoggerTests
    {

        string filePath = "C:\\Users\\Jordan\\test-folder\\School\\Classes\\371.2\\"; 
      
        [TestMethod]
        public void TestLogLevel_ReturnTrueIfMessageOutputsProperly()
        {
            string fileName = String.Format("{0}\\TestLogLevel_ReturnTrueIfMessageOutputsProperly.txt", filePath);

            // Arrange
            if (File.Exists(fileName)) {
                File.Delete(fileName);
            }

            FileStream fs = File.Create(fileName);

            fs.Close();


            FileLogger fileLogger = new FileLogger(fileName);
            string message = "This is a test warning, please remain calm"; 


            // Act
            fileLogger.Log(LogLevel.Warning, message);
            
            string expected = $"{DateTime.Now} FileLoggerTests Warning: {message}";

            // Open the file 
            string actual = new StreamReader(fileName).ReadLine();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestClassName_ReturnTrueIfGetClassNameReturnsFileLogger() 
        {
            // Arrange
            string className = "FileLogger";
            
            LogFactory logFactory = new LogFactory();


            // Act
            logFactory.ConfigureFileLogger(filePath);

            FileLogger fileLogger = (FileLogger)logFactory.CreateLogger(className);


            // Assert
            Assert.AreEqual(fileLogger.GetClassName(), className);


        }

}
}
