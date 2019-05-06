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
    public class PermissionRepository
    {
        public List<string> SelectPermissionName()
        {
            List<string> ret = new List<string>();
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ConnectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = @"Select Name from Permission";
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string name = reader.GetString(0);

                                ret.Add(name);
                            }
                            return ret;
                        }
                    }
                }
                catch (Exception e)
                {
                    Debug.WriteLine($"Error happend during  SelectPermissionName \n Error info:{e.Message}");
                    return null;

                }
            }
        }


        public string SelectPermissionNameById(int id)
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ConnectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = @"Select Name from Permission WHERE Id = @id";
                        command.Parameters.Add("id", SqlDbType.Int).Value = id;
                        return (string)command.ExecuteScalar();
                    }
                }
                catch (Exception e)
                {
                    Debug.WriteLine($"Error happend during  SelectPermissionNameById \n Error info:{e.Message}");
                    return "";
                }
            }
        }
        public int SelectPermissionIdByName(string name)
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ConnectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = @"Select id from Permission WHERE Name = @name";
                        command.Parameters.Add("@name", SqlDbType.NVarChar).Value = name;
                        return (int)command.ExecuteScalar();
                    }
                }
                catch (Exception e)
                {
                    Debug.WriteLine($"Error happend during  SelectPermissionIdByName \n Error info:{e.Message}");
                    return 0;
                }
            }
        }
    }
}
