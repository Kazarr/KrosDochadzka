using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Model;
using RandomNameGeneratorLibrary;
using Faker;
using Data.Repository;

namespace Data.Generator
{
    public class PersonGenerator
    {
        public const int PERSON_COUNT = 100;
        private PersonRepository _personRepository;

        public PersonGenerator()
        {
            _personRepository = new PersonRepository();
        }
        public Person FakePerson()
        {
            Random r = new Random();
            string firstName = Faker.Name.First();
            string lastName = Faker.Name.Last();
            string adress = Faker.Address.StreetName();
            string phoneNumber = "0905" + r.Next(1000000).ToString();
            return new Person(firstName, lastName, phoneNumber, adress);
        }

        public void GenerateRandomPersons()
        {
            for(int i = 0; i < PERSON_COUNT; i++)
            {
                _personRepository.InsertOnlyPerson(FakePerson());
            }
        }

    }
}
