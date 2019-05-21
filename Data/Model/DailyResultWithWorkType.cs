using System;

namespace Data.Model
{
    public class DailyResultWithWorkType
    {
        public int DailyResultID { get; set; }
        public int IdEmployee { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? FinishTime { get; set; }
        public string  WorkType { get; set; }

    }
}
