using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
    public class Daily_Result
    {
        public int Id { get; set; }
        public int Id_employee { get; set; }
        public DateTime Start { get; set; }
        public DateTime Finish { get; set; }
        public int Id_worktype { get; set; }
    }
}
