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
        private RepositoryFactory _repositoryFactory;
        public DailyDetailsViewModel()
        {
            _repositoryFactory = new RepositoryFactory();
        }
        public IEnumerable<DailyResultWithWorkType> GetDailyResultWithWorkTypes (int employeeID, DateTime date)
        {
            return _repositoryFactory.GetDailyRecordRepository().GetSpecifficDailyResult(employeeID, date);
        }

        public bool DeleteDailyResultByID (int dailyResultID)
        {
            return _repositoryFactory.GetDailyRecordRepository().DeleteDailyResult(dailyResultID);
        }

        public Employee GetEmpolyeeById(int employeeId)
        {
            return _repositoryFactory.GetEmployeeRepository().GetEmpolyeeByID(employeeId);
        }

        public DailyRecord GetDailyResultById(int dailyResultId)
        {
            return _repositoryFactory.GetDailyRecordRepository().GetDailyResultByID(dailyResultId);
        }
    }
}
