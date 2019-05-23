using Data.Model;
using System;
using System.Collections.Generic;
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

        public  List<DailyRecord> GetTimeSpendOnDailyResults(DateTime date, int IdEmployee)
        {
            List<DailyRecord> listDailyRecords = new List<DailyRecord>();
            Execute((command) => 
            {
            command.CommandText = @"select dr.Id, dr.Start,dr.Finish, dr.IdWorkType from DailyRecord as dr
where dr.IdEmployee=@idEmployee and year(dr.Start) = YEAR(@date) and MONTH(dr.Start)=MONTH(@date)";
            command.Parameters.Add("@idEmployee", SqlDbType.Int).Value = IdEmployee;
            command.Parameters.Add("@date", SqlDbType.DateTime2).Value = date;
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {                      
                    if (!reader.IsDBNull(reader.GetOrdinal("Start")) && !reader.IsDBNull(reader.GetOrdinal("Finish")))
                    {
                            DailyRecord dailyRecord = new DailyRecord
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Start = reader.GetDateTime(reader.GetOrdinal("Start")),
                                Finish = reader.GetDateTime(reader.GetOrdinal("Finish")),
                                IdWorktype = reader.GetInt32(reader.GetOrdinal("IdWorkType")),
                                IdEmployee = IdEmployee
                            };
                            listDailyRecords.Add(dailyRecord);
                        }
                }
            }
            });
            return listDailyRecords;
        }
    }
}
