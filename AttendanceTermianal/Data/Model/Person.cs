using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
    public class Person
    {
        public Person()
        {
        }

        public Person(int id, string first_name, string last_name, string phone_number, string adress)
        {
            Id = id;
            First_name = first_name;
            Last_name = last_name;
            Phone_number = phone_number;
            Adress = adress;
        }

        public int Id { get; set; }
        public string First_name { get; set; }
        public string Last_name { get; set; }
        public string Phone_number { get; set; }
        public string Adress { get; set; }
    }
}
