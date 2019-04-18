using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
    public class Empolyee
    {
        public int Id { get; set; }
        public string Password { get; set; }
        public int Id_person { get; set; }
        public int Id_supervisor { get; set; }
        public int Permision { get; set; }
        public decimal Salary { get; set; }
        public DateTime HiredDate { get; set; }
    }
}
