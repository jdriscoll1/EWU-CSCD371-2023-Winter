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
        public string GetAggregateSortedListOfStatesUsingCsvRows() {
            IEnumerable<string> states = GetUniqueSortedListOfStatesGivenCsvRows();
            string[] statesArray = states.Select(x => x).ToArray();
            return string.Join(",", statesArray);
        }

        // 4.
        public IEnumerable<IPerson> People
        {
            get {
                List<IPerson> people = new(); 

                foreach (string row in CsvRows)
                {

                    string[] rowData = row.Split(",");
       
                    if (((rowData[1], rowData[2], rowData[3]) is (string firstName, string lastName, string email)) &&
                         ((rowData[4], rowData[5], rowData[6], rowData[7]) is (string street, string city, string state, string zip))) {
                        Address newAddress = new(street, city, state, zip);
                        Person newPerson = new(firstName, lastName, newAddress, email);
                        people.Add(newPerson); 
                    }
                }
                return people.OrderBy(person => person.Address.State).ThenBy(person => person.Address.City).ThenBy(person => person.Address.Zip); 

            }
        }

        // 5.
        public IEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(
            Predicate<string> filter) => throw new NotImplementedException();

        // 6.
        public string GetAggregateListOfStatesGivenPeopleCollection(
            IEnumerable<IPerson> people) => throw new NotImplementedException();
    }
}
