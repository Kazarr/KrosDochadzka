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
        private RepositoryFactory _repositoryFactory;

        public EmployeeGenerator()
        {
            _repositoryFactory = new RepositoryFactory();

        }

        Random r = new Random();

        private DateTime RandomDate()
        {
            DateTime start = new DateTime(1995, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(r.Next(range));
        }

        public Employee SetSupervisor(int i)
        {
            string pass = "0000";
            int idPerson = i;
            int idPermission = 2;
            decimal salary = r.Next(1400, 2300);
            DateTime date = RandomDate();
            return new Employee(pass, idPerson, idPermission, salary, date);
        }
        public Employee SetEmployee(int i)
        {
            string pass = "0000";
            int idPerson = i;
            int idSupervisor = r.Next(2118, 2214);
            int idPermission = 1;
            decimal salary = r.Next(1000, 2500);
            DateTime date = RandomDate();
            return new Employee(pass, idPerson, idSupervisor, idPermission, salary, date);
        }

        public void GenerateSupervisor()
        {
            List<Person> people = _repositoryFactory.GetPersonRepository().GetPersons().ToList();
            for (int i = 5; i < people.Count - 700; i++)
            {
               _repositoryFactory.GetEmployeeRepository().InsertFullEmployee(SetSupervisor(i));
            }
        }

        public void GenerateEmployee()
        {
            List<Person> people = _repositoryFactory.GetPersonRepository().GetPersons().ToList();
            for (int i = 200; i < people.Count-1 ; i++)
            {
                _repositoryFactory.GetEmployeeRepository().InsertFullEmployee(SetEmployee(i));
            }
        }
    }
}
