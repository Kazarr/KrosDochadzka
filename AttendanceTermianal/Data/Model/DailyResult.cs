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
            Id_employee = id_employee;
            Start = start;
            Finish = finish;
            Id_worktype = id_worktype;
        }

        public DailyResult(int id, int id_employee, DateTime start, DateTime finish, int id_worktype)
        {
            Id = id;
            Id_employee = id_employee;
            Start = start;
            Finish = finish;
            Id_worktype = id_worktype;
        }

        public int Id { get; set; }
        public int Id_employee { get; set; }
        public DateTime Start { get; set; }
        public DateTime Finish { get; set; }
        public int Id_worktype { get; set; }
    }
}
