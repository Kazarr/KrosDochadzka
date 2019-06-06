using Data.Model;
using Data.Repository;
using System;
using System.Collections.Generic;

namespace Data.Generator
{
    public class PersonGenerator
    {
        public int PersonCount;
        public List<int> generatedPersonsId { get; set; }
        private PersonRepository _personRepository;

        public PersonGenerator(int personCount)
        {
            _personRepository = new PersonRepository();
            generatedPersonsId = new List<int>();
            PersonCount = personCount;
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

        public bool GenerateRandomPersons(Action<int> reportProgress, Func<bool> cancelationPendint)
        {
            bool finished = false;
            for (int i = 0; i < PersonCount && !cancelationPendint.Invoke(); i++)
            {
                generatedPersonsId.Add(_personRepository.InsertOnlyPerson(FakePerson()));
                reportProgress.Invoke((i / PersonCount) * 100);
            }
            if(generatedPersonsId.Count == PersonCount)
            {
                finished = true;
            }
            return finished;
        }

    }
}
