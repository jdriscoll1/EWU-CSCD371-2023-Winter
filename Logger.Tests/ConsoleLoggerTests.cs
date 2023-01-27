using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Logger.Tests
{
    [TestClass]
    public class ConsoleLoggerTests
    {

        [TestMethod]
        public void TestClassName_ReturnTrueIfGetClassNameReturnsConsoleLogger()
        {
            // Arrange
            string className = "ConsoleLogger";

            LogFactory logFactory = new();

            ConsoleLogger consoleLogger = (ConsoleLogger)logFactory.CreateLogger(nameof(ConsoleLoggerTests), className);


            // Assert
            Assert.AreEqual(consoleLogger.GetClassName(), className);


        }
        [TestMethod]
        public void TestWriteToConsoleReturnTrueIfConsoleIsWrittenTo()
        {
            // Arrange
            string className = "ConsoleLogger";

            LogFactory logFactory = new();

            ConsoleLogger consoleLogger = (ConsoleLogger)logFactory.CreateLogger(nameof(ConsoleLoggerTests), className);

            
            // Act

            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            consoleLogger.Log(LogLevel.Error, "Test Error");
            

            // Assert
            string expected = $"{DateTime.Now} ConsoleLoggerTests Error: Test Error";
            Assert.AreEqual(stringWriter.ToString().Trim(), expected);
            
        }

        [TestMethod]
        public void TestIfMixinsWorksWithConsole()
        {
            // Arrange
            string className = "ConsoleLogger";

            LogFactory logFactory = new();

            ConsoleLogger consoleLogger = (ConsoleLogger)logFactory.CreateLogger(nameof(ConsoleLoggerTests), className);


            // Act

            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            consoleLogger.Error("{0}", "Test Error");


            // Assert
            string expected = $"{DateTime.Now} ConsoleLoggerTests Error: Test Error";
            Assert.AreEqual(stringWriter.ToString().Trim(), expected);
        }
    }
}
