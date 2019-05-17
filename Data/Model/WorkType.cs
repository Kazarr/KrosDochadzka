using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
    public class WorkType
    {
        public WorkType()
        {
        }

        public WorkType(string name)
        {
            Name = name;
        }

        public WorkType(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
