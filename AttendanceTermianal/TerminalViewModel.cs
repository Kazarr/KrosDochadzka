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
        public bool IsCorrectEmp(int employeeId)
        {
            try
            {
                var empoloyee = _logic.GetEmpolyeeByID(employeeId);
                return empoloyee != null && empoloyee.Id.Equals(employeeId);
            }
            catch (FormatException)
            {
                return false;
            }
        }

        /// <summary>
        /// HLavna funkcua pre buttony
        /// </summary>
        /// <param name="employeeId"></param>
        /// <param name="type"></param>
        public void ProcessAction(int employeeId, EnumWorkType type)
        {
            if (type == EnumWorkType.Exit)
            {
                _logic.ExitTimeBlock(employeeId);
            }
            else
            {
                _logic.CreateNewAndFinishPreviousRecord(employeeId, type);
            }
        }
    }
}
