using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class ManagerRepository
    {
        public static DailyResultRepository DialyResultRepository = new DailyResultRepository();
        public static EmployeeRepository EmployeeRepository = new EmployeeRepository();
        public static PersonRepository PersonRepository = new PersonRepository();
        public static WorkTypeRepository WorkTypeRepository = new WorkTypeRepository();
    }
}
