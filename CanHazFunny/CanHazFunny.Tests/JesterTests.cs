using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

[assembly: CLSCompliant(true)]
namespace CanHazFunny.Tests
{
    [TestClass]
    public class JesterTests
    {
        [TestMethod]
        public void InstantiateJesterReturnTrueIfProperlyCreated()
        {
            // Arrange
            Jester jester = new(new JokeOutput(), new JokeService());

            // Assert
            Assert.IsInstanceOfType(jester, typeof(Jester));   
            
        


        }

        [TestMethod]
        public void TestTellJokeReturnTrueIfStringReturned()
        {
            // Arrange
            Jester jester = new Jester(new JokeOutput(), new JokeService());

            // Act
            string joke = jester.GetJoke();
            // Assert
            Assert.IsNotNull(joke);
            
        }

        [TestMethod]
        public void TestContainsChuckNorrisReturnTrueIfContainsChecksProperly()
        {
            // Arrange
            bool joke1 = Jester.ContainsChuckNorris("There is no chin behind Chuck Norris' beard. There is only another fist.\n");
            bool joke2 = !Jester.ContainsChuckNorris("Yo momma's so poor she opend a Gmail account just so she could eat the spam \n");
            bool joke3 = Jester.ContainsChuckNorris("chUCk nORRiS");

            // Assert
            Assert.IsTrue(joke1);
            Assert.IsTrue(joke2);
            Assert.IsTrue(joke3);
            

        }
        [TestMethod]
        public void TestJesterMethodReturnTrueIfThrowsNullException() {
            // Arrange
            ArgumentNullException exception = null!; 

            // Act
            try
            {
                Jester jester = new(null!, null!);
            }
            catch (ArgumentNullException ex) {
                exception = ex; 
            }

            // Assert
            Assert.IsNotNull(exception); 

        }

        [TestMethod]
        public void TestCLIOutput()
        {
            // Arrange
            Jester jester = new (new JokeOutput(), new JokeService());
            using StringWriter stringWriter = new();
            Console.SetOut(stringWriter);

            // Act
            jester.TellJoke();

            // Assert
            Assert.IsNotNull(stringWriter.ToString());

        }
    }

}
