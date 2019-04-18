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

        public Person(string first_name, string last_name, string phone_number, string adress)
        {
            FirstName = first_name;
            LastName = last_name;
            PhoneNumber = phone_number;
            Adress = adress;
        }

        public Person(int id, string first_name, string last_name, string phone_number, string adress)
        {
            Id = id;
            FirstName = first_name;
            LastName = last_name;
            PhoneNumber = phone_number;
            Adress = adress;
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Adress { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(FirstName);
            sb.Append(" ");
            sb.AppendLine(LastName);
            return sb.ToString();
        }
    }
}
