

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GenericsHomework.Tests
{
    [TestClass]
    public class LinkedListTests
    {
        private CircularLinkedList<string>? TestLinkedList { get; set; } = null;

        [TestInitialize]
        public void InstantiateLinkedList()
        {

            TestLinkedList = new("myString");

        }


        [TestMethod]
        public void NodeToStringTest()
        {

        }

        [TestMethod]
        public void CheckIfNextThrowsExceptionIfNull()
        {
            Assert.IsNotNull(TestLinkedList);

        }



        [TestMethod]
        public void AppendNodeToLinkedList()
        {
            Assert.IsNotNull(TestLinkedList);
            TestLinkedList.Append("Test Node");

            Assert.IsTrue(TestLinkedList.Exists("Test Node"));
        }

        [TestMethod]
        public void ClearLinkedList()
        {

        }

        [TestMethod]
        public void ContainsLinkedListTest()
        {

        }

        [TestMethod]
        public void MyTestMethod()
        {

        }

        [TestCleanup]
        public void Cleanup()
        {


        }

        [TestMethod]
        public void OutputLinkedList()
        {

            // Arrange
            Assert.IsNotNull(TestLinkedList); 
            string expected = "myString ";


            // Assert
            Assert.AreEqual<string>(expected, TestLinkedList.ToString()); 

        }
    }
}