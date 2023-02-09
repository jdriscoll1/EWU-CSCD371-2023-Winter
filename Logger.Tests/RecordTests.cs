using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Tests
{
    [TestClass]
    public class RecordTests
    {

        [TestMethod]
        public void InstantiateFullNameObjectReturnTrueIfNotNull()
        {
            Assert.IsNotNull(new FullName("Billy", "Joe", null));

        }

        [TestMethod]
        public void InstantiateFullNameObjectWithMiddleNameReturnTrueIfNotNull()
        {
            Assert.IsNotNull(new FullName("Billy", "Joe", "Bob"));

        }

        [TestMethod]
        public void FullNameComparesByValueAssertTrueIfObjectsAreEqual()
        {
            // This test displays that the two objects are value equals because 
            // we are creating two different objects with different addresses
            // Yet we are equals because they share the same values
            FullName name1 = new("Johnny", "Smith", "J");
            FullName name2 = new("Johnny", "Smith", "J");
            Assert.AreEqual<FullName>(name1, name2);

        }

        [TestMethod]
        public void StudentsAreNotEqual() {
            FullName name = new("Aiden", "Lowe", null);
            Student s1 = new(name, "CS", "EWU");
            Student s2 = new(name, "CS", "EWU");
            Assert.AreNotEqual<Student>(s1, s2); 


        }

        [TestMethod]
        public void EmployeesAreNotEqual()
        {
            FullName name = new("Aiden", "Lowe", null);
            Employee e1 = new(name, "Programmer", "Walmart");
            Employee e2 = new(name, "Programmer", "Walmart");
            Assert.AreNotEqual<Employee>(e1, e2);


        }


        [TestMethod]
        public void BooksAreNotEqual()
        {
            FullName author = new("Aiden", "Lowe", null);
            Book b1 = new("Golf Handbook", author, "12345");
            Book b2 = new("Golf Handbook", author, "12345");
            Assert.AreNotEqual<Book>(b1, b2);


        }

        [TestMethod]
        public void FullNameComparesByValueAssertFalseIfObjectsAreNotEqual()
        {
            FullName name1 = new("Johnny", "", "J");
            FullName name2 = new("Johnny", "S", "J");
            Assert.AreNotEqual<FullName>(name1, name2);

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
        public void StudentInheritsFromPerson() {
            FullName studentName = new("SquarePants", "Spongebob", null);
            Student student = new(studentName, "Boating License", "Boating School");
            Assert.IsInstanceOfType(student, typeof(Person));    
        }


    }
}
