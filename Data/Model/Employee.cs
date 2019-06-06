using System;

namespace Data.Model
{
    public class Employee
    {
        public int Id { get; set; }
        public string Password { get; set; }
        public int IdPerson { get; set; }
        public int? IdSupervisor { get; set; }
        public int IdPermission { get; set; }
        public decimal Salary { get; set; }
        public DateTime HiredDate { get; set; }
    }
}
