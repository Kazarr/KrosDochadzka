using Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceTermianal
{
    public class TerminalViewModel
    {
        public string CurrentDate()
        {
            string date = DateTime.Now.ToString("dd/MM/yyyy");
            return date;
        }
        public string CurrentDay()
        {
            string day = DateTime.Now.ToString("dddd");
            return day;
        }
        public string CurrentHourmin()
        {
            string day = DateTime.Now.ToString("HH:mm");
            return day;
        }
        public string CurrentSec()
        {
            string day = DateTime.Now.ToString("ss");
            return day;
        }

        public string EmployeeDescription(int id)
        {
            //StringBuilder employeeDescription = new StringBuilder();
            string fullName = $"{ManagerRepository.personRepository.GetPersonByIdEmployee(id).First_name} " +
                                $"{ManagerRepository.personRepository.GetPersonByIdEmployee(id).Last_name} " +
                                $"{DateTime.Now}";
            return fullName;                   
        }
        public Tuple<bool, int> IsCorrectId(string input)
        {
            int Id = 0;
            bool isOk = int.TryParse(input, out Id);
            if (isOk)
            {
                return new Tuple<bool, int>(true, Id);
            }
            return new Tuple<bool, int>(false, Id);
        }

    }
}
