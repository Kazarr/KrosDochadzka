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

        public string DescriptionFullname(int employeeId)
        {
            string fullName = $"{_logic.GetPersonByIdEmployee(employeeId).FirstName} " +
                                $"{_logic.GetPersonByIdEmployee(employeeId).LastName} ";
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
        /// <summary>
        /// Ak pre daného zamestnanca neexistuje žiaden záznam pre dnešný deň, vytvorím nový záznam
        /// v ktorom mu nastavím start a finish time na aktuálny |||||DOVOD|||| - aby som nestratil čas odchodu,ak si zamestnanec nedal príchod
        /// </summary>
        /// <param name="employeeId"></param>
        public void ExitDailyRecord(int employeeId)
        {
            DailyRecord dailyRecord = _logic.GetLastDailyRecordByEmployeeId(employeeId);
            if (dailyRecord == null)
            {
                _logic.CreateNewTimeBlock(employeeId, EnumWorkType.Other, DateTime.Now,DateTime.Now);
            }
            else
            {
                _logic.UpdateFinishInTimeBlock(dailyRecord,DateTime.Now);
            }
        }

        public void CreateNewAndFinishPreviousRecord(int employeeId, EnumWorkType type)
        {
            _logic.CreateNewAndFinishPreviousRecord(employeeId,type);
        }
    }
}
