using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
   public class MonthOverview
    {
        public int Id { get; set; }
        public int IdEmployee { get; set; }
        public DateTime Month { get; set; }
        public TimeSpan HoursWorked { get; set; }
        public TimeSpan Overtime { get; set; }
        public TimeSpan Doctor { get; set; }
        public TimeSpan Private { get; set; }
        public TimeSpan Holiday { get; set; }
        public TimeSpan BsTrip { get; set; }
    }
}
