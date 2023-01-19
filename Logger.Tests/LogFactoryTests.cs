using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Logger.Tests
{
    [TestClass]
    public class LogFactoryTests
    {
        // Check to see if it has a name 
        [TestMethod]
        public void SetClassName()
        {
            // Arrange
            LogFactory factory = new LogFactory();
            string factoryName = "FactoryName"; 
            // Act
            factory.factoryName = factoryName;

            // Assert
            Assert.AreEqual(factoryName, factory.factoryName);
        }
        
    }
}
