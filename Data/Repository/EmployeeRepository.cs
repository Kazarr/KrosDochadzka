using Data.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Data.Repository
{
    public class EmployeeRepository:ConnectionManager
    {
        public IEnumerable<Employee> GetEmpolyees()
        {
            List<Employee> ret = new List<Employee>();
            Execute((command) => 
            {
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

                        ret.Add(new Employee() { Id = employeeId, Password = password, IdPerson = idPerson, IdSupervisor = idSupervisor, Permision = permision, Salary = salary, HiredDate = hiredDate });
                    }
                }
            });
            return ret;
        }

        public bool ChangePassword(int employeeId, string password)
        {           
            bool success = false;
            Execute((command) => 
            {
                command.CommandText = @"UPDATE Employee SET Password = @password WHERE ID = @id";
                command.Parameters.Add("@password", SqlDbType.VarChar).Value = password;
                command.Parameters.Add("@id", SqlDbType.VarChar).Value = employeeId;
                if (command.ExecuteNonQuery() > 1)
                {
                    success = true;
                }
            });
            return success;
        }

        //todo move update person to person repository. 
        public bool UpdateEmployee(Employee empolyee, Person person)
        {
            bool success = false;
            bool updatePerson = false;

            Execute((command) => 
            {
                command.CommandText = @" UPDATE Person 
                                                  SET	FirstName = @firstname,
		                                                Lastname = @lastName,
		                                                PhoneNumber = @phoneNumber,
		                                                Adress = @address
                                                WHERE ID = (SELECT e.IdPerson FROM Employee AS e
			                                                JOIN Person AS p ON e.IdPerson = p.ID
			                                                WHERE e.Id = @employeeId)";
                command.Parameters.Add("@firstname", SqlDbType.VarChar).Value = person.FirstName;
                command.Parameters.Add("@lastName", SqlDbType.VarChar).Value = person.LastName;
                command.Parameters.Add("@phoneNumber", SqlDbType.VarChar).Value = person.PhoneNumber;
                command.Parameters.Add("@address", SqlDbType.VarChar).Value = person.Adress;
                command.Parameters.Add("@employeeId", SqlDbType.Int).Value = empolyee.Id;
                if (command.ExecuteNonQuery() > 1)
                {
                    updatePerson = true;
                }
            });
            Execute((command) => 
            {
                command.CommandText = @"   Update Employee
                                                    SET	IdPerson = @IdPerson,
		                                                IdSuperVisor = @IdSupervisor,
		                                                IdPermission = @IdPermission,
		                                                Salary = @Salary
                                                WHERE Id = @Id";
                command.Parameters.Add("@IdPerson", SqlDbType.VarChar).Value = empolyee.IdPerson;
                command.Parameters.Add("@IdSupervisor", SqlDbType.VarChar).Value = empolyee.IdSupervisor;
                command.Parameters.Add("@IdPermission", SqlDbType.VarChar).Value = empolyee.Permision;
                command.Parameters.Add("@Salary", SqlDbType.Int).Value = empolyee.Salary;
                command.Parameters.Add("@Id", SqlDbType.Int).Value = empolyee.Id;
                if (command.ExecuteNonQuery() > 0 && updatePerson)
                {
                    success = true;
                }
            });
            return success;
        }

        public bool UpdateEmployeePleb(Employee empolyee)
        {
            bool success = false;
            Execute((command) => 
            {
                command.CommandText = @"UPDATE Employee
                                                  SET IdSupervisor = (SELECT id FROM Employee
                                                  WHERE IdPermission = 3)
                                                  WHERE id IN (SELECT id FROM Employee WHERE IdSupervisor = @idSupervisor)";
                command.Parameters.Add("@idSupervisor", SqlDbType.Decimal).Value = empolyee.IdSupervisor;
                if (command.ExecuteNonQuery() > 0)
                {
                    success = true;
                }
            });
            return success;
        }
      
        /// <summary>
        /// Recursively delete supervisor. Normal delete pleb.
        /// </summary>
        /// <param name="empolyee"></param>
        /// <returns></returns>
        public bool DeleteEmployee(Employee empolyee)
        {
            bool success = false;
            Execute((command) => 
            {
                command.CommandText = @"DELETE FROM Employee WHERE Id = @Id";
                command.Parameters.Add("@Id", SqlDbType.Decimal).Value = empolyee.Id;
                if (command.ExecuteNonQuery() > 0)
                {
                    success = true;
                }
            });
            return success;
        }

        public int InsertFullEmployee(Employee employee)
        {
            //employee.Password = CalculateMD5Hash(employee.Password);
            int ret = -1;
            Execute((command) => 
            {
                command.CommandText = @"INSERT INTO Employee (Salary, IdPermission, IdSupervisor, Password, IdPerson, HiredDate)
                                                OUTPUT INSERTED.Id
                                                VALUES (@Salary, @IdPermission, @IdSupervisor, @Password, @IdPerson, @HiredDate)";
                command.Parameters.Add("@Salary", SqlDbType.Decimal).Value = employee.Salary;
                command.Parameters.Add("@IdPermission", SqlDbType.Int).Value = employee.Permision;
                command.Parameters.Add("@IdSupervisor", SqlDbType.Int).Value = (object)employee.IdSupervisor ?? DBNull.Value;
                command.Parameters.Add("@Password", SqlDbType.VarChar).Value = employee.Password;
                command.Parameters.Add("@IdPerson", SqlDbType.VarChar).Value = employee.IdPerson;
                command.Parameters.Add("@HiredDate", SqlDbType.Date).Value = (object)employee.HiredDate ?? DateTime.Now;
                ret = (int)command.ExecuteScalar();
            });
            return ret;
        }

        public void UpdateSupervisor(Employee empolyee)
        {
            Execute((command) => 
            {
                command.CommandText = @"UPDATE Employee
	                                            SET IdSupervisor = @idSupervisor
	                                            WHERE id = @idEmployee ";
                command.Parameters.Add("@idSupervisor", SqlDbType.Decimal).Value = empolyee.IdSupervisor;
                command.Parameters.Add("@idEmployee", SqlDbType.Int).Value = empolyee.Id;

                command.ExecuteNonQuery();
            });
        }
        
        public Employee GetEmpolyeeByID(int id)
        {
            Employee ret = null;
            Execute((command) => 
            {
                command.CommandText = @"select * from Employee where id = @id";
                command.Parameters.Add("@id", SqlDbType.Int).Value = id;
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int employeeId = reader.GetInt32(0);
                        string password = reader.GetString(1);
                        int idPerson = reader.GetInt32(2);
                        int idSupervisor = reader.IsDBNull(3) ? 0 : reader.GetInt32(3);
                        int permision = reader.GetInt32(4);
                        decimal salary = reader.GetDecimal(5);
                        DateTime hiredDate = reader.GetDateTime(6);

                        ret = new Employee() { Id = employeeId, Password = password, IdPerson = idPerson, IdSupervisor = idSupervisor, Permision = permision, Salary = salary, HiredDate = hiredDate };
                    }
                }
            });
            return ret;
        }
        
        public Employee GetEmpolyeeByIdPerson(int id)
        {
            Employee ret = null;
            Execute((command) => 
            {
                command.CommandText = @"select * from Employee where idPerson = @id";
                command.Parameters.Add("@id", SqlDbType.Int).Value = id;
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int employeeId = reader.GetInt32(0);
                        string password = reader.GetString(1);
                        int idPerson = reader.GetInt32(2);
                        int idSupervisor = reader.IsDBNull(3) ? 0 : reader.GetInt32(3);
                        int permision = reader.GetInt32(4);
                        decimal salary = reader.GetDecimal(5);
                        DateTime hiredDate = reader.GetDateTime(6);

                        ret = new Employee() { Id = employeeId, Password = password, IdPerson = idPerson, IdSupervisor = idSupervisor, Permision = permision, Salary = salary, HiredDate = hiredDate };
                    }
                }
            });
            return ret;
        }

        public Employee GetEmpolyeeByIdPerson(Person person)
        {
            Employee ret = null;
            Execute((command) => 
            {
                command.CommandText = @"select * from Employee where idPerson = @id";
                command.Parameters.Add("@id", SqlDbType.Int).Value = person.Id;
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int employeeId = reader.GetInt32(0);
                        string password = reader.GetString(1);
                        int idPerson = reader.GetInt32(2);
                        int idSupervisor = reader.IsDBNull(3) ? 0 : reader.GetInt32(3);
                        int permision = reader.GetInt32(4);
                        decimal salary = reader.GetDecimal(5);
                        DateTime hiredDate = reader.GetDateTime(6);

                        ret = new Employee() { Id = employeeId, Password = password, IdPerson = idPerson, IdSupervisor = idSupervisor, Permision = permision, Salary = salary, HiredDate = hiredDate };
                    }
                }
            });
            return ret;
        }


        public bool CheckLogin(int id, string password)
        {
            List<Employee> employees;
            if (GetEmpolyees() != null)
            {
                 employees= new List<Employee>(GetEmpolyees());
            }
            else
            {
                return false;
            }

            foreach (var employee in employees)
            {
                if ((employee.Id==id) && (employee.Password.Equals(password)))
                {
                    return true;
                }
            }
            return false;
        }

        public bool InsertEmployee(Employee empolyee)
        {
            bool success = false;
            Execute((command) => 
            {
                command.CommandText = @"INSERT INTO Employee (Password, IdPerson)
                                                VALUES (@Password, @IdPerson)";
                command.Parameters.Add("@Password", SqlDbType.VarChar).Value = empolyee.Password;
                command.Parameters.Add("@IdPerson", SqlDbType.VarChar).Value = empolyee.IdPerson;
                if (command.ExecuteNonQuery() > 1)
                {
                    success = true;
                }
            });
            return success;
        }

    }
}
