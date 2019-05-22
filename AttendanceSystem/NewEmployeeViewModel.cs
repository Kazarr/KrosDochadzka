using Data.Model;
using Data.Repository;
using Logic;
using System.Collections.Generic;
using System.ComponentModel;

namespace AttendanceSystem
{
    public class NewEmployeeViewModel
    {
        private LogicSystem _logic = new LogicSystem();
        public Employee Employee { get; set; }
        public Person Person { get; set; }
        public Person Supervisor { get; set; }
        private RepositoryFactory _repositoryFactory;

        public NewEmployeeViewModel(Person person, Employee empolyee)
        {
            Person = person;
            Employee = empolyee;
            Supervisor = GetSupervisor(Employee.Id);
            _repositoryFactory = new RepositoryFactory();
        }

        public NewEmployeeViewModel()
        {
            _repositoryFactory = new RepositoryFactory();
            Employee = new Employee();
            Person = new Person();
        }

        public void AddNewEmployee(string firstName, string lastName, string phoneNumber, string address, int permission, Person supervisor, string password)
        {
            _logic.AddNewEmployee(firstName, lastName, phoneNumber, address, permission, supervisor, password);
        }

        public List<string> FillPermissions()
        {
            return _repositoryFactory.GetPermissionRepository().SelectPermissionName();
        }

        public string EmployeePermission(Employee empolyee)
        {
            return _repositoryFactory.GetPermissionRepository().SelectPermissionNameById(empolyee.Permision);
        }

        public int EmployeePermissionId(string name)
        {
            return _repositoryFactory.GetPermissionRepository().SelectPermissionIdByName(name);
        }

        public Person GetSupervisor(int? idEmployee)
        {
            return _repositoryFactory.GetPersonRepository().GetPersonByIdEmployee(idEmployee.Value);
        }

        public BindingList<Person> FillSupervisors()
        {
            return new BindingList<Person>(_repositoryFactory.GetPersonRepository().GetPersonEmployeesSupervisors());
        }

        public void UpdateEmployee(string firstName, string lastName, string phoneNumber, string address, int permission, Person supervisor)
        {
            _logic.UpdateEmployee(firstName, lastName, phoneNumber, address, permission, supervisor);

        }
    }
}
