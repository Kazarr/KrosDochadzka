using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class ConnectionManager
    {
        public  SqlCommand Execute()
        {
            SqlConnection connection = new SqlConnection(Properties.Settings.Default.ConnectionString);
            try
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    return command;
                }
            }
            catch (SqlException e)
            {
                Debug.WriteLine($"Error happend during  Execution \n Error info:{e.Message}\n{e.StackTrace}");
                //logger 
                return null;
            }
         
        }

    }
}
