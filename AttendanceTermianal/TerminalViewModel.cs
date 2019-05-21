using Data.Model;
using Logic;
using System;

namespace AttendanceTermianal
{


    public class TerminalViewModel
    {
        private LogicTerminal _logic;

        public TerminalViewModel(LogicTerminal logic)
        {
            _logic = logic;
        }

        /// <summary>
        /// nastavenie dizajnu, rozne fonty pre rozne casove zlozky
        /// </summary>
        /// <returns></returns>
        public string DescriptionFullname(int employeeId)
        {
            return $"{_logic.GetPersonByIdEmployee(employeeId).FirstName} " +
                                $"{_logic.GetPersonByIdEmployee(employeeId).LastName} ";
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
                _logic.CreateNewTimeBlock(employeeId, EnumWorkType.Other, DateTime.Now, DateTime.Now);
            }
            else
            {
                _logic.UpdateFinishInTimeBlock(dailyRecord, DateTime.Now);
            }
        }

        /// <summary>
        /// HLavna funkcua pre buttony
        /// </summary>
        /// <param name="employeeId"></param>
        /// <param name="type"></param>
        public void CreateNewAndFinishPreviousRecord(int employeeId, EnumWorkType type)
        {
            _logic.CreateNewAndFinishPreviousRecord(employeeId, type);
        }
    }
}
