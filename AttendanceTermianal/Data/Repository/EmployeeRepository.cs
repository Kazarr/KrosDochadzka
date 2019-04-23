using Data.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
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
                        command.CommandText = @"SELECT * FROM Employee";
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int employeeId = reader.GetInt32(0);
                                string password = reader.GetString(1);
                                int idPerson = reader.GetInt32(2);
                                int idSupervisor = reader.IsDBNull(3) ? 0 : reader.GetInt32(3);
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

        public bool InsertFullEmployee(Empolyee employee)
        {
            employee.Password = CalculateMD5Hash(employee.Password);
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ConnectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = @"INSERT INTO Employee (Salary, IdPermission, IdSupervisor, Password, IdPerson)
                                                VALUES (@Salary, @IdPermission, @IdSupervisor, @Password, @IdPerson)";
                        command.Parameters.Add("@Salary", SqlDbType.Decimal).Value = employee.Salary;
                        command.Parameters.Add("@IdPermission", SqlDbType.Int).Value = employee.Permision;
                        command.Parameters.Add("@IdSupervisor", SqlDbType.Int).Value = employee.IdSupervisor;
                        command.Parameters.Add("@Password", SqlDbType.VarChar).Value = employee.Password;
                        command.Parameters.Add("@IdPerson", SqlDbType.VarChar).Value = employee.IdPerson;
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

        public Empolyee GetEmpolyeeByID(int id)
        {
            
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ConnectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = @"select * from Employee where id = @id";
                        command.Parameters.Add("@id", SqlDbType.Int).Value = id;
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if  (reader.Read())
                            {
                                int employeeId = reader.GetInt32(0);
                                string password = reader.GetString(1);
                                int idPerson = reader.GetInt32(2);
                                int idSupervisor = reader.IsDBNull(3) ? 0 : reader.GetInt32(3);
                                int permision = reader.GetInt32(4);
                                decimal salary = reader.GetDecimal(5);
                                DateTime hiredDate = reader.GetDateTime(6);

                                return new Empolyee(employeeId, password, idPerson, idSupervisor, permision, salary, hiredDate);
                            }
                            return null;
                        }
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }


        // this needs to be gone
        private string CalculateMD5Hash(string input)

        {
            // step 1, calculate MD5 hash from input
            MD5 md5 = MD5.Create();
            byte[] inputBytes =Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString().ToLower();
        }


        // this need to be gone too
        /// <summary>
        /// checks if id and hashed password match and are in our database
        /// </summary>
        /// <param name="id"></param>
        /// <param name="password"></param>
        /// <returns>true if password and login match </returns>
        public bool CheckLogin(int id, string password)
        {
            List<Empolyee> employees = new List<Empolyee>(GetEmpolyees());
            Console.WriteLine(CalculateMD5Hash(password));
            Console.WriteLine(employees[0].Password);
            foreach (var employee in employees)
            {
                if ((employee.Id==id) && (employee.Password.Equals(CalculateMD5Hash(password))))
                {
                    return true;
                }
            }
            return false;
        }

        public bool InsertEmployee(Empolyee empolyee)
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ConnectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = @"INSERT INTO Employee (Password, IdPerson)
                                                VALUES (@Password, @IdPerson)";
                        command.Parameters.Add("@Password", SqlDbType.VarChar).Value = empolyee.Password;
                        command.Parameters.Add("@IdPerson", SqlDbType.VarChar).Value = empolyee.IdPerson;
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
