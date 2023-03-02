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

            Assert.AreEqual<string>(ppl.First().Address.State, "AL");
            Assert.AreEqual<string>(ppl.First().Address.City, "Mobile");
            Assert.AreEqual<string>(ppl.First().Address.Zip, "37308");

        }

        static bool fromGoogle(string email) 
        {
            string google = "google";
            return email.Contains(google);
        }


        [TestMethod]
        public void test_FilterByEmailAddress()
        {
            SampleData sampleData = new();
            Predicate<string> predicate = fromGoogle;
            IEnumerable<(string FirstName, string LastName)> result = sampleData.FilterByEmailAddress(predicate);
            Assert.AreEqual<(string FirstName, string LastName)>(result.Single(), ("Molly", "Jeannot"));
        }

        [TestMethod]
        public void test_GetAggregateListOfStatesGivenPeopleCollection()
        {
            SampleData sampleData = new();
            IEnumerable<string> expected = sampleData.GetUniqueSortedListOfStatesGivenCsvRows(); //< got this wrong in other, kinda
            string[] statesArray = expected.Select(item => item).ToArray();
            string expect = string.Join(",", statesArray);

            string actual = sampleData.GetAggregateListOfStatesGivenPeopleCollection(sampleData.People);
            Assert.AreEqual(expect, actual);
        }
    }
}
