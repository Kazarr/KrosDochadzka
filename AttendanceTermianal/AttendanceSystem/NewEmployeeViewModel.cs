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

        public Empolyee Empolyee { get; set; }
        public Person Person { get; set; }
        public Person Supervisor { get; set; }

        public NewEmployeeViewModel(Person person, Empolyee empolyee)
        {
            Person = person;
            Empolyee = empolyee;
            Supervisor = GetSupervisor(Empolyee.Id);
        }

        public NewEmployeeViewModel()
        {
            Empolyee = new Empolyee();
            Person = new Person();
        }

        public void AddNewEmployee(string firstName, string lastName, string phoneNumber, string adress, decimal salary, int permission, Person supervisor, string password)
        {
            Person p = new Person(firstName, lastName, phoneNumber, adress);
            p.Id = ManagerRepository.PersonRepository.InsertPerson(p);
            Empolyee e = new Empolyee(password, p.Id, permission, salary);
            //e.Password = password;
            //e.IdPerson = p.Id;
            //e.IdSupervisor = supervisor.Id;
            //e.Permision = permission;
            //e.Salary = salary;
            if (supervisor == null)
            {
                e.IdSupervisor = ManagerRepository.EmployeeRepository.InsertFullEmployee(e);
                e.Id = e.IdSupervisor.Value;
                ManagerRepository.EmployeeRepository.UpdateSupervisor(e);
            }
            else
            {
                e.IdSupervisor = ManagerRepository.EmployeeRepository.GetEmpolyeeByIdPerson(supervisor.Id).Id;
                ManagerRepository.EmployeeRepository.InsertFullEmployee(e);
            }


        }

        public List<string> FillPermissions()
        {
            return ManagerRepository.PermissionRepository.SelectPermissionName();
        }

        public string EmployeePermission(Empolyee empolyee)
        {
            return ManagerRepository.PermissionRepository.SelectPermissionNameById(empolyee.Permision);
        }

        public int EmployeePermissionId(string name)
        {
            return ManagerRepository.PermissionRepository.SelectPermissionIdByName(name);
        }

        public Person GetSupervisor(int? idEmployee)
        {
            return ManagerRepository.PersonRepository.GetPersonByIdEmployee(idEmployee.Value);
        }

        public BindingList<Person> FillSupervisors()
        {
            return new BindingList<Person>(ManagerRepository.PersonRepository.GetPersonEmployeesSupervisors());
        }

        public void UpdateEmployee(string firstName, string lastName, string phoneNumber, string adress, decimal salary, int permission, Person supervisor, string password)
        {
            Empolyee.Password = password;
            Empolyee.Permision = permission;
            Empolyee.Salary = salary;
            Person p = new Person(firstName, lastName, phoneNumber, adress);
            if(supervisor == null)
            {
                Empolyee.IdSupervisor = Empolyee.Id;
            }
            else
            {
                Empolyee.IdSupervisor = ManagerRepository.EmployeeRepository.GetEmpolyeeByIdPerson(supervisor.Id).Id;
            }
            ManagerRepository.EmployeeRepository.UpdateEmployee(Empolyee, p);
            

        }
    }
}
