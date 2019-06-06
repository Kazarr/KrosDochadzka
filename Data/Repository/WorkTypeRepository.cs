using Data.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;

namespace Data.Repository
{
    public class WorkTypeRepository
    {
        public IEnumerable<WorkType> GetWorkType()
        {
            List<WorkType> ret = new List<WorkType>();
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ConnectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = @"SELECT * FROM WorkType";
                        using(SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int workTypeId = reader.GetInt32(reader.GetOrdinal("Id"));
                                string name = reader.GetString(reader.GetOrdinal("Name"));                               

                                ret.Add(new WorkType() { Id = workTypeId, Name = name });
                            }
                            return ret;
                        }
                    }
                }
                catch (Exception e)
                {
                    Debug.WriteLine($"Error happend during  GetWorkType \n Error info:{e.Message}");
                    return null;
            
                }
            }
        }
    }
}
