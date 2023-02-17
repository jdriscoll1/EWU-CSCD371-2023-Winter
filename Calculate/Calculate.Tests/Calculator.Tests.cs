using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Calculate.Tests
{
    [TestClass]
    public class CalculatorTests
    {
        [TestMethod]
        public void TestAdd()
        {
            Assert.AreEqual<int>(Calculator<int>.Add(1, 1), 2);
        }
        [TestMethod]
        public void TestSubtract()
        {
            Assert.AreEqual<int>(Calculator<int>.Subtract(2, 1), 1);
        }

        [TestMethod]
        public void TestMultiply()
        {
            Assert.AreEqual<int>(Calculator<int>.Multiply(2, 2), 4);
        }

        [TestMethod]
        public void TestDivide()
        {
            Assert.AreEqual<int>(Calculator<int>.Divide(2, 1), 2);
        }

        [TestMethod]
        public void ValidateThatDictionaryProperlyReturnsLambdaFunction()
        {
            Assert.AreEqual<Func<int, int, int>>(Calculator<int>.Subtract, Calculator<int>.mathematicalOperations['-']);
            Assert.AreEqual<Func<int, int, int>>(Calculator<int>.Add, Calculator<int>.mathematicalOperations['+']);
            Assert.AreEqual<Func<int, int, int>>(Calculator<int>.Multiply, Calculator<int>.mathematicalOperations['*']);
            Assert.AreEqual<Func<int, int, int>>(Calculator<int>.Divide, Calculator<int>.mathematicalOperations['/']);

        }

        [TestMethod]
        public void ParsingEquationTestTrueCase()
        {
            // Arrange
            string equation = "2 + 2";
            int? expected = 4;

            // Act
            int? actual = Calculator<int>.TryCalculate(equation);

            // Assert
            Assert.AreEqual<int?>(actual, expected); 
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void ParsingEquationTestFalseCase()
        {
            Calculator<int>.TryCalculate("I am John");

        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void ParsingEquationTestFalseCase2()
        {
            Calculator<int>.TryCalculate("IamJohn");

        }

        [TestMethod]
        public void GenericCalculateTest()
        {
            Assert.AreEqual<double>(2.5, Calculator<double>.TryCalculate(".5 + 2"));

        }
    }
}