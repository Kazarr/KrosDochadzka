using System;

namespace Data.Model
{
    public class DailyRecord
    {
        public int Id { get; set; }
        public int IdEmployee { get; set; }
        public DateTime Start { get; set; }
        public DateTime? Finish { get; set; }
        public int IdWorktype { get; set; }
    }
}
