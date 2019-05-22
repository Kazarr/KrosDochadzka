using System.Text;

namespace Data.Model
{
    public class Person
    {
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
