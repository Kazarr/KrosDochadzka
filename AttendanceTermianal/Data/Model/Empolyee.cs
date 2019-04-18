using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
    public class Empolyee
    {
        public Empolyee()
        {
        }

        public Empolyee(string password, int id_person, int id_supervisor, int permision, decimal salary, DateTime hiredDate)
        {
            Password = password;
            Id_person = id_person;
            Id_supervisor = id_supervisor;
            Permision = permision;
            Salary = salary;
            HiredDate = hiredDate;
        }

        public Empolyee(int id, string password, int id_person, int id_supervisor, int permision, decimal salary, DateTime hiredDate)
        {
            Id = id;
            Password = password;
            Id_person = id_person;
            Id_supervisor = id_supervisor;
            Permision = permision;
            Salary = salary;
            HiredDate = hiredDate;
        }

        public int Id { get; set; }
        public string Password { get; set; }
        public int Id_person { get; set; }
        public int Id_supervisor { get; set; }
        public int Permision { get; set; }
        public decimal Salary { get; set; }
        public DateTime HiredDate { get; set; }
    }
}
