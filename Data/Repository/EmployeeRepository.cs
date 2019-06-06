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
                        int employeeId = reader.GetInt32(reader.GetOrdinal("Id"));
                        string password = reader.GetString(reader.GetOrdinal("Password"));
                        int idPerson = reader.GetInt32(reader.GetOrdinal("IdPerson"));
                        int idSupervisor = reader.IsDBNull(reader.GetOrdinal("IdSupervisor")) ? 
                            0 : reader.GetInt32(reader.GetOrdinal("IdSupervisor"));
                        int permision = reader.GetInt32(reader.GetOrdinal("IdPermission"));
                        decimal salary = reader.GetDecimal(reader.GetOrdinal("Salary"));
                        DateTime hiredDate = reader.GetDateTime(reader.GetOrdinal("HiredDate"));

                        ret.Add(new Employee() { Id = employeeId, Password = password, IdPerson = idPerson,
                            IdSupervisor = idSupervisor, IdPermission = permision, Salary = salary, HiredDate = hiredDate });
                    }
                }
            });
            return ret;
        }

        public List<Employee> GetEmployeesByIdGreaterThan(int lowestId)
        {
            List<Employee> ret = new List<Employee>();
            Execute((command) =>
            {
                command.CommandText = @"SELECT TOP (1000) [Id]
                                      ,[Password]
                                      ,[IdPerson]
                                      ,[IdSupervisor]
                                      ,[IdPermission]
                                      ,[Salary]
                                      ,[HiredDate]
                                  FROM [Employee]
                                  where id >= @lowestId";
                command.Parameters.Add("@lowestId", SqlDbType.Int).Value = lowestId;
                using(SqlDataReader reader = command.ExecuteReader())
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

        public bool UpdateEmployee(Employee employee, Person person)
        {
            bool success = false;

            Execute((command) => 
            {
                command.CommandText = @" 
begin transaction
UPDATE Person 
SET	FirstName = @firstname,
	Lastname = @lastName,
	PhoneNumber = @phoneNumber,
	Adress = @address
	WHERE ID = (SELECT e.IdPerson FROM Employee AS e
JOIN Person AS p ON e.IdPerson = p.ID
WHERE e.Id = @employeeId)

Update Employee
SET	IdPerson = @IdPerson,
	IdSuperVisor = @IdSupervisor,
	IdPermission = @IdPermission,
	Salary = @Salary
 WHERE Id = @employeeId
 commit";
                command.Parameters.Add("@firstname", SqlDbType.VarChar).Value = person.FirstName;
                command.Parameters.Add("@lastName", SqlDbType.VarChar).Value = person.LastName;
                command.Parameters.Add("@phoneNumber", SqlDbType.VarChar).Value = person.PhoneNumber;
                command.Parameters.Add("@address", SqlDbType.VarChar).Value = person.Adress;
                command.Parameters.Add("@employeeId", SqlDbType.Int).Value = employee.Id;
                command.Parameters.Add("@IdPerson", SqlDbType.VarChar).Value = employee.IdPerson;
                command.Parameters.Add("@IdSupervisor", SqlDbType.VarChar).Value = employee.IdSupervisor;
                command.Parameters.Add("@IdPermission", SqlDbType.VarChar).Value = employee.IdPermission;
                command.Parameters.Add("@Salary", SqlDbType.Int).Value = employee.Salary;
                if (command.ExecuteNonQuery() > 0)
                {
                    success = true;
                }
            });
            return success;
        }
      
        public bool DeleteEmployee(Employee employee,int supervisorId)
        {
            bool success = false;
            Execute((command) => 
            {
                command.CommandText = @"begin transaction
if ((select IdPermission
	from Employee
	where Id=@id)>=2)
		update Employee
		set IdSupervisor=
		@supervisorID
		where IdSupervisor=@id;
	

delete from DailyRecord
where IdEmployee=@id

delete  from Employee
where Id=@id
commit";
                command.Parameters.Add("@Id", SqlDbType.Decimal).Value = employee.Id;
                command.Parameters.Add("@supervisorID", SqlDbType.Int).Value = supervisorId;
                if (command.ExecuteNonQuery() > 0)
                {
                    success = true;
                }
            });
            return success;
        }

        public int InsertFullEmployee(Employee employee)
        {
            int ret = -1;
            Execute((command) => 
            {
                command.CommandText = @"INSERT INTO Employee (Salary, IdPermission, IdSupervisor, Password, IdPerson, HiredDate)
                                                OUTPUT INSERTED.Id
                                                VALUES (@Salary, @IdPermission, @IdSupervisor, @Password, @IdPerson, @HiredDate)";
                command.Parameters.Add("@Salary", SqlDbType.Decimal).Value = employee.Salary;
                command.Parameters.Add("@IdPermission", SqlDbType.Int).Value = employee.IdPermission;
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
                        int employeeId = reader.GetInt32(reader.GetOrdinal("Id"));
                        string password = reader.GetString(reader.GetOrdinal("Password"));
                        int idPerson = reader.GetInt32(reader.GetOrdinal("IdPerson"));
                        int idSupervisor = reader.IsDBNull(reader.GetOrdinal("IdSupervisor")) ?
                            0 : reader.GetInt32(reader.GetOrdinal("IdSupervisor"));
                        int permision = reader.GetInt32(reader.GetOrdinal("IdPermission"));
                        decimal salary = reader.GetDecimal(reader.GetOrdinal("Salary"));
                        DateTime hiredDate = reader.GetDateTime(reader.GetOrdinal("HiredDate"));

                        ret = new Employee() { Id = employeeId, Password = password, IdPerson = idPerson,
                            IdSupervisor = idSupervisor, IdPermission = permision, Salary = salary, HiredDate = hiredDate };
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
                        int employeeId = reader.GetInt32(reader.GetOrdinal("Id"));
                        string password = reader.GetString(reader.GetOrdinal("Password"));
                        int idPerson = reader.GetInt32(reader.GetOrdinal("IdPerson"));
                        int idSupervisor = reader.IsDBNull(reader.GetOrdinal("IdSupervisor")) ?
                            0 : reader.GetInt32(reader.GetOrdinal("IdSupervisor"));
                        int permision = reader.GetInt32(reader.GetOrdinal("IdPermission"));
                        decimal salary = reader.GetDecimal(reader.GetOrdinal("Salary"));
                        DateTime hiredDate = reader.GetDateTime(reader.GetOrdinal("HiredDate"));

                        ret = new Employee() { Id = employeeId, Password = password, IdPerson = idPerson,
                            IdSupervisor = idSupervisor, IdPermission = permision, Salary = salary, HiredDate = hiredDate };
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

       

    }
}
