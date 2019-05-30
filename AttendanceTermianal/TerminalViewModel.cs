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
        /// HLavna funkcua pre buttony
        /// </summary>
        /// <param name="employeeId"></param>
        /// <param name="type"></param>
        //public void ProcessAction(int employeeId, EnumWorkType type)
        //{
        //    if (type == EnumWorkType.Exit)
        //    {
        //        _logic.ExitTimeBlock(employeeId);
        //    }
        //    else
        //    {
        //        _logic.CreateNewAndFinishPreviousRecord(employeeId, type);
        //    }
        //}
    }
}
