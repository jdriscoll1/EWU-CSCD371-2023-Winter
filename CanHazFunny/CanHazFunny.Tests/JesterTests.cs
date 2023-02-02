using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using Moq; 

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
        public void TestJesterMethodReturnTrueIfThrowsNullException() {
            // Arrange
            ArgumentNullException exception = null!; 

            // Act
            try
            {
                Jester jester = new(null!, null!);
                jester.JokeOutput = null!;

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
            Assert.IsNotNull(stringWriter);
            Assert.IsNotNull(stringWriter.ToString());

        }
        [TestMethod]
        public void TestIfJokeReturnsChuckNorris()
        {
            // Arrange
            Mock<IJokeService> jokeServiceMock = new();

            JokeService jokeService = new();

            jokeServiceMock.SetupSequence(jokeService => jokeService.GetJoke()).Returns("Chuck Norris Joke").Returns("Funny Joke");

            Jester jester = new(new JokeOutput(), jokeServiceMock.Object);

            using StringWriter stringWriter = new();
            Console.SetOut(stringWriter);

            // Act
            jester.TellJoke();

            // Assert
            Assert.AreEqual("Funny Joke", stringWriter.ToString().Trim());

        }

        
        
    }


}
