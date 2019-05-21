using Data.Model;
using Data.Repository;
using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceTermianal
{

    
    public class TerminalViewModel
    {
        private LogicTerminal _logic;

        public TerminalViewModel(LogicTerminal logic)
        {
            _logic = logic;
        }

        public string CurrentDate()
        {
            return DateTime.Now.ToString("dd.MM.yyyy");
        }
        public string CurrentDay()
        {
            return DateTime.Now.ToString("dddd");
            
        }
        public string CurrentHourmin()
        {
            return DateTime.Now.ToString("HH:mm");
   
        }
        public string CurrentSec()
        {
            return DateTime.Now.ToString("ss");
            
        }

        public string DescriptionFullname(int id_employee)
        {
            string fullName = $"{_logic.GetPersonByIdEmployee(id_employee).FirstName} " +
                                $"{_logic.GetPersonByIdEmployee(id_employee).LastName} ";
            return fullName;
        }
        public string DescriptionWorkType(EnumWorkType type)
        {
            string workT = type.ToString();
            return workT;
        }
        public string DescriptionDate()
        {
            string date = DateTime.Now.ToString("dd.MM.yyyy" + " | " + "HH:mm");
            return date;
        }

        /// <summary>
        /// kontroluje či pod zadaným ID existuje nejaký employee
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public bool CorrectEmp(string input)
        {
            try
            {
                var empoloyee = _logic.GetEmpolyeeByID(int.Parse(input));
                return empoloyee != null && empoloyee.Id.Equals(int.Parse(input));
            }
            catch (FormatException)
            {
                return false;
            }      
        }

        public void ExitDailyResult(int idEmployee)
        {
            _logic.FinishWork(idEmployee);
        }

        public void CreateNewDailyResult(int idEmployee, EnumWorkType type)
        {
            _logic.ChangeWorkType(idEmployee,type);
        }
    }
}
