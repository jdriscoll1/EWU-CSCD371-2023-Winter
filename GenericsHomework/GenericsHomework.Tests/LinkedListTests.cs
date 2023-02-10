

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using GenericsHomework; 

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
        public void NodeToStringTest() { 
        
        }

        [TestMethod]
        public void CheckIfNextThrowsExceptionIfNull()
        {
            Assert.IsNotNull(TestLinkedList);

        }

   

        [TestMethod]
        public void AppendNodeToLinkedList()
        {

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
        public void Cleanup() { 
        
        
        }
    }
}