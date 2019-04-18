using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class DialyResultRepository
    {
        public DataSet GetEmployees()
        {
            using (SqlConnection connection = new SqlConnection(Shared.CONNECTION_STRING))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = @"SELECT * FROM Daily_Result";
                        using (SqlDataAdapter adapter = new SqlDataAdapter())
                        {
                            DataSet ds = new DataSet();
                            adapter.Fill(ds, "Daily_Result");
                            return ds;
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
