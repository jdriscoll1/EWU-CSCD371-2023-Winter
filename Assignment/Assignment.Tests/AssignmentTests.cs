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
            SampleData sampleData = new();
            IEnumerable<string> csvRows = sampleData.CsvRows;
            IEnumerator<string> csvEnumerator = csvRows.GetEnumerator();
            using StreamReader sr = new("People.csv");
            string line;
            _ = sr.ReadLine()!;

            while ((line = sr.ReadLine()!) != null && csvEnumerator.MoveNext())
            {
                Assert.AreEqual<string>(line, csvEnumerator.Current);
            
            }
        }

        [TestMethod]
        public void ValidateUnique_UsingHardcodedListOfSpokaneAddresses()
        {          
            List<Address> listOfAddresses = new() {
                new Address("44 W. Riverside Ave.", "Spokane", "WA", "99201"),
                new Address("2111 W. Wellesley Ave", "Spokane", "WA", "99205"),
                new Address("2304 E. Mallon", "Spokane", "WA", "99202"),
                new Address("1720 W 4th Ave Unit B", "Spokane", "WA", "99201"),
                new Address("5124 N. Market St.", "Spokane", "WA", "99217")
                
            };
            IEnumerable<Address> state = listOfAddresses.DistinctBy(address => address.State);
            Assert.AreEqual<int>(1, state.Count());
            Assert.AreEqual<string>("WA", state.ElementAt(0).State); 

        }

        [TestMethod]
        public void TestGetUniqueSortedListOfStatesGivenCsvRows_AssertTrueIfStatesAreOrdered()
        {
            IEnumerable<string> uniqueSortedListOfStates = new SampleData().GetUniqueSortedListOfStatesGivenCsvRows();
            _ = uniqueSortedListOfStates.Zip(uniqueSortedListOfStates.Skip(1), (curr, next) => String.Compare(curr, next) > 0).All(x => x);
            Assert.AreEqual<int>(27, uniqueSortedListOfStates.Count());

        }

        [TestMethod]
        public void Test_GetAggregateSortedListOfStatesUsingCsvRows()
        {
            string expected = "AL,AZ,CA,DC,FL,GA,IN,KS,LA,MD,MN,MO,MT,NC,NE,NH,NV,NY,OR,PA,SC,TN,TX,UT,VA,WA,WV";
            string actual = new SampleData().GetAggregateSortedListOfStatesUsingCsvRows().ToString();
            Assert.AreEqual<string>(expected, actual); 
        }
    }
}
