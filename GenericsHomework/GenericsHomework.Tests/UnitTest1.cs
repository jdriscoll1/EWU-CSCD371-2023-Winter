

using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace GenericsHomework.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestInitialize]
        public void InstantiateLinkedList()
        {
     
            CirclularLinkedList<string> list = new CircularLinkedList<string>("myString");

        }


        [TestMethod]
        public void NodeToStringTest() { 
        
        }

        [TestMethod]
        public void CheckIfNextThrowsExceptionIfNull()
        {

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