using System;
using System.Data;
using System.Data.SqlClient;

namespace Data.Repository
{
    public class DaySummaryRepository : ConnectionManager
    {
        
        public  DateTime? GetArrivalTime(DateTime date, int idEmployee)
        {

            DateTime? ret = null;
            Execute((command) => {
                command.CommandText = @"select min(dr.[Start]) from DailyRecord as dr
                                                where dr.IdEmployee=@idEmployee  and dr.IdWorktype=1 and convert(date,dr.start)=convert(date,@date)";

                command.Parameters.Add("@idEmployee", SqlDbType.Int).Value = idEmployee;
                command.Parameters.Add("@date", SqlDbType.NVarChar).Value = date;
                ret = command.ExecuteScalar() as DateTime?;

            });
            return ret;
        }


        public  DateTime? GetLeavingTime(DateTime date, int idEmployee)
        {
            DateTime? ret = null;
            Execute((command) =>
            {
                command.CommandText = @"select max(dr.[Finish]) from DailyRecord as dr
                                                where dr.IdEmployee=@idEmployee  and dr.IdWorktype=1 and convert(date,dr.start)=convert(date,@date)";

                command.Parameters.Add("@idEmployee", SqlDbType.Int).Value = idEmployee;
                command.Parameters.Add("@date", SqlDbType.NVarChar).Value = date;
                ret = command.ExecuteScalar() as DateTime?;
            });
            return ret;
        }
          

        public  TimeSpan GetTimeSpendOnDailyResults(DateTime date, int IdEmployee, int idWorkType)
        {
            TimeSpan ret = TimeSpan.Zero;
            Execute((command) => 
            {
            command.CommandText = @"select dr.Start,dr.Finish from DailyRecord as dr
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

               
    }
}
