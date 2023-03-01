using System;
using System.Collections.Generic;
using System.Linq;
using System.IO; 
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    public class SampleDataAsync : IAsyncSampleData
    {
        public static async IAsyncEnumerable<string> ReadFileIntoAsyncEnumerable()
        {
            using StreamReader reader = File.OpenText("People.csv");
            reader.ReadLine(); 
            while (!reader.EndOfStream)
                yield return await reader.ReadLineAsync() ?? throw new ArgumentNullException("File Not Found");
        }

        public IAsyncEnumerable<string> CsvRows
        {
            get
            { 
                return ReadFileIntoAsyncEnumerable(); 
                

            }
        }

        public IAsyncEnumerable<IPerson> People => throw new NotImplementedException();

        public IAsyncEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(Predicate<string> filter)
        {
            throw new NotImplementedException();
        }

        public string GetAggregateListOfStatesGivenPeopleCollection(IAsyncEnumerable<IPerson> people)
        {
            throw new NotImplementedException();
        }

        public string GetAggregateSortedListOfStatesUsingCsvRows()
        {
            throw new NotImplementedException();
        }

        public IAsyncEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows()
        {
            throw new NotImplementedException();
        }
    }
}
