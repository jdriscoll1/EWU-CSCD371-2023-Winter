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

            using StreamReader sr = new("People.csv");
            string line;
            _ = sr.ReadLine()!;

            while ((line = sr.ReadLine()!) != null && csvEnumerator.MoveNext())
            {
                Assert.AreEqual<string>(line, csvEnumerator.Current);
            
            }
        }
    }
}
