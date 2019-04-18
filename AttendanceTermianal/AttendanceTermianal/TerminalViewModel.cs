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

        //public string Meno()
        //{
        //    ManagerRepository.dialyResultRepository.
        //}

    }
}
