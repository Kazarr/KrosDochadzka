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
        private RepositoryFactory _repositoryFactory;

        public MainWindowViewModel()
        {
            _repositoryFactory = new RepositoryFactory();
        }

        public Person Person { get => _person; set {  _person = value;
                                                      Employee = GetEmpolyeeByPersonId(Person.Id);}}


        public Employee Employee { get => _employee; set => _employee = value; }


        public Employee GetEmployeeByID(int id)
        {
            return _repositoryFactory.GetEmployeeRepository().GetEmpolyeeByID(id);
        }


        public BindingList<Person> FillComboBox()
        {
            return new BindingList<Person>(_repositoryFactory.GetPersonRepository().GetPersonsEmployees().ToList());
        }

        public BindingList<Person> FillComboBox(int idSupervisor)
        {
            return new BindingList<Person>(_repositoryFactory.GetPersonRepository().GetPersonEmployeesPlebs(idSupervisor).ToList());
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
            return _repositoryFactory.GetDailyRecordRepository().GetMonthsWithNumberOfRecords(id);
        }

        public Person GetPersonByEmployeeId(int employeeId)
        {
            return _repositoryFactory.GetPersonRepository().GetPersonByIdEmployee(employeeId);
        }

        public Person GetPersonByEmployee(Person person)
        {
            return _repositoryFactory.GetPersonRepository().GetPersonByIdEmployee(person.Id);
        }

        public Employee GetEmpolyeeByPersonId(int id)
        {
            return _repositoryFactory.GetEmployeeRepository().GetEmpolyeeByIdPerson(id);
        }

        public Employee GetEmpolyeeByPersonId(Person person)
        {
            return _repositoryFactory.GetEmployeeRepository().GetEmpolyeeByIdPerson(person);
        }

        public int GetEmployeeIdByPerson(Person selectedItem)
        {
            return _repositoryFactory.GetEmployeeRepository().GetEmpolyeeByIdPerson(selectedItem.Id).Id;
        }

        public void DeleteEmployeePerson(Person person)
        {

            Employee e = _repositoryFactory.GetEmployeeRepository().GetEmpolyeeByIdPerson(person.Id);
            _repositoryFactory.GetDailyRecordRepository().DeleteDailyResultByIdEmployee(e.Id);
            _repositoryFactory.GetEmployeeRepository().DeleteEmployee(e);
            //ManagerRepository.PersonRepository.DeletePerson(person);//nemusime mazat z osoby

        }

        public BindingList<Person> FillPlebPerson(int employeeId)
        {
            BindingList<Person> ret = new BindingList<Person>
            {
                _repositoryFactory.GetPersonRepository().GetPersonByIdEmployee(employeeId)
            };
            return ret;
        }
        public bool ResetPassword()
        {
            return _logic.ChangePassword(_repositoryFactory.GetEmployeeRepository().GetEmpolyeeByIdPerson(Person.Id).Id, "0000");
        }
    }
}
