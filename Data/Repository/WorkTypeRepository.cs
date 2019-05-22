using Data.Model;
using System;
using System.Collections.Generic;
using System.Data;
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
                                int workTypeId = reader.GetInt32(0);
                                string name = reader.GetString(1);                               

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

        public bool InsertWorkType(WorkType workType)
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ConnectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = @"INSERT INTO WorkType (Name)
                                                VALUES (@Name)";
                        command.Parameters.Add("@Name", SqlDbType.VarChar).Value = workType.Name;
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
                    Debug.WriteLine($"Error happend during  InsertWorkType \n Error info:{e.Message}");
                    return false;

                }
            }
        }


    }
}
