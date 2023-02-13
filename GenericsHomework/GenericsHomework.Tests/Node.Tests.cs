

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics.Metrics;
using System.Text;

namespace GenericsHomework.Tests
{
    [TestClass]
    public class LinkedListTests
    {
        private Node<string>? TestNode { get; set; } = null;

        [TestInitialize]
        public void InstantiateNode()
        {

            TestNode = new("myString");

        }


        [TestMethod]
        public void CheckIfNextThrowsExceptionIfNull()
        {
            Assert.IsNotNull(TestNode);

        }



        [TestMethod]
        public void AppendNodeTest()
        {
            Assert.IsNotNull(TestNode);
            TestNode.Append("Test Node");

            Assert.IsTrue(TestNode.Exists("Test Node"));
        }


        [TestMethod]
        public void ClearNodes()
        {
            // Arrange
            Assert.IsNotNull(TestNode);
            TestNode.Append("1");
            TestNode.Append("2");
            TestNode.Append("3");
            TestNode.Append("4");
            TestNode.Append("5");
            TestNode.Append("6");
            TestNode.Append("7");  
            Assert.AreEqual<string>( "myString 7 6 5 4 3 2 1 ", TestNode.ToString()); 

            
            // Act
            TestNode.Clear();

            // Assert
            Assert.AreEqual<string>(TestNode.ToString(), "myString "); 



        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AssertDuplicatesCannotBeAddedNode() {
            Assert.IsNotNull(TestNode);
            TestNode.Append("1");
            TestNode.Append("1");


        }

        [TestMethod]
        public void ContainsLinkedListTestHead()
        {
            // Arrange
            Assert.IsNotNull(TestNode);
        
            
            Assert.IsTrue(TestNode.Exists("myString"));

        }

        [TestMethod]
        public void ContainsNodeTestBody()
        {
            // Arrange
            Assert.IsNotNull(TestNode);

            TestNode.Append("1");
            TestNode.Append("2");
            TestNode.Append("3");
            Assert.IsTrue(TestNode.Exists("2"));

        }


        [TestMethod]
        public void OutputNodes()
        {

            // Arrange
            Assert.IsNotNull(TestNode); 
            string expected = "myString ";


            // Assert
            Assert.AreEqual<string>(expected, TestNode.ToString()); 

        }
    }
}