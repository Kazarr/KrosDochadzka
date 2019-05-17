using Data.Model;
using Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem
{
    class DailyDetailsAddEditViewModel
    {
        public List<string> GetWorkTypes()
        {
            List<string> ret = new List<string>();
            IEnumerable<WorkType> myList= ManagerRepository.WorkTypeRepository.GetWorkType(); 

            foreach (var item in myList)
            {
                ret.Add($"{item.Id} : {item.Name}");
            }
            return ret;
        }

        /// <summary>
        /// create new Daily Results by the data from System manualy entered
        /// </summary>
        /// <param name="employeeID"></param>
        /// <param name="startTime"></param>
        /// <param name="finishTime"></param>
        /// <param name="workTypeID"></param>
        /// <returns> true if new daily result was added, othervise false</returns>
        public bool CreateNewDailyResult(int employeeID, DateTime startTime, DateTime finishTime,int workTypeID) {

            DailyResult dailyResult = new DailyResult();
            dailyResult.IdEmployee = employeeID;
            dailyResult.Start = startTime;
            dailyResult.Finish = finishTime;
            dailyResult.IdWorktype = workTypeID;
            if (ManagerRepository.DailyResultRepository.InsertNewDailyResultFromSystem(dailyResult))
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
        
        /// <summary>
        /// update existing Daily Result
        /// </summary>
        /// <param name="updatedDailyResult"></param>
        /// <returns>true if update happend, otherwise false</returns>
        public bool UpdateDailyResult (DailyResult updatedDailyResult)
        {
            return ManagerRepository.DailyResultRepository.UpdateDailyResult(updatedDailyResult);
        }
    }
}
