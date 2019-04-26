using Data.Model;
using Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Data.Generator
{
    public class EmployeeGenerator
    {
        private EmployeeRepository _employeeRepository;
        private PersonRepository _personRepository;

        Random r = new Random();

        private DateTime RandomDate()
        {
            DateTime start = new DateTime(1995, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(r.Next(range));
        }

        public Empolyee SetEmployee(int i)
        {
           
                string pass = "0000";
                int idPerson = i;
                int idPermission = 2;
                decimal salary = r.Next(1400, 2300);
                DateTime date = RandomDate();
                return new Empolyee(pass, idPerson, idPermission, salary, date);            
        }
        public void GenerateEmployee()
        {
            List<Person> people = ManagerRepository.PersonRepository.GetPersons().ToList();
            for (int i = 3; i < people.Count-700; i++)
            {
                _employeeRepository.InsertFullEmployee(SetEmployee(i));
            }
        }
    }
}
