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
            //default person if none is selected
            //Person = _logic.GetPersonByIdEmployee(1);
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
            List<Person> ret = _logic.GetPersonsEmployees().ToList();
            Person = ret[0];
            return new BindingList<Person>(ret);
        }

        public BindingList<Person> FillComboBox(int idSupervisor)
        {
            List<Person> ret = _logic.GetPersonEmployeesPlebs(idSupervisor).ToList();
            Person = ret.FirstOrDefault();
            return new BindingList<Person>(ret);
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

        public void DeleteEmployeePerson(Person person,int supervisorID)
        {

            Employee employee = _logic.GetEmpolyeeByIdPerson(person.Id);
            _logic.DeleteEmployee(employee,supervisorID);

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
