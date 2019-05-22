using Data.Model;
using Data.Repository;
using Logic;
using System.Collections.Generic;
using System.ComponentModel;

namespace AttendanceSystem
{
    public class NewEmployeeViewModel
    {
        private LogicSystem _logic;
        public Employee Employee { get; set; }
        public Person Person { get; set; }
        public Person Supervisor { get; set; }

        public NewEmployeeViewModel(Person person, Employee empolyee, LogicSystem logic)
        {
            _logic = logic;
            Person = person;
            Employee = empolyee;
            Supervisor = GetSupervisor(Employee.Id);

        }

        public NewEmployeeViewModel(LogicSystem logic)
        {
            _logic = logic;
            Employee = new Employee();
            Person = new Person();
        }

        public void AddNewEmployee(string firstName, string lastName, string phoneNumber, string address, int permission, Person supervisor, string password)
        {
            _logic.AddNewEmployee(firstName, lastName, phoneNumber, address, permission, supervisor, password);
        }

        public List<string> FillPermissions()
        {
            return _logic.SelectPermissionName();
        }

        public string EmployeePermission(Employee empolyee)
        {
            return _logic.SelectPermissionNameById(empolyee.Permision);
        }

        public int EmployeePermissionId(string name)
        {
            return _logic.SelectPermissionIdByName(name);
        }

        public Person GetSupervisor(int? idEmployee)
        {
            return _logic.GetPersonByIdEmployee(idEmployee.Value);
        }

        public BindingList<Person> FillSupervisors()
        {
            return new BindingList<Person>(_logic.GetPersonEmployeesSupervisors());
        }

        public void UpdateEmployee(string firstName, string lastName, string phoneNumber, string address, int permission, Person supervisor)
        {
            Person person = new Person() { FirstName = firstName, LastName = lastName, PhoneNumber = phoneNumber, Adress = address };
            _logic.UpdateEmployee(person, permission, supervisor);

        }
    }
}
