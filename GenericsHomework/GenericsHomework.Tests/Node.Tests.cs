

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics.Metrics;
using System.Reflection;
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

        [TestMethod]
        public void ValidateCountReturnsNumberOfItems()
        {
            Assert.IsNotNull(TestNode); 
 
            Assert.AreEqual<int>(TestNode.Count(), 1);
            TestNode.Append("1");
            
            Assert.AreEqual<int>(TestNode.Count(), 2);
            
            TestNode.Append("2");
            Assert.AreEqual<int>(TestNode.Count(), 3);
            TestNode.Append("3");
            Assert.AreEqual<int>(TestNode.Count(), 4);
            TestNode.Append("4");
            Assert.AreEqual<int>(TestNode.Count(), 5);
            TestNode.Clear();
            Assert.AreEqual<int>(TestNode.Count(), 1);
            
        }

        [TestMethod]
        public void ConvertLinkedListToArray_StartAt0()
        {
            Assert.IsNotNull(TestNode);
            TestNode.Add("1");
            TestNode.Add("2");
            string[] arr = {"3", "4", "5"};
            TestNode.CopyTo(arr, 0);
            
            Assert.AreEqual<string>(string.Join(" ", arr), TestNode.ToString().Trim());
            TestNode.Clear(); 

        }

        [TestMethod]
        public void ConvertLinkedListToArray_StartAt1()
        {
            Assert.IsNotNull(TestNode);
            TestNode.Add("1");
            TestNode.Add("2");
            string[] arr = { "3", "4", "5" };
            TestNode.CopyTo(arr, 1);

            Assert.AreEqual<string>("3 myString 2", string.Join(" ", arr));
            TestNode.Clear(); 

        }

        [TestMethod]
        public void ConvertLinkedListToArray_StartAt2()
        {
            Assert.IsNotNull(TestNode);
            TestNode.Add("1");
            TestNode.Add("2");
            string[] arr = { "3", "4", "5" };
            TestNode.CopyTo(arr, 2);

            Assert.AreEqual<string>("3 4 myString", string.Join(" ", arr));
            TestNode.Clear(); 

        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ValidateCopyToThrowNullException()
        {
            // Arrange
            Assert.IsNotNull(TestNode);
            string[] nullArray = null!;

            // Act
            TestNode.CopyTo(nullArray, 0); 

        }

        [TestMethod]
        public void TestEnumerator_ReturnTrueIfOutputIntoString() {
            // Arrange
            Assert.IsNotNull(TestNode);
            // Act
            TestNode.Append("0");
            TestNode.Append("1");
            TestNode.Append("2");
            TestNode.Append("3");

            string actual = ""; 
            // Assert
            foreach (string value in TestNode) {
                actual += value; 
            }
            string expected = "myString3210";
            Assert.AreEqual<string>(expected, actual);
            TestNode.Clear();

        }

        [TestMethod]
        public void TestRemoveFromLinkedList()
        {
            // Arrange
            Assert.IsNotNull(TestNode);
            TestNode.Append("1");
            TestNode.Append("2");
            TestNode.Append("3");
            Assert.AreEqual<string>("myString 3 2 1 ", TestNode.ToString());

            // Act
            Assert.IsTrue(TestNode.Remove("2"));

            // Assert
            Assert.AreEqual<string>("myString 3 1 ", TestNode.ToString());

            // Act
            Assert.IsTrue(TestNode.Remove("3"));

            // Assert
            Assert.AreEqual<string>("myString 1 ", TestNode.ToString());

            Assert.IsFalse(TestNode.Remove("myString"));

            Assert.IsFalse(TestNode.Remove("2"));



        }


    }
}