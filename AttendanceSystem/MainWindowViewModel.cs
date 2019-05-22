using Data.Model;
using Logic;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace AttendanceSystem
{
    public class MainWindowViewModel
    {
        private LogicSystem _logic;
        private Employee _employee;
        private Person _person;

        public MainWindowViewModel(LogicSystem logic)
        {
            _logic = logic;
        }

        public Person Person
        {
            get => _person; set
            {
                _person = value;
                Employee = GetEmpolyeeByPersonId(Person.Id);
            }
        }


        public Employee Employee { get => _employee; set => _employee = value; }

        public Employee GetEmployeeByID(int id)
        {
            return _logic.GetEmpolyeeByID(id);
        }

        public BindingList<Person> FillComboBox()
        {
            return new BindingList<Person>(_logic.GetPersonsEmployees().ToList());
        }

        public BindingList<Person> FillComboBox(int idSupervisor)
        {
            return new BindingList<Person>(_logic.GetPersonEmployeesPlebs(idSupervisor).ToList());
        }

        public BindingList<DaySummary> FillDataGridViewOverview(int id, string date)
        {

            return new BindingList<DaySummary>(_logic.GetSummariesByMonth(date, id));
        }

        public BindingList<int> FillYears(int IdEmployee)
        {
            return new BindingList<int>(_logic.GetYearsFromEmploymentStartByEmployee(IdEmployee));
        }

        public Employee GetEmpolyeeByPersonId(int id)
        {
            return _logic.GetEmpolyeeByIdPerson(id);
        }

        public int GetEmployeeIdByPerson(Person selectedItem)
        {
            return _logic.GetEmpolyeeByIdPerson(selectedItem.Id).Id;
        }

        public void DeleteEmployeePerson(Person person)
        {

            Employee employee = _logic.GetEmpolyeeByIdPerson(person.Id);
            _logic.DeleteDailyResultByIdEmployee(employee.Id);
            _logic.DeleteEmployee(employee);

        }

        public BindingList<Person> FillPlebPerson(int employeeId)
        {
            BindingList<Person> ret = new BindingList<Person>
            {
                _logic.GetPersonByIdEmployee(employeeId)
            };
            return ret;
        }

        public bool ResetPassword()
        {
            // 0000 je základne resetovacie heslo
            return _logic.ChangePasswordByEmployeeId(_logic.GetEmpolyeeByIdPerson(Person.Id).Id, "0000");
        }
    }
}
