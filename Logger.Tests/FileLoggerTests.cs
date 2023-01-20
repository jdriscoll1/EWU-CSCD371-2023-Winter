using Microsoft.VisualStudio.TestPlatform.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO; 

namespace Logger.Tests
{
    [TestClass]
    public class FileLoggerTests
    {

        string filePath = "C:\\Users\\Jordan\\test-folder\\School\\Classes\\371.2\\log.txt"; 
      
        [TestMethod]
        public void TestLogLevel_ReturnTrueIfMessageOutputsProperly()
        {
            // Arrange
            if (File.Exists(filePath)) {
                File.Delete(filePath);
            }

            FileStream fs = File.Create(filePath);

            fs.Close(); 


            FileLogger fileLogger = new FileLogger(filePath);
            string message = "This is a test warning, please remain calm"; 


            // Act
            fileLogger.Log(LogLevel.Warning, message);
            
            string expected = $"{DateTime.Now} FileLoggerTests Warning: {message}";

            // Open the file 
            string actual = new StreamReader(filePath).ReadLine();

            // Assert
            Assert.AreEqual(expected, actual);
        }

}
}
