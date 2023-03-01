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
        private static async IAsyncEnumerable<string> ReadFileIntoAsyncEnumerable()
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
        private async IAsyncEnumerable<IPerson> GetPeople() {


            await foreach (string row in CsvRows)
            {

                string[] rowData = row.Split(",");

                if (((rowData[1], rowData[2], rowData[3]) is (string firstName, string lastName, string email)) &&
                     ((rowData[4], rowData[5], rowData[6], rowData[7]) is (string street, string city, string state, string zip)))
                {
                    Address newAddress = new(street, city, state, zip);
                    Person newPerson = new(firstName, lastName, newAddress, email);
                    yield return newPerson;
                }
            }
       
        }
        public IAsyncEnumerable<IPerson> People {
         
                get {
                    return GetPeople().OrderBy(person => person.Address.State).ThenBy(person => person.Address.City).ThenBy(person => person.Address.Zip);  
                }
            

        }

        public IAsyncEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(Predicate<string> filter)
        {
            return People.Where(person => filter(person.EmailAddress)).Select(person => {
              return (person.FirstName, person.LastName);
          });
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
