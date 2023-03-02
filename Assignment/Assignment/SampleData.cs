using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using static System.Net.Mime.MediaTypeNames;

namespace Assignment
{
    public class SampleData : ISampleData
    {
        // 1.
        public IEnumerable<string> CsvRows => File.ReadAllLines("../../../People.csv").Skip(1);

        // 2.
        public IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows()
        {
            List<string> states = new();
            foreach (string row in CsvRows)
            {
                states.Add(row.Split(",")[6]);
            }
            return states.Distinct().OrderBy(b => b).ToList();
        }


        // 3.
        public string GetAggregateSortedListOfStatesUsingCsvRows()
        {
            IEnumerable<string> states = GetUniqueSortedListOfStatesGivenCsvRows();
            string[] statesArray = states.Select(item => item).ToArray();
            return string.Join(",", statesArray);
        }

        // 4.
        public IEnumerable<IPerson> People
        {
            get {
                List<IPerson> people = new();
                foreach (string row in CsvRows)
                {
                    string[] PersonInfo = row.Split(",").ToArray();
                    Address adrss = new(PersonInfo[4], PersonInfo[5], PersonInfo[6], PersonInfo[7]);
                    people.Add( new Person(PersonInfo[1], PersonInfo[2],adrss, PersonInfo[3]));
                }
                IEnumerable<IPerson> SortedPeople = people.OrderBy(person => person.Address.State).ThenBy(person => person.Address.City).ThenBy(person => person.Address.Zip);
                return SortedPeople;
            }
        }

        // 5.
        public IEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(
            Predicate<string> filter)
        {
            return (IEnumerable<(string FirstName, string LastName)>)
                People.Where(person => filter(person.EmailAddress)).Select(item => new { item.FirstName, item.LastName });
            
        }

        // 6.
        /*public string GetAggregateListOfStatesGivenPeopleCollection(
            IEnumerable<IPerson> people)
        {
            List<string> states = new List<string>();
            foreach (IPerson person in people)
            {
                states.Add(person.Address.State);
            }
            string agg = states.Aggregate("", (state, next) => states.Contains());
            return;
        }*/
    }
}
