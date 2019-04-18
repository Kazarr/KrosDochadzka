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
    }
}
