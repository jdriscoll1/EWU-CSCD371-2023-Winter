
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Logger.Tests
{
    [TestClass]
    public class BaseLoggerMixinsTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Error_WithNullLogger_ThrowsException()
        {
            // Arrange
            ArgumentNullException exception = null!;

            // Act
            try
            {
                BaseLoggerMixins.Error(null, "");
            }
            catch (ArgumentNullException ex) {
                throw new ArgumentNullException(); 
            }
            // Assert
            Assert.IsNotNull(exception);
        }/*
        public void Model_GivenNull_ThrowsException()
        {
            // Assert
            Vehicle vehicle = new();
            ArgumentNullException expectedException = null!;

            // Act
            try
            {
                vehicle.Model = null;
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("Model", ex.ParamName);
            }

            Assert.IsNotNull(expectedException);

        }
        */
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
