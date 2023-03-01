using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment.Tests
{
    [TestClass]
    public class SampleDataAsynchTests
    {


        [TestMethod]
        public async Task TestReadCSV()
        {
            // Act
            
            // Make a new Async Sample Data Object 
            SampleDataAsync sampleData = new(); 

            // Obtain the CSV Rows 
            IAsyncEnumerable<string> csvRows = sampleData.CsvRows;

            // Get an Enumerator For the Rows 
            IAsyncEnumerator<string> csvEnumerator = csvRows.GetAsyncEnumerator();
            using StreamReader sr = new("People.csv");

            // Count the Number of Lines
            _ = sr.ReadLine()!;
            
            int i = 0; 
            while(sr.ReadLine()!= null)
            {
                i++; 
            }

            Assert.AreEqual<int>(csvRows.CountAsync().Result, i);


            // Check the all the lines are the same 
            string line;

            using StreamReader sr2 = new("People.csv");
            _ = sr2.ReadLine()!;
            // Assert
            await foreach(var row in csvRows)
            {
                line = sr2.ReadLine()!; 
                
                Assert.AreEqual<string>(line, row);

            }
            
        }

        [TestMethod]
        public void Test_PersonObject()
        {
            // Arrange
            Person expected = new("Arthur", "Myles", new Address("4718 Thackeray Pass", "Mobile", "AL", "37308"), "amyles1c@miibeian.gov.cn");
            // Act
            IAsyncEnumerable<IPerson> people = new SampleDataAsync().People;
            Person actual = (Person)people.FirstAsync().Result;
            // Assert
            Assert.IsTrue(expected == actual);

        }

      
        private static bool ContainsDotGov(string str)
        {
            return str.Contains(".gov");
        }

        [TestMethod]
        public async Task Test_FilterByEmail()
        {
         
            // Arrange
            Predicate<string> predicate = ContainsDotGov;
            SampleDataAsync data = new();
            IAsyncEnumerable<IPerson> people = data.People;
            List<Person> expected = new();
           await foreach (Person person in people.Cast<Person>())
            {
                if (predicate(person.EmailAddress))
                {
                    expected.Add(person);
                }
            }

            Assert.IsTrue(expected.All(person => predicate(person.EmailAddress)));
            
            // Act 
            IAsyncEnumerable<(string FirstName, string LastName)> actual = data.FilterByEmailAddress(predicate);

            // Assert
            Assert.AreEqual<int>(actual.CountAsync().Result, expected.Count);

            // Using Get Enumerator Because To Abide By the Pricniple of Preferring Simplicity
            // Zip functionality required unnecessarily complicated typing 
            IAsyncEnumerator<(string FirstName, string LastName)> actualEnumerator = actual.GetAsyncEnumerator();
            foreach (Person person in expected) {
                await actualEnumerator.MoveNextAsync();
                Assert.AreEqual<(string FirstName, string LastName)>((person.FirstName, person.LastName), actualEnumerator.Current);
               
            }

            
            

        }

        [TestMethod]
        public void TestAsyncGetUniqueSortedListOfStatesGivenCsvRows_AssertTrueIfStatesAreOrdered()
        {
            IAsyncEnumerable<string> uniqueSortedListOfStates = new SampleDataAsync().GetUniqueSortedListOfStatesGivenCsvRows();
            Assert.IsTrue(uniqueSortedListOfStates.Zip(uniqueSortedListOfStates.Skip(1), (curr, next) => string.Compare(curr, next) < 0).AllAsync(x => x).Result);
            Assert.AreEqual<int>(27, uniqueSortedListOfStates.CountAsync().Result);
        }

    }
}
