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

        public Empolyee Eempolyee { get; set; }
        public Person Pperson { get; set; }
        public Person Supervisor { get; set; }

        public NewEmployeeViewModel(Person person, Empolyee empolyee)
        {
            Pperson = person;
            Eempolyee = empolyee;
            Supervisor = GetSupervisor(Eempolyee.Id);
        }

        public NewEmployeeViewModel()
        {
            Eempolyee = new Empolyee();
            Pperson = new Person();
        }

        public void AddNewEmployee(string firstName, string lastName, string phoneNumber, string adress, int permission, Person supervisor, string password)
        {
            Person p = new Person(firstName, lastName, phoneNumber, adress);
            p.Id = ManagerRepository.PersonRepository.InsertPerson(p);
            Empolyee e = new Empolyee(password, p.Id, permission);
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


        public void AddNewEmployee()
        {
           
            Pperson.Id = ManagerRepository.PersonRepository.InsertPerson(Pperson);
           
            if (Supervisor == null)
            {
                Eempolyee.IdSupervisor = ManagerRepository.EmployeeRepository.InsertFullEmployee(Eempolyee);
                Eempolyee.Id = Eempolyee.IdSupervisor.Value;
                ManagerRepository.EmployeeRepository.UpdateSupervisor(Eempolyee);
            }
            else
            {
                Eempolyee.IdSupervisor = ManagerRepository.EmployeeRepository.GetEmpolyeeByIdPerson(Supervisor.Id).Id;
                ManagerRepository.EmployeeRepository.InsertFullEmployee(Eempolyee);
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

        public void UpdateEmployee(string firstName, string lastName, string phoneNumber, string adress, int permission, Person supervisor)
        {
            Eempolyee.Permision = permission;
            Person p = new Person(firstName, lastName, phoneNumber, adress);
            if(supervisor == null)
            {
                Eempolyee.IdSupervisor = Eempolyee.Id;
            }
            else
            {
                Eempolyee.IdSupervisor = ManagerRepository.EmployeeRepository.GetEmpolyeeByIdPerson(supervisor.Id).Id;
            }
            ManagerRepository.EmployeeRepository.UpdateEmployee(Eempolyee, p);
            

        }
    }
}
