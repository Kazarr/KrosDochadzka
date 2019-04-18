using Data.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class EmployeeRepository
    {
        public IEnumerable<Empolyee> GetEmpolyees()
        {
            List<Empolyee> ret = new List<Empolyee>();
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ConnectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = @"SELECT * FROM Empolyee";
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int employeeId = reader.GetInt32(0);
                                string password = reader.GetString(1);
                                int idPerson = reader.GetInt32(2);
                                int idSupervisor = reader.GetInt32(3);
                                int permision = reader.GetInt32(4);
                                decimal salary = reader.GetDecimal(5);
                                DateTime hiredDate = reader.GetDateTime(6);

                                ret.Add(new Empolyee(employeeId, password, idPerson, idSupervisor, permision, salary, hiredDate));
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
    }
}
