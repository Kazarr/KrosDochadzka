using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class ManagerRepository
    {
        public static DialyResultRepository dialyResultRepository = new DialyResultRepository();
        public static EmployeeRepository employeeRepository = new EmployeeRepository();
        public static PersonRepository personRepository = new PersonRepository();
        public static WorkTypeRepository workTypeRepository = new WorkTypeRepository();
    }
}
