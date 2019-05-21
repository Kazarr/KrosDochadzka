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
        private LogicTerminal _logicTerminal = new LogicTerminal();

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
            string fullName = $"{ManagerRepository.PersonRepository.GetPersonByIdEmployee(id_employee).FirstName} " +
                                $"{ManagerRepository.PersonRepository.GetPersonByIdEmployee(id_employee).LastName} ";
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
                var empoloyee = ManagerRepository.EmployeeRepository.GetEmpolyeeByID(int.Parse(input));
                return empoloyee != null && empoloyee.Id.Equals(int.Parse(input));
                           
            }
            catch (FormatException)
            {
                return false;
            }      
        }

        public void ExitDailyResult(int idEmployee)
        {
            _logicTerminal.FinishWork(idEmployee);
        }

        public void CreateNewDailyResult(int idEmployee, EnumWorkType type)
        {
            _logicTerminal.ChangeWorkType(idEmployee,type);
        }
    }
}
