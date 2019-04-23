using Data.Model;
using Data.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem
{
    public class NewEmployeeViewModel
    {
        public void AddNewEmployee(string firstName, string lastName, string phoneNumber, string streetName, string houseNumber, decimal salary, int permission, Person supervisor, string password)
        {
            Person p = new Person(firstName, lastName, phoneNumber, streetName + " " + houseNumber);
            p.Id = ManagerRepository.PersonRepository.InsertPerson(p);
            Empolyee e = new Empolyee(password,p.Id, supervisor.Id, permission,salary);
            ManagerRepository.EmployeeRepository.InsertFullEmployee(e);
            
        }

        public BindingList<Person> FillSupervisors()
        {
            return new BindingList<Person>(ManagerRepository.PersonRepository.GetPersonEmployeesSupervisors());
        }
    }
}
