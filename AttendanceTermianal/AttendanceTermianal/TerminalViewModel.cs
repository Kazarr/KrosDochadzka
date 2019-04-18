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
            string date = DateTime.Now.ToString("dd MM yyyy");
            return date;
        }

    }
}
