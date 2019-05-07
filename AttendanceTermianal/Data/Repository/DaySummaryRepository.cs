using Data.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Globalization;
using System.Linq;

namespace Data.Repository
{
    public class DaySummaryRepository : ConnectionManager
    {
        
        private DateTime? GetArrivalTime(DateTime date, int idEmployee)
        {

            DateTime? ret = null;
            Execute((command) => {
                command.CommandText = @"select min(dr.[Start]) from DailyResult as dr
                                                where dr.IdEmployee=@idEmployee  and dr.IdWorktype=1 and convert(date,dr.start)=convert(date,@date)";

                command.Parameters.Add("@idEmployee", SqlDbType.Int).Value = idEmployee;
                command.Parameters.Add("@date", SqlDbType.NVarChar).Value = date;
                ret = command.ExecuteScalar() as DateTime?;

            });
            return ret;
        }


        private DateTime? GetLeavingTime(DateTime date, int idEmployee)
        {
            DateTime? ret = null;
            Execute((command) =>
            {
                command.CommandText = @"select max(dr.[Finish]) from DailyResult as dr
                                                where dr.IdEmployee=@idEmployee  and dr.IdWorktype=1 and convert(date,dr.start)=convert(date,@date)";

                command.Parameters.Add("@idEmployee", SqlDbType.Int).Value = idEmployee;
                command.Parameters.Add("@date", SqlDbType.NVarChar).Value = date;
                ret = command.ExecuteScalar() as DateTime?;
            });
            return ret;
        }


        // TODO prec
        public DaySummary CreateDaySummary(DateTime date, int idEmployee)
        {
            DaySummary daySummary = new DaySummary();

            daySummary.Date = date.Date.ToString("MM-dd-yyyy");
            daySummary.WorkArrivalTime = GetArrivalTime(date, idEmployee);
            daySummary.WorkLeavingTime = GetLeavingTime(date, idEmployee);
            daySummary.LunchBreak = GetTimeSpendOnDailyResults(date, idEmployee, 2);
            daySummary.HolidayTime = GetTimeSpendOnDailyResults(date, idEmployee, 3);
            daySummary.HomeOffice = GetTimeSpendOnDailyResults(date, idEmployee, 4);
            daySummary.BusinessTrip = GetTimeSpendOnDailyResults(date, idEmployee, 5);
            daySummary.Doctor = GetTimeSpendOnDailyResults(date, idEmployee, 6);
            daySummary.Private = GetTimeSpendOnDailyResults(date, idEmployee, 7);
            daySummary.Other = GetTimeSpendOnDailyResults(date, idEmployee, 8);

            daySummary.TotalTimeWorked = daySummary.WorkLeavingTime - daySummary.WorkArrivalTime - daySummary.HolidayTime
                 - daySummary.Doctor - daySummary.Private - daySummary.Other;

            if (daySummary.TotalTimeWorked > TimeSpan.FromHours(4))
            {
                daySummary.TotalTimeWorked -= daySummary.LunchBreak > TimeSpan.FromMinutes(30) ? daySummary.LunchBreak : TimeSpan.FromMinutes(30);
            }
            else
            {
                daySummary.TotalTimeWorked -= daySummary.LunchBreak;
            }
            return daySummary;

        }

        private TimeSpan GetTimeSpendOnDailyResults(DateTime date, int IdEmployee, int idWorkType)
        {
            TimeSpan ret = TimeSpan.Zero;
            Execute((command) => 
            {
            command.CommandText = @"select dr.Start,dr.Finish from DailyResult as dr
                                                where dr.IdEmployee=@IdEmployee  and dr.IdWorktype=@idWorkType 
                                                            and convert(date,dr.start)=convert(date,@date)";

            command.Parameters.Add("@idEmployee", SqlDbType.Int).Value = IdEmployee;
            command.Parameters.Add("@idWorkType", SqlDbType.Int).Value = idWorkType;
            command.Parameters.Add("@date", SqlDbType.DateTime2).Value = date;
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    if (!reader.IsDBNull(0) && !reader.IsDBNull(1))
                    {
                        ret += (reader.GetDateTime(1) - reader.GetDateTime(0));
                    }
                }
            }
            });
            return ret;
        }

        //TODO prec
        public List<DaySummary> GetSummariesByMonth(string month, int idEmployee)
        {
            List<DaySummary> myListOfDays = new List<DaySummary>();
            int numberOfMonth = DateTime.ParseExact(month, "MMMM", CultureInfo.CurrentCulture).Month;

            DateTime dt = new DateTime(2019, numberOfMonth, 1);
            while (dt.Month == numberOfMonth)
            {
                myListOfDays.Add(CreateDaySummary(dt, idEmployee));
                dt = dt.AddDays(1);
            }

            return myListOfDays;
        }
    }
}
