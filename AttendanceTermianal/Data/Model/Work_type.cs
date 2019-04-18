using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
    public class Work_type
    {
        public Work_type()
        {
        }

        public Work_type(string name)
        {
            Name = name;
        }

        public Work_type(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
