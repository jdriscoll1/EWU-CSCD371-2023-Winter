
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

        string filePath = "./";


        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Error_WithNullLogger_ThrowsException()
        {
            // Arrange
            ArgumentNullException exception = null!;

            // Act
            try
            {
                BaseLoggerMixins.Error(null!, null!);
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
            string fileName = String.Format("{0}\\Error_WithData_UseMixins_ReturnTrueIfLogsErrorIntoFile", filePath);
         
            // Arrange     
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }

            FileStream fs = File.Create(fileName);

            fs.Close();
            
            LogFactory logFactory = new();
            logFactory.ConfigureFileLogger(fileName);
            
            FileLogger fileLogger = (FileLogger)logFactory.CreateLogger(nameof(BaseLoggerMixinsTests), "FileLogger");
            
            string message = "Message {0}";

            string error = "42";
            

             // Act
             fileLogger.Error(message, error);
            

             // Assert
             string expected = $"{DateTime.Now} BaseLoggerMixinsTests Error: Message 42";
            StreamReader sr = new StreamReader(fileName); 

             string actual = sr.ReadLine()!;
             sr.Close(); 
             Assert.AreEqual(expected, actual);
      
             File.Delete(fileName);


        }



        [TestMethod]
        public void Warning_WithData_UseMixins_ReturnTrueIfLogsWarningIntoFile()
        {
            string fileName = String.Format("{0}\\Warning_WithData_UseMixins_ReturnTrueIfLogsWarningIntoFile", filePath);

            // Arrange     
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }

            FileStream fs = File.Create(fileName);

            fs.Close();

            LogFactory logFactory = new LogFactory();
            logFactory.ConfigureFileLogger(fileName);
            FileLogger fileLogger = (FileLogger)logFactory.CreateLogger(nameof(BaseLoggerMixinsTests), "FileLogger");

            string message = "Message {0}";

            string warning = "42";


            // Act
            fileLogger.Warning(message, warning);

            // Assert
            string expected = $"{DateTime.Now} BaseLoggerMixinsTests Warning: Message 42";
            StreamReader sr = new StreamReader(fileName);
            string actual = sr.ReadLine()!;
            sr.Close();
            Assert.AreEqual(expected, actual);

            File.Delete(fileName);


        }

        [TestMethod]
        public void Information_WithData_UseMixins_ReturnTrueIfLogsInformationIntoFile()
        {
            string fileName = String.Format("{0}\\Information_WithData_UseMixins_ReturnTrueIfLogsInformationIntoFile", filePath);

            // Arrange     
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }

            FileStream fs = File.Create(fileName);

            fs.Close();

            LogFactory logFactory = new LogFactory();
            logFactory.ConfigureFileLogger(fileName);
            FileLogger fileLogger = (FileLogger)logFactory.CreateLogger(nameof(BaseLoggerMixinsTests), "FileLogger");

            string message = "Message {0}";

            string information = "42";


            // Act
            fileLogger.Information(message, information);

            // Assert
            string expected = $"{DateTime.Now} BaseLoggerMixinsTests Information: Message 42";
            StreamReader sr = new StreamReader(fileName);
            string actual = sr.ReadLine()!;
            sr.Close();
            Assert.AreEqual(expected, actual);

            File.Delete(fileName);


        }


        [TestMethod]
        public void Debug_WithData_UseMixins_ReturnTrueIfLogsDebugIntoFile()
        {
            string fileName = String.Format("{0}\\Debug_WithData_UseMixins_ReturnTrueIfLogsDebugIntoFile", filePath);

            // Arrange     
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }

            FileStream fs = File.Create(fileName);

            fs.Close();

            LogFactory logFactory = new LogFactory();
            logFactory.ConfigureFileLogger(fileName);
            FileLogger fileLogger = (FileLogger)logFactory.CreateLogger(nameof(BaseLoggerMixinsTests), "FileLogger");

            string message = "Message {0}";

            string debug = "42";


            // Act
            fileLogger.Debug(message, debug);

            // Assert
            string expected = $"{DateTime.Now} BaseLoggerMixinsTests Debug: Message 42";
            StreamReader sr = new StreamReader(fileName);
            string actual = sr.ReadLine()!;
            sr.Close();
            Assert.AreEqual(expected, actual);

            File.Delete(fileName);


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
