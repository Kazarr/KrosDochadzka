using Data.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class WorkTypeRepository
    {
        public IEnumerable<WorkType> GetWork_Type()
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

                                ret.Add(new WorkType(workTypeId, name));
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

        public bool InsertWork_Type(WorkType work_Type)
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
                        command.Parameters.Add("@Name", SqlDbType.VarChar).Value = work_Type.Name;
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
