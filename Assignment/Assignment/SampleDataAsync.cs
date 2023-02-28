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
        public IAsyncEnumerable<string> CsvRows {
            get
            {
                return null!; 
                //var inputFile = File.ReadAllLines("People.csv");
                //return new List<string>(inputFile).Skip(1);
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
