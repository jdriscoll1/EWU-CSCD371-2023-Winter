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
            new Program().WriteLine(expected);

            // Assert
            Assert.AreEqual<string>(expected, stringWriter.ToString().Trim());
        }

        [TestMethod]
        public void TestReadLine()
        {
            // Arrange
            string? testString = "string";
            using StringReader stringReader = new(testString);
            Console.SetIn(stringReader);


            // Act
            string? input = new Program().ReadLine(); 

            // Assert
            Assert.AreEqual<string?>(testString, input);

        }

        [TestMethod]
        public void TestCalculateWithProgram() { 
            Program program = new();
            using StringWriter stringWriter = new();
            Console.SetOut(stringWriter);
            string? userInput = "2 + 2";

            // Arrange
            using StringReader stringReader = new(userInput);
            Console.SetIn(stringReader);
            string expected = "The result of the following equation: 2 + 2 is 4";



            userInput = program.ReadLine();
             
            int? result = Calculator<int>.TryCalculate(userInput!);
                
             
            program.WriteLine($"The result of the following equation: {userInput} is {result}");
            Assert.AreEqual<string>(expected, stringWriter.ToString().Trim()); 


        }

    }
}
