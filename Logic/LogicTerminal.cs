using Data.Model;
using Data.Repository;
using System;

namespace Logic
{
    public class LogicTerminal
    {
        private RepositoryFactory _repositoryFactory;

        public LogicTerminal()
        {
            _repositoryFactory = new RepositoryFactory();
        }
        public void CreateNewTimeBlock(int idEmployee, EnumWorkType type, DateTime startTime, DateTime? finishTime = null)
        {
            DailyRecord dailyRecord = new DailyRecord
            {
                Start = startTime,
                Finish = finishTime,
                IdEmployee = idEmployee,
                IdWorktype = (int)type
            };
            _repositoryFactory.GetDailyRecordRepository().InsertDialyRecord(dailyRecord);
        }

        public void UpdateFinishInTimeBlock(DailyRecord dailyRecord, DateTime finishTime)
        {
                dailyRecord.Finish = finishTime;
                _repositoryFactory.GetDailyRecordRepository().UpdateDailyRecord(dailyRecord);            
        }

        public void CreateNewAndFinishPreviousRecord(int employeeId, EnumWorkType type)
        {
            DateTime currentTime = DateTime.Now;
            DailyRecord dailyRecord = _repositoryFactory.GetDailyRecordRepository().GetLastDailyRecordByEmployeeId(employeeId);
            if (dailyRecord != null)
            {
                if (dailyRecord.Finish == null)
                {
                    UpdateFinishInTimeBlock(dailyRecord, currentTime);
                }
                else
                {
                    CreateNewTimeBlock(employeeId, EnumWorkType.Other, (DateTime)dailyRecord.Finish, currentTime);   
                }               
            }
            CreateNewTimeBlock(employeeId, type, currentTime);
        }
    }
}
