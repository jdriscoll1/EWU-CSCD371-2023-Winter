using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Calculate.Tests
{
    [TestClass]
    public class CalculatorTests
    {
        [TestMethod]
        public void TestAdd()
        {
            Assert.AreEqual<int>(Calculator.Add(1, 1), 2);
        }
        [TestMethod]
        public void TestSubtract()
        {
            Assert.AreEqual<int>(Calculator.Subtract(2, 1), 1);
        }

        [TestMethod]
        public void TestMultiply()
        {
            Assert.AreEqual<int>(Calculator.Multiply(2, 2), 4);
        }

        [TestMethod]
        public void TestDivide()
        {
            Assert.AreEqual<int>(Calculator.Divide(2, 1), 2);
        }

        [TestMethod]
        public void ValidateThatDictionaryProperlyReturnsLambdaFunction()
        {
            Assert.AreEqual<Func<int, int, int>>(Calculator.Subtract, Calculator.mathematicalOperations['-']);
            Assert.AreEqual<Func<int, int, int>>(Calculator.Add, Calculator.mathematicalOperations['+']);
            Assert.AreEqual<Func<int, int, int>>(Calculator.Multiply, Calculator.mathematicalOperations['*']);
            Assert.AreEqual<Func<int, int, int>>(Calculator.Divide, Calculator.mathematicalOperations['/']);

        }

        [TestMethod]
        public void ParsingEquationTestTrueCase()
        {
            // Arrange
            string equation = "2 + 2";
            int? expected = 4;

            // Act
            int? actual = Calculator.TryCalculate(equation);

            // Assert
            Assert.AreEqual<int?>(actual, expected); 
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void ParsingEquationTestFalseCase()
        {
            Calculator.TryCalculate("I am John");

        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void ParsingEquationTestFalseCase2()
        {
            Calculator.TryCalculate("IamJohn");

        }
    }
}