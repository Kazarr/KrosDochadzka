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
    public class PermissionRepository:ConnectionManager
    {
        public List<string> SelectPermissionName()
        {
            List<string> ret = new List<string>();
            Execute((command) => 
            {
                command.CommandText = @"Select Name from Permission";
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string name = reader.GetString(0);

                        ret.Add(name);
                    }
                }
            });
            return ret;
        }


        public string SelectPermissionNameById(int id)
        {
            string ret = null;
            Execute((command) => 
            {
                command.CommandText = @"Select Name from Permission WHERE Id = @id";
                command.Parameters.Add("id", SqlDbType.Int).Value = id;
                ret = (string)command.ExecuteScalar();
            });
            return ret;
        }
        public int SelectPermissionIdByName(string name)
        {
            int ret = -1;
            Execute((command) => 
            {
                command.CommandText = @"Select id from Permission WHERE Name = @name";
                command.Parameters.Add("@name", SqlDbType.NVarChar).Value = name;
                ret = (int)command.ExecuteScalar();
            });
            return ret;
        }
    }
}
