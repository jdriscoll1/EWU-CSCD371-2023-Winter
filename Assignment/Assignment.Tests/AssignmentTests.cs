using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using Assignment;
using System.Linq;

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

            using StreamReader sr = new("../../../People.csv");
            string line = sr.ReadLine()!;
         
            while ((line = sr.ReadLine()!) != null && csvEnumerator.MoveNext())
            {
                Assert.AreEqual<string>(line, csvEnumerator.Current);
            
            }
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
        public void Test_PersonReturnsPeople()
        {
            SampleData sampleData = new();
            var ppl = sampleData.People;
            //_ = ppl.Zip(ppl.Skip(1), (curr, next) => (curr > next).All(x => x);

            //string frstPersn = sampleData.CsvRows.First().Split(",")[1];
            Assert.AreEqual<string>(ppl.First().Address.State, "AL");
            Assert.AreEqual<string>(ppl.First().Address.City, "Mobile");
            Assert.AreEqual<string>(ppl.First().Address.Zip, "37308");

        }
    }
}
