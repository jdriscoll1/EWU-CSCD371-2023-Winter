using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Tests
{
    [TestClass]
    public class FullNameTests
    {

        [TestMethod]
        public void InstantiateFullNameObject_ReturnTrueIfNotNull()
        {
            Assert.IsNotNull(new FullName("Billy", "Joe", null));

        }

        [TestMethod]
        public void InstantiateFullNameObjectWithMiddleName_ReturnTrueIfNotNull()
        {
            Assert.IsNotNull(new FullName("Billy", "Joe", "Bob"));

        }

        [TestMethod]
        public void FullNameComparesByValue_AssertTrueIfObjectsAreEqual()
        {
            FullName name1 = new("Johnny", "Smith", "J");
            FullName name2 = new("Johnny", "Smith", "J");
            Assert.AreEqual(name1, name2);

        }

        [TestMethod]
        public void InstantiateStudentRecord()
        {
            FullName studentName = new("Vader", "Darth", null);
            Assert.IsNotNull(new Student(studentName, "Mechanical Engineer", "Eastern Washington University"));
        }

        [TestMethod]
        public void InstantiateEmployeeRecord() {
            FullName employeeName = new("Claude", "Debussy", null);
            Assert.IsNotNull(new Employee(employeeName, "Janitor", "Walmart"));
        
        }

        [TestMethod]
        public void InstantiateBookRecord()
        {
            FullName author = new("Poe", "Edgar", "Alan");
            Assert.IsNotNull(new Book("The Cat In The Hat", author, "12345")); 

        }

        [TestMethod]
        public void ValidateRecordStored_ReturnTrueIfObjectsSaved()
        {
            // Arrange
            Storage recordStorage = new();
            string isbn = "12345";
            FullName author = new("Poe", "Edgar", "Alan");
            Book bookRecord = new("The Cat In The Hat", author, isbn);
            Guid bookID = bookRecord.Id; 

            // Act
            recordStorage.Add(bookRecord);
            Book storedBook = recordStorage.Get(bookID) as Book ?? throw new ArgumentNullException();

            // Assert
            Assert.AreEqual<Book>(storedBook, bookRecord); 

        }


    }
}
