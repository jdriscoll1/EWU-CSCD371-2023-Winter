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
        [ExpectedException(typeof(System.ArgumentNullException))]
        public void TestJesterDependencyNullabilityReturnTrueIfNullExceptionThrown()
        {
            new Jester(null!, null!);

            

        }

        [TestMethod]
        public void TestIfJokeWritesToCLI() {
            // Arrange
            Mock<IJokeService> jokeServiceMock = new();

            JokeService jokeService = new();

            jokeServiceMock.SetupSequence(jokeService => jokeService.GetJoke()).Returns("Funny Joke");

            Jester jester = new(new JokeOutput(), jokeServiceMock.Object);

            using StringWriter stringWriter = new();

            Console.SetOut(stringWriter);

            // Act
            jester.TellJoke();

            // Assert
            Assert.AreEqual<string>("Funny Joke", stringWriter.ToString().Trim());


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
            Assert.AreEqual<string>("Funny Joke", stringWriter.ToString().Trim());

        }

        
        
    }


}
