using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
    public class DaySummary
    {
        public string Date { get; set; }
        public DateTime? WorkArrivalTime { get; set; }
        public DateTime? WorkLeavingTime { get; set; }
        public TimeSpan LunchBreak { get; set; } = TimeSpan.Zero;
        public TimeSpan HolidayTime { get; set; } = TimeSpan.Zero;
        public TimeSpan HomeOffice { get; set; } = TimeSpan.Zero;
        public TimeSpan BusinessTrip { get; set; } = TimeSpan.Zero;
        public TimeSpan Doctor { get; set; } = TimeSpan.Zero;
        public TimeSpan Private { get; set; } = TimeSpan.Zero;
        public TimeSpan Other { get; set; } = TimeSpan.Zero;
        public TimeSpan? TotalTimeWorked { get; set; }= TimeSpan.Zero;
    }
}
