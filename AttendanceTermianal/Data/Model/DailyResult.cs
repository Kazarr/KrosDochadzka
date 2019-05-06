using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
    public class DailyResult
    {
        public DailyResult()
        {
        }

        public DailyResult(int id_employee, DateTime start, DateTime finish, int id_worktype)
        {
            IdEmployee = id_employee;
            Start = start;
            Finish = finish;
            IdWorktype = id_worktype;
        }

        public DailyResult(int id, int id_employee, DateTime start, DateTime finish, int id_worktype)
        {
            Id = id;
            IdEmployee = id_employee;
            Start = start;
            Finish = finish;
            IdWorktype = id_worktype;
        }

        public int Id { get; set; }
        public int IdEmployee { get; set; }
        public DateTime Start { get; set; }
        public DateTime? Finish { get; set; }
        public int IdWorktype { get; set; }
        public int MyProperty { get; set; }
    }
}
