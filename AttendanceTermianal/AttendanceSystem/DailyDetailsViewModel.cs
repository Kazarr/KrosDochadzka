using Data.Model;
using Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem
{
    class DailyDetailsViewModel
    {
        public IEnumerable<DailyResultWithWorkType> GetDailyResultWithWorkTypes (int employeeID, DateTime date)
        {
            return ManagerRepository.DailyResultRepository.GetSpecifficDailyResult(employeeID, date);
        }

        public bool DeleteDailyResultByID (int dailyResultID)
        {
            return ManagerRepository.DailyResultRepository.DeleteDailyResult(dailyResultID);
        }
    }
}
