using Data.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;

namespace Data.Repository
{
    public class DaySummaryRepository
    {
        private DateTime GetArrivalTime(DateTime date, int idEmployee)
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
                                                where dr.IdEmployee=@idEmployee  and dr.IdWorktype=1 and (convert(date,dr.start)=(convert(date,@date))";

                        command.Parameters.Add("@idEmployee", SqlDbType.Int).Value = idEmployee;
                        command.Parameters.Add("@date", SqlDbType.NVarChar).Value = date;

                        return Convert.ToDateTime(command.ExecuteScalar())
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

        private DateTime GetLeavingTime(DateTime date, int idEmployee)
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
                                                where dr.IdEmployee=@idEmployee  and dr.IdWorktype=1 and (convert(date,dr.start)=(convert(date,@date))";

                        command.Parameters.Add("@idEmployee", SqlDbType.Int).Value = idEmployee;
                        command.Parameters.Add("@date", SqlDbType.NVarChar).Value = date;

                        return Convert.ToDateTime(command.ExecuteScalar())
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





    }
}
