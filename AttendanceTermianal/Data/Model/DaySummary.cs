using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
    public class DaySummary
    {
        public List<DailyResult> Work { get; set; }
        public List<DailyResult> Lunch { get; set; }
        public List<DailyResult> Holiday { get; set; }
        public List<DailyResult> HomeOffice { get; set; }
        public List<DailyResult> BusinessTrip { get; set; }
        public List<DailyResult> Doctor { get; set; }
        public List<DailyResult> Private { get; set; }
        public List<DailyResult> Other { get; set; }
    }
}
