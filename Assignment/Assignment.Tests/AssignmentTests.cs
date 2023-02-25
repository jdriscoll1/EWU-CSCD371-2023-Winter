using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using Assignment;
using System.Linq;
using System.Transactions;

namespace Assignment.Tests
{
    [TestClass]
    public class AssignmentTests
    {

        [TestMethod]
        public void TestReadCSV()
        {
            // Act
            IEnumerable<string> csvRows = new SampleData().CsvRows;
            IEnumerator<string> csvEnumerator = csvRows.GetEnumerator();
            using StreamReader sr = new("People.csv");
            string line;
            _ = sr.ReadLine()!;

            // Assert
            while ((line = sr.ReadLine()!) != null && csvEnumerator.MoveNext())
            {
                Assert.AreEqual<string>(line, csvEnumerator.Current);
            
            }
        }

        [TestMethod]
        public void ValidateUnique_UsingHardcodedListOfSpokaneAddresses()
        {          
            // Arrange
            List<Address> listOfAddresses = new() {
                new Address("44 W. Riverside Ave.", "Spokane", "WA", "99201"),
                new Address("2111 W. Wellesley Ave", "Spokane", "WA", "99205"),
                new Address("2304 E. Mallon", "Spokane", "WA", "99202"),
                new Address("1720 W 4th Ave Unit B", "Spokane", "WA", "99201"),
                new Address("5124 N. Market St.", "Spokane", "WA", "99217")
                
            };

            // Act
            IEnumerable<Address> state = listOfAddresses.DistinctBy(address => address.State);

            // Assert
            Assert.AreEqual<int>(1, state.Count());
            Assert.AreEqual<string>("WA", state.ElementAt(0).State); 

        }

        [TestMethod]
        public void TestGetUniqueSortedListOfStatesGivenCsvRows_AssertTrueIfStatesAreOrdered()
        {
            // Act
            IEnumerable<string> uniqueSortedListOfStates = new SampleData().GetUniqueSortedListOfStatesGivenCsvRows();
            _ = uniqueSortedListOfStates.Zip(uniqueSortedListOfStates.Skip(1), (curr, next) => String.Compare(curr, next) > 0).All(x => x);
           // Assert
            Assert.AreEqual<int>(27, uniqueSortedListOfStates.Count());

        }

        [TestMethod]
        public void Test_GetAggregateSortedListOfStatesUsingCsvRows()
        {
            // Arrange
            string expected = "AL,AZ,CA,DC,FL,GA,IN,KS,LA,MD,MN,MO,MT,NC,NE,NH,NV,NY,OR,PA,SC,TN,TX,UT,VA,WA,WV";
            // Act
            string actual = new SampleData().GetAggregateSortedListOfStatesUsingCsvRows().ToString();
            // Assert
            Assert.AreEqual<string>(expected, actual); 
        }

        [TestMethod]
        public void Test_PersonObject()
        {
            // Arrange
            //49,Arthur,Myles,amyles1c@miibeian.gov.cn,4718 Thackeray Pass,Mobile,AL,37308

            Person expected = new("Arthur", "Myles", new Address("4718 Thackeray Pass", "Mobile", "AL", "37308"), "amyles1c@miibeian.gov.cn");
            // Act
            IEnumerable<IPerson> people = new SampleData().People;
            Person actual = (Person)people.ElementAt(0);
            // Assert
            Assert.AreEqual<string>(expected.FirstName, actual.FirstName);
            Assert.AreEqual<string>(expected.LastName, actual.LastName);
            Assert.AreEqual<string>(expected.EmailAddress, actual.EmailAddress);
            Assert.AreEqual<string>(expected.Address.State, actual.Address.State);
            Assert.AreEqual<string>(expected.Address.StreetAddress, actual.Address.StreetAddress);
            Assert.AreEqual<string>(expected.Address.Zip, actual.Address.Zip);
            Assert.AreEqual<string>(expected.Address.City, actual.Address.City);

        }
    }
}
