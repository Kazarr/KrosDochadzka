using Data.Model;
using Data.Repository;
using Logic;
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
        private LogicSystem _logic = new LogicSystem();
        public Employee Employee { get; set; }
        public Person Person { get; set; }
        public Person Supervisor { get; set; }

        public NewEmployeeViewModel(Person person, Employee empolyee)
        {
            Person = person;
            Employee = empolyee;
            Supervisor = GetSupervisor(Employee.Id);
        }

        public NewEmployeeViewModel()
        {
            Employee = new Employee();
            Person = new Person();
        }

        public void AddNewEmployee(string firstName, string lastName, string phoneNumber, string address, int permission, Person supervisor, string password)
        {
            _logic.AddNewEmployee(firstName, lastName, phoneNumber, address, permission, supervisor, password);
        }

        public void AddNewEmployee()
        {
            _logic.AddNewEmployee(Person, Employee, Supervisor);
        }

        public List<string> FillPermissions()
        {
            return ManagerRepository.PermissionRepository.SelectPermissionName();
        }

        public string EmployeePermission(Employee empolyee)
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

        public void UpdateEmployee(string firstName, string lastName, string phoneNumber, string address, int permission, Person supervisor)
        {
            _logic.UpdateEmployee(firstName, lastName, phoneNumber, address, permission, supervisor);

        }

    
    }
}
