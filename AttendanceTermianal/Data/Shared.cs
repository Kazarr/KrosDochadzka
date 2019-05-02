using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public static class Shared
    {
        public const string CONNECTION_STRING = @"Server = kardos\sqlexpresskardy; Database=KROSDOCHADZKA;Trusted_Connection=True";


        public static bool CheckConnection()
        {

            SqlConnection connection = new SqlConnection(Properties.Settings.Default.ConnectionString);
            connection.OpenAsync();
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Close();
                return false;
            }
            else
            {
                connection.Close();
                return true;
            }
            

        }
    }
}
