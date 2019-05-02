using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class ManagerRepository
    {
        public static DailyResultRepository DailyResultRepository = new DailyResultRepository();
        public static EmployeeRepository EmployeeRepository = new EmployeeRepository();
        public static PersonRepository PersonRepository = new PersonRepository();
        public static WorkTypeRepository WorkTypeRepository = new WorkTypeRepository();
        public static DaySummaryRepository DaySummaryRepository = new DaySummaryRepository();
        public static PermissionRepository PermissionRepository = new PermissionRepository();
    }
}
