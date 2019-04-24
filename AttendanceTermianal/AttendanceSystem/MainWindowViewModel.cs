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
    public class MainWindowViewModel
    {
        private Empolyee _empolyee;
        private Person _person;

        public Person Person { get => _person; set {  _person = value;
                                                      Empolyee = GetEmpolyeeByPersonId(Person.Id);}}
        public Empolyee Empolyee { get => _empolyee; set => _empolyee = value; }
        public Empolyee GetEmployeeByID(int id)
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
        public Empolyee GetEmpolyeeByPersonId(int id)
        {
            return ManagerRepository.EmployeeRepository.GetEmpolyeeByIdPerson(id);
        }
    }
}
