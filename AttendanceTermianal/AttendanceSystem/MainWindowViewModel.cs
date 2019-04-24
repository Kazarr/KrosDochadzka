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
    class MainWindowViewModel
    {
        public Empolyee GetEmployeeByID(int id)
        {
            return ManagerRepository.EmployeeRepository.GetEmpolyeeByID(id);
        }
        public BindingList<Person> FillComboBox()
        {
            return new BindingList<Person>(ManagerRepository.PersonRepository.GetPersonsEmployees().ToList());
        }

        public IDictionary<string, int> GetMonthWithNumberOfRecords(int id)
        {
            return ManagerRepository.DailyResultRepository.GetMonthsWithNumberOfRecords(id);
        }

        public List<string> FillDGV(DateTime date, int idEmployee)
        {
            return ManagerRepository.DaySummaryRepository.MakeLine(date, idEmployee);
        }

        public Dictionary<string, List<string >> getApril(int idEmployee){
            return ManagerRepository.DaySummaryRepository.April(idEmployee);
}
    }
}
