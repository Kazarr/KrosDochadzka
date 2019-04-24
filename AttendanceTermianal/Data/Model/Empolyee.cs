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

        public Empolyee(string password, int idPerson, int idSupervisor, int permision, decimal salary)
        {
            Password = password;
            IdPerson = idPerson;
            IdSupervisor = idSupervisor;
            Permision = permision;
            Salary = salary;
        }

        public Empolyee(string password, int id_person, int id_supervisor, int permision, decimal salary, DateTime hiredDate)
        {
            Password = password;
            IdPerson = id_person;
            IdSupervisor = id_supervisor;
            Permision = permision;
            Salary = salary;
            HiredDate = hiredDate;
        }

        public Empolyee(int id, string password, int id_person, int id_supervisor, int permision, decimal salary, DateTime hiredDate)
        {
            Id = id;
            Password = password;
            IdPerson = id_person;
            IdSupervisor = id_supervisor;
            Permision = permision;
            Salary = salary;
            HiredDate = hiredDate;
        }

        public int Id { get; set; }
        public string Password { get; set; }
        public int IdPerson { get; set; }
        public int IdSupervisor { get; set; }
        public int Permision { get; set; }
        public decimal Salary { get; set; }
        public DateTime HiredDate { get; set; }
    }
}
