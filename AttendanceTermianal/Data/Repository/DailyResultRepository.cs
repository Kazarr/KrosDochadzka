using Data.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class DailyResultRepository
    {
        public IEnumerable<DailyResult> GetDailyResult()
        {
            List<DailyResult> ret = new List<DailyResult>();
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ConnectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = @"SELECT * FROM Daily_Result";
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int dailyResultId = reader.GetInt32(0);
                                int employeeId = reader.GetInt32(1);
                                DateTime start = reader.GetDateTime(2);
                                DateTime finish = reader.GetDateTime(3);
                                int workTypeId = reader.GetInt32(4);

                                ret.Add(new DailyResult(dailyResultId, employeeId, start, finish, workTypeId));
                            }
                            return ret;
                        }
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }
        public int InsertDialyResult(DailyResult dailyResult)
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ConnectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = @"INSERT INTO DailyResult (IdEmployee, IdWorktype)
                                                OUTPUT INSERTED.Id
                                                VALUES (@Id_Employee, @Id_Worktype)";
                        command.Parameters.Add("@Id_Employee", SqlDbType.VarChar).Value = dailyResult.IdEmployee;
                        command.Parameters.Add("@Id_Worktype", SqlDbType.VarChar).Value = dailyResult.IdWorktype;
                        return (int)command.ExecuteScalar();
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }
        public bool UpdateFinishDailyResult(DailyResult daily_Result)
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ConnectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = @"UPDATE DailyResult
                                               SET Finish = GETDATE()
                                                WHERE ID = @ID";
                        command.Parameters.Add("@ID", SqlDbType.VarChar).Value = daily_Result.Id;
                        if (command.ExecuteNonQuery() > 1)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }
    }
}
