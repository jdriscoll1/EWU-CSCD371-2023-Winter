using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO; 

namespace Logger.Tests
{
    [TestClass]
    public class FileLoggerTests
    {

        string filePath = "./"; 
      
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
            string actual = new StreamReader(fileName).ReadLine()!;

            // Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestFileLogger_AppendsProperly_ReturnTrueIfTwoLinesAppend() {
            // Arrange
            string fileName = String.Format("{0}\\TestFileLogger_AppendsProperly_ReturnTrueIfTwoLinesAppend", filePath);

            // Arrange
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }

            FileStream fs = File.Create(fileName);

            fs.Close();


            FileLogger fileLogger = new FileLogger(fileName);
            
            string message1 = "This is a test warning, please remain calm";
            
            string message2 = "This is a second test warning, please remain calm";

            // Act
            fileLogger.Log(LogLevel.Warning, message1);
            fileLogger.Log(LogLevel.Warning, message2);

            string expected1 = $"{DateTime.Now} FileLoggerTests Warning: {message1}";

            string expected2 = $"{DateTime.Now} FileLoggerTests Warning: {message2}";

            // Assert
            StreamReader streamReader = new StreamReader(fileName);
            string actual1 = streamReader.ReadLine()!;
            string actual2 = streamReader.ReadLine()!; 


            // Assert
            Assert.AreEqual(expected1, actual1);
            Assert.AreEqual(expected2, actual2);


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
