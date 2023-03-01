using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Tests
{
    [TestClass]
    public class SampleDataAsynchTests
    {


        [TestMethod]
        public void TestReadCSV()
        {
            // Act
            IAsyncEnumerable<string> csvRows = ((IAsyncSampleData)new SampleDataAsync()).CsvRows;
            IAsyncEnumerator<string> csvEnumerator = csvRows.GetAsyncEnumerator();
            using StreamReader sr = new("People.csv");
            string line;
            _ = sr.ReadLine()!;
            Console.WriteLine("Starting");
            // Assert
            while ((line = sr.ReadLine()!) != null && csvEnumerator.MoveNextAsync().Result)
            {
                Console.WriteLine($"{line} == {csvEnumerator.Current}");
                Assert.AreEqual<string>(line, csvEnumerator.Current);

            }
        }

    }
}
