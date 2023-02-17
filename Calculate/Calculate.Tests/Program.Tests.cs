using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculate.Tests
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void TestWriteLine()
        {
            // Arrange
            using StringWriter stringWriter = new();
            Console.SetOut(stringWriter);
            string expected = "str";

            // Act
            Program.WriteLine(expected);

            // Assert
            Assert.AreEqual<string>(expected, stringWriter.ToString().Trim());
        }

        [TestMethod]
        public void TestReadLine()
        {
            // Arrange
            string testString = "string";
            using StringReader stringReader = new(testString);
            Console.SetIn(stringReader);


            // Act
            string? input = Program.ReadLine(); 

            // Assert
            Assert.AreEqual<string>(testString, input!);

        }

    }
}
