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
    public class DaySummaryRepository
    {
        private DateTime? GetArrivalTime(DateTime date, int idEmployee)
        {

            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ConnectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = @"select min(dr.[Start]) from DailyResult as dr
                                                where dr.IdEmployee=@idEmployee  and dr.IdWorktype=1 and convert(date,dr.start)=convert(date,@date)";

                        command.Parameters.Add("@idEmployee", SqlDbType.Int).Value = idEmployee;
                        command.Parameters.Add("@date", SqlDbType.NVarChar).Value = date;

                        DateTime? resultDate = command.ExecuteScalar() as DateTime?;
                        
                        if (!resultDate.HasValue)
                        {
                            return null;
                        }
                        else
                        {
                            return resultDate.Value;
                        }


                    }
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                    throw e;
                }
            }
        }

        private DateTime? GetLeavingTime(DateTime date, int idEmployee)
        {

            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ConnectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = @"select max(dr.[Finish]) from DailyResult as dr
                                                where dr.IdEmployee=@idEmployee  and dr.IdWorktype=1 and convert(date,dr.start)=convert(date,@date)";

                        command.Parameters.Add("@idEmployee", SqlDbType.Int).Value = idEmployee;
                        command.Parameters.Add("@date", SqlDbType.NVarChar).Value = date;

                        DateTime? resultDate = command.ExecuteScalar() as DateTime?;

                        if (!resultDate.HasValue)
                        {
                            return null;
                        }
                        else
                        {
                            return resultDate.Value;
                        }
;


                    }
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                    throw e;
                }
            }
        }

        public DaySummary CreateDaySummary(DateTime date, int idEmployee)
        {
            DaySummary daySummary = new DaySummary();

            daySummary.WorkArrivalTime = GetArrivalTime(date, idEmployee);
            daySummary.WorkLeavingTime = GetLeavingTime(date, idEmployee);

            return daySummary;

        }

        public List<DaySummary> GetSummariesByMonth (string month, int idEmployee)
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
