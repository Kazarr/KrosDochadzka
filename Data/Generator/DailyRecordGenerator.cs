using Data.Model;
using Data.Repository;
using System;
using System.Collections.Generic;

namespace Data.Generator
{
    public class DailyRecordGenerator
    {
        private DailyRecord _record = new DailyRecord();
        private EmployeeRepository _employeeRepository = new EmployeeRepository();
        private Random random = new Random();
        private DailyRecordRepository _dailyRecordRespository = new DailyRecordRepository();

        private void GenerateRandomWorkRecord(DateTime date)
        {

            DateTime start = DateTime.Today.AddHours(7);
            start = start.AddMinutes(random.Next(241));
            _record.Start = date.Date + start.TimeOfDay;
            _record.Finish = _record.Start.AddMinutes(240 + random.Next(400));
            _record.IdWorktype = (int)EnumWorkType.Work;
        }

        private IEnumerable<DateTime> EachDay(DateTime from, DateTime thru)
        {
            for (var day = from.Date; day.Date <= thru.Date; day = day.AddDays(1))
                if (day.DayOfWeek != DayOfWeek.Saturday && day.DayOfWeek != DayOfWeek.Sunday)
                {
                    yield return day;
                }
        }

        private void LoopThruoughtTime(DateTime from, DateTime thru, int employeeID)
        {
            foreach (var date in EachDay(from, thru))
            {
                GenerateRandomWorkRecord(date);
                _record.IdEmployee = employeeID;
                _dailyRecordRespository.InsertNewDailyResultFromSystem(_record);
            }
        }

        public void GiveRecordsToEmployee()
        {
            foreach (var employee in _employeeRepository.GetEmpolyees())
            {
                LoopThruoughtTime(employee.HiredDate, DateTime.Now.AddDays(-1), employee.Id);
            }
        }

    }
}
