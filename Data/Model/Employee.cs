using System;

namespace Data.Model
{
    public class Employee
    {
        public Employee()
        {
        }

        public Employee(string password, int idPerson, int permision, decimal salary)
        {
            Password = password;
            IdPerson = idPerson;
            Permision = permision;
            Salary = salary;
        }

        public Employee(string password, int idPerson, int idSupervisor, int permision, decimal salary)
        {
            Password = password;
            IdPerson = idPerson;
            IdSupervisor = idSupervisor;
            Permision = permision;
            Salary = salary;
        }

        public Employee(string password, int id_person, int id_supervisor, int permision, decimal salary, DateTime hiredDate)
        {
            Password = password;
            IdPerson = id_person;
            IdSupervisor = id_supervisor;
            Permision = permision;
            Salary = salary;
            HiredDate = hiredDate;
        }

        public Employee(string password, int id_person,  int permision, decimal salary, DateTime hiredDate)
        {
            Password = password;
            IdPerson = id_person;
            Permision = permision;
            Salary = salary;
            HiredDate = hiredDate;
        }

        public Employee(int id, string password, int id_person, int id_supervisor, int permision, decimal salary, DateTime hiredDate)
        {
            Id = id;
            Password = password;
            IdPerson = id_person;
            IdSupervisor = id_supervisor;
            Permision = permision;
            Salary = salary;
            HiredDate = hiredDate;
        }

        public Employee(string password, int idPerson, int permision)
        {
            Password = password;
            IdPerson = idPerson;
            Permision = permision;
        }

        public int Id { get; set; }
        public string Password { get; set; }
        public int IdPerson { get; set; }
        public int? IdSupervisor { get; set; }
        public int Permision { get; set; }
        public decimal Salary { get; set; }
        public DateTime HiredDate { get; set; }
    }
}
