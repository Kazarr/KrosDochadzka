using Data.Model;
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
      
        private DailyResult _result = new DailyResult();
        private Empolyee _empolyee = new Empolyee();
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

        public string EmployeeDescription(int id_employee, string workType)
        {
            string fullName = $"{ManagerRepository.PersonRepository.GetPersonByIdEmployee(id_employee).FirstName} " +
                                $"{ManagerRepository.PersonRepository.GetPersonByIdEmployee(id_employee).LastName} " +
                                $"{workType} " + 
                                $"{DateTime.Now}";
            return fullName;
        }
        public bool CorrectEmp(string input)
        {
            try
            {
                var empoloyee = ManagerRepository.EmployeeRepository.GetEmpolyeeByID(int.Parse(input));
                if (empoloyee != null && empoloyee.Id.Equals(int.Parse(input)))
                {
                    return true;
                }
                else
                {
                    return false;
                }               
            }
            catch (FormatException)
            {
                return false;
            }      
        }
        private void StartWork(int id_employee, EWorkType type)
        {
            _result.IdWorktype = (int)type;
            _result.IdEmployee = id_employee;
            _result.Id = ManagerRepository.DailyResultRepository.InsertDialyResult(_result);           
        }
        public bool FinishWork(int id_employee, EWorkType type)
        {
            _result.IdWorktype = (int)type;
            _result.IdEmployee = id_employee;
            if (ManagerRepository.DailyResultRepository.CheckIfWorkDailyExist(_result)== null)
            {
                return ManagerRepository.DailyResultRepository.UpdateFinishDailyResult(_result);
            }
            return false;
            
        }
        public void ChangeWorkType(int id_employee, EWorkType type)
        {
            if (!CheckDailyResult(id_employee, type))
            {
                FinishWork(id_employee, type);
                StartWork(id_employee, type);
            }           
        }
        public bool CheckDailyResult(int id_employee, EWorkType type)
        {
            _result.IdWorktype = (int)type;
            _result.IdEmployee = id_employee;
            return ManagerRepository.DailyResultRepository.CheckIfDailyResultExist(_result);
        }
    }
}
