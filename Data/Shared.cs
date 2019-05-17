using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
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
            try
            {
                connection.Open();
            }
            catch (SqlException )
            {
                connection.Close();
                return false;
            }
            connection.Close();
            return true;       
            

        }
    }
}
