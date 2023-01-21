
using Microsoft.VisualBasic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace Logger.Tests
{
    [TestClass]
    public class BaseLoggerMixinsTests
    {

        string filePath = "C:\\Users\\Jordan\\test-folder\\School\\Classes\\371.2\\log.txt";


        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Error_WithNullLogger_ThrowsException()
        {
            // Arrange
            ArgumentNullException exception = null!;

            // Act
            try
            {
                BaseLoggerMixins.Error(null, 0);
            }
            catch (ArgumentNullException ex) {
                throw ex; 
            }
            // Assert
            Assert.IsNotNull(exception);
        }


        [TestMethod]
        public void Error_WithData_LogsMessage()
        {
            // Arrange
            var logger = new TestLogger();

            // Act
            logger.Error("Message {0}", 42);

            // Assert
            Assert.AreEqual(1, logger.LoggedMessages.Count);
            Assert.AreEqual(LogLevel.Error, logger.LoggedMessages[0].LogLevel);
            Assert.AreEqual("Message 42", logger.LoggedMessages[0].Message);
        }

        [TestMethod]
        public void Error_WithData_UseMixins_ReturnTrueIfLogsErrorIntoFile()
        {
            // Arrange     
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            FileStream fs = File.Create(filePath);

            fs.Close();

            string message = "Message {0}";

            int error = 42;


            // Act
            BaseLoggerMixins.Error(message, error);

            // Assert
            string expected = $"{DateTime.Now} BaseLoggerMixins Error: Message 42"; 
            string actual = new StreamReader(filePath).ReadLine();
            Assert.AreEqual(expected, actual); 


        }

    }

    public class TestLogger : BaseLogger
    {
        public List<(LogLevel LogLevel, string Message)> LoggedMessages { get; } = new List<(LogLevel, string)>();

        public override void Log(LogLevel logLevel, string message)
        {
            LoggedMessages.Add((logLevel, message));
        }

        internal void Error(string msg, int id)
        {
            Log(LogLevel.Error, String.Format(msg, id)); 
        }
    }
}
