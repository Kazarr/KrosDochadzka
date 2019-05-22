using Data.Model;
using Data.Repository;
using System;

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
            return new Person() { FirstName = firstName, LastName = lastName, PhoneNumber = phoneNumber, Adress = adress };
        }

        public void GenerateRandomPersons()
        {
            for (int i = 0; i < PERSON_COUNT; i++)
            {
                _personRepository.InsertOnlyPerson(FakePerson());
            }
        }

    }
}
