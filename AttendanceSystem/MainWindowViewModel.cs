using Data.Model;
using Data.Repository;
using Logic;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace AttendanceSystem
{
    public class MainWindowViewModel
    {
        private LogicSystem _logic = new LogicSystem();
        private Employee _employee;
        private Person _person;

        public MainWindowViewModel()
        {

        }

        public Person Person { get => _person; set {  _person = value;
                                                      Employee = GetEmpolyeeByPersonId(Person.Id);}}


        public Employee Employee { get => _employee; set => _employee = value; }


        public Employee GetEmployeeByID(int id)
        {
            return ManagerRepository.EmployeeRepository.GetEmpolyeeByID(id);
        }


        public BindingList<Person> FillComboBox()
        {
            return new BindingList<Person>(ManagerRepository.PersonRepository.GetPersonsEmployees().ToList());
        }

        public BindingList<Person> FillComboBox(int idSupervisor)
        {
            return new BindingList<Person>(ManagerRepository.PersonRepository.GetPersonEmployeesPlebs(idSupervisor).ToList());
        }

        public BindingList<DaySummary> FillDataGridViewOverview(int id, string date)
        {
            
            return new BindingList<DaySummary>(_logic.GetSummariesByMonth(date, id));
        }

        public BindingList<int> FillYears(int IdEmployee)
        {
            return new BindingList<int>(_logic.GetYearsFromStart(IdEmployee));
        }


        public IDictionary<string, int> GetMonthWithNumberOfRecords(int id)
        {
            return ManagerRepository.DailyResultRepository.GetMonthsWithNumberOfRecords(id);
        }

        public Person GetPersonByEmployeeId(int employeeId)
        {
            return ManagerRepository.PersonRepository.GetPersonByIdEmployee(employeeId);
        }

        public Person GetPersonByEmployee(Person person)
        {
            return ManagerRepository.PersonRepository.GetPersonByIdEmployee(person.Id);
        }

        public Employee GetEmpolyeeByPersonId(int id)
        {
            return ManagerRepository.EmployeeRepository.GetEmpolyeeByIdPerson(id);
        }

        public Employee GetEmpolyeeByPersonId(Person person)
        {
            return ManagerRepository.EmployeeRepository.GetEmpolyeeByIdPerson(person);
        }

        public int GetEmployeeIdByPerson(Person selectedItem)
        {
            return ManagerRepository.EmployeeRepository.GetEmpolyeeByIdPerson(selectedItem.Id).Id;
        }

        public void DeleteEmployeePerson(Person person)
        {
            Employee e = ManagerRepository.EmployeeRepository.GetEmpolyeeByIdPerson(person.Id);
            ManagerRepository.DailyResultRepository.DeleteDailyResultByIdEmployee(e.Id);
            ManagerRepository.EmployeeRepository.DeleteEmployee(e);
        }

        public BindingList<Person> FillPlebPerson(int employeeId)
        {
            BindingList<Person> ret = new BindingList<Person>
            {
                ManagerRepository.PersonRepository.GetPersonByIdEmployee(employeeId)
            };
            return ret;
        }
        public bool ResetPassword()
        {
            return _logic.ChangePasswordByEmployeeId(ManagerRepository.EmployeeRepository.GetEmpolyeeByIdPerson(Person.Id).Id, "0000");
        }
    }
}
