using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CanHazFunny.Tests
{
    [TestClass]
    public class JesterTests
    {
        [TestMethod]
        public void Instantiate_Jester_ReturnTrueIfProperlyCreated()
        {
            // Arrange
            Jester jester = new Jester(new JokeOutput(), new JokeService());

            // Assert
            Assert.IsInstanceOfType(jester, typeof(Jester));   
            
        


        }

        [TestMethod]
        public void TestTellJoke_ReturnTrueIfStringReturned()
        {
            // Arrange
            Jester jester = new Jester(new JokeOutput(), new JokeService());

            // Act
            string joke = jester.GetJoke();
            // Assert
            Assert.IsNotNull(joke);
            
        }

        [TestMethod]
        public void TestContainsChuckNorris_DoesNotReturnChuckNorris()
        {
            // Arrange
            Jester jester = new Jester(new JokeOutput(), new JokeService());

            // Act
            bool joke1 = jester.ContainsChuckNorris("There is no chin behind Chuck Norris' beard. There is only another fist.\n");
            bool joke2 = !jester.ContainsChuckNorris("Yo momma's so poor she opend a Gmail account just so she could eat the spam \n");
            bool joke3 = jester.ContainsChuckNorris("chUCk nORRiS");

            // Assert
            Assert.IsTrue(joke1);
            Assert.IsTrue(joke2);
            Assert.IsTrue(joke3); 

        }
    }
}
