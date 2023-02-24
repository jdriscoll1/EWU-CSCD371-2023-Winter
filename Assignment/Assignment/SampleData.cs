using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace Assignment
{
    public class SampleData : ISampleData
    {
        // 1.
        public IEnumerable<string> CsvRows { 
            get {
                var inputFile = File.ReadAllLines("People.csv");
                return new List<string>(inputFile).Skip(1);
            } 
        }

        // 2.
        public IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows() {
            List<string> states = new(); 
            foreach (string row in CsvRows) {
                states.Add(row.Split(",")[6]); 
            }
            states = states.Distinct().OrderBy(x => x).ToList(); 

            return states; 

        }
            

        // 3.
        public string GetAggregateSortedListOfStatesUsingCsvRows()
            => throw new NotImplementedException();

        // 4.
        public IEnumerable<IPerson> People => throw new NotImplementedException();

        // 5.
        public IEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(
            Predicate<string> filter) => throw new NotImplementedException();

        // 6.
        public string GetAggregateListOfStatesGivenPeopleCollection(
            IEnumerable<IPerson> people) => throw new NotImplementedException();
    }
}
