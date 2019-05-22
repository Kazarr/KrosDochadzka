using System;
using System.Data.SqlClient;
using System.Diagnostics;

namespace Data.Repository
{
    public class ConnectionManager
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public void Execute(Action<SqlCommand> executeAction)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ConnectionString))
                {
                    connection.Open();
                    try
                    {
                        using (SqlCommand command = new SqlCommand())
                        {
                            command.Connection = connection;
                            executeAction.Invoke(command);
                            log.Info(command.CommandText);
                        }
                    }
                    catch (SqlException e)
                    {
                        Debug.WriteLine($"Error happend during  Execution \n Error info:{e.Message}\n{e.StackTrace}");
                        log.Error(e);
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error happend during  Connecting \n Error info:{e.Message}\n{e.StackTrace}");
                log.Error(e);
            }
        }
        
        //public void SaveConnectionString(string connectionString)
        //{
        //    Properties.Settings.Default.ConnectionString = connectionString;
        //    Properties.Settings.Default.Save();
        //}
        public SqlConnectionStringBuilder GetSqlConnectionStringBuilder(string initialCatalog)
        {
            SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder();
            scsb.IntegratedSecurity = true;
            scsb.InitialCatalog = initialCatalog;
            return scsb;
        }
    }
}
