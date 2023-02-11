

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
        public void TestLinkedListSize_AssertEqualsTo5()
        {
            // Arrange
            Assert.IsNotNull(TestLinkedList);
            TestLinkedList.Append("string 2");
            TestLinkedList.Append("string 3");
            TestLinkedList.Append("string 4");
            TestLinkedList.Append("string 5");

            // Assert
            Assert.AreEqual<int>(TestLinkedList.Size, 5);


        }
        [TestMethod]
        public void ClearLinkedList()
        {
            // Arrange
            Assert.IsNotNull(TestLinkedList);
            TestLinkedList.Append("1");
            TestLinkedList.Append("2");
            TestLinkedList.Append("3");
            TestLinkedList.Append("4");
            TestLinkedList.Append("5");
            TestLinkedList.Append("6");
            TestLinkedList.Append("7");  
            Assert.AreEqual<string>(TestLinkedList.ToString(), "myString 7 6 5 4 3 2 1 "); 

            
            // Act
            TestLinkedList.Clear();

            // Assert
            Assert.AreEqual<int>(TestLinkedList.Size, 1);
            Assert.AreEqual<string>(TestLinkedList.ToString(), "myString "); 



        }

        public void ValidateNodesAreDestroyedOnClear_ReturnTrueIfDestructorOutputs() { 
            
        
        }

        [TestMethod]
        public void ContainsLinkedListTest()
        {
            // Arrange
            Assert.IsNotNull(TestLinkedList);
            string expected = "myString";


            // Assert
            Assert.IsTrue(TestLinkedList.Exists(expected));

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