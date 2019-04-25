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
    public class PersonRepository
    {
        public IEnumerable<Person> GetPersons()
        {
            List<Person> ret = new List<Person>();
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ConnectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = @"SELECT * FROM Person";
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int personId = reader.GetInt32(0);
                                string firstName = reader.GetString(1);
                                string lastName = reader.GetString(2);
                                string phoneNumber = reader.GetString(3);
                                string adress = reader.GetString(4);

                                ret.Add(new Person(personId, firstName, lastName, phoneNumber, adress));
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

        public List<Person> GetPersonEmployeesSupervisors()
        {
            List<Person> ret = new List<Person>();
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ConnectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = @"SELECT DISTINCT e.Id, p.FirstName, p.LastName, p.PhoneNumber, p.Adress FROM Employee AS e
                                              LEFT JOIN Employee AS sup ON e.Id = sup.IdSupervisor
                                              JOIN Person AS p ON e.IdPerson = p.ID
                                              WHERE e.Id = e.IdSupervisor";
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int personId = reader.GetInt32(0);
                                string firstName = reader.GetString(1);
                                string lastName = reader.GetString(2);
                                string phoneNumber = reader.GetString(3);
                                string adress = reader.IsDBNull(4) ? "" : reader.GetString(4);

                                ret.Add(new Person(personId, firstName, lastName, phoneNumber, adress));
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

        public bool DeletePerson(Person person)
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ConnectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = @"DELETE FROM Person WHERE Id = @Id";
                        command.Parameters.Add("@Id", SqlDbType.Int).Value = person.Id;
                        if (command.ExecuteNonQuery() > 0)
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

        public Person GetPersonByIdEmployee(int employeeId)
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ConnectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = @"SELECT * FROM Person as p
                                                JOIN Employee as e ON p.Id = e.IdPerson
                                                WHERE e.Id = @employeeId";
                        command.Parameters.Add("@employeeId", SqlDbType.Int).Value = employeeId;
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if(reader.Read())
                            {
                                int personId = reader.GetInt32(0);
                                string firstName = reader.GetString(1);
                                string lastName = reader.GetString(2);
                                string phoneNumber = reader.GetString(3);
                                string adress = reader.IsDBNull(4) ? "" : reader.GetString(4);

                                return new Person(personId, firstName, lastName, phoneNumber, adress);
                            }
                            throw new Exception("There was nothing to read");
                        }
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        public Person GetPersonByEmployee(Empolyee empolyee)
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ConnectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = @"SELECT * FROM Person as p
                                                JOIN Employee as e ON p.Id = e.IdPerson
                                                WHERE e.IdPerson = @employeeId";
                        command.Parameters.Add("@employeeId", SqlDbType.Int).Value = empolyee.Id;
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int personId = reader.GetInt32(0);
                                string firstName = reader.GetString(1);
                                string lastName = reader.GetString(2);
                                string phoneNumber = reader.GetString(3);
                                string adress = reader.IsDBNull(4) ? "" : reader.GetString(4);

                                return new Person(personId, firstName, lastName, phoneNumber, adress);
                            }
                            throw new Exception("There was nothing to read");
                        }
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        public int InsertPerson(Person person)
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ConnectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = @"INSERT INTO Person (FirstName, LastName, PhoneNumber, Adress)
                                                OUTPUT INSERTED.Id
                                                VALUES (@FirstName, @Lastname, @PhoneNumber, @Adress)";
                        command.Parameters.Add("@Firstname", SqlDbType.VarChar).Value = person.FirstName;
                        command.Parameters.Add("@Lastname", SqlDbType.VarChar).Value = person.LastName;
                        command.Parameters.Add("@PhoneNumber", SqlDbType.VarChar).Value = person.PhoneNumber;
                        command.Parameters.Add("@Adress", SqlDbType.VarChar).Value = person.Adress;
                        return (int)command.ExecuteScalar();
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }
        public bool InsertOnlyPerson(Person person)
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ConnectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = @"INSERT INTO Person (FirstName, LastName, PhoneNumber, Adress)
                                                VALUES (@FirstName, @Lastname, @PhoneNumber, @Adress)";
                        command.Parameters.Add("@Firstname", SqlDbType.VarChar).Value = person.FirstName;
                        command.Parameters.Add("@Lastname", SqlDbType.VarChar).Value = person.LastName;
                        command.Parameters.Add("@PhoneNumber", SqlDbType.VarChar).Value = person.PhoneNumber;
                        command.Parameters.Add("@Adress", SqlDbType.VarChar).Value = person.Adress;
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
        
        public IEnumerable<Person> GetPersonsEmployees()
        {
            List<Person> ret = new List<Person>();
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ConnectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = @"SELECT p.Id, p.FirstName, p.LastName, p.PhoneNumber, p.Adress FROM Person as p
                                                JOIN Employee as e ON p.ID = e.IdPerson";
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int personId = reader.GetInt32(0);
                                string firstName = reader.GetString(1);
                                string lastName = reader.GetString(2);
                                string phoneNumber = reader.GetString(3);
                                string adress = reader.IsDBNull(4) ? "" : reader.GetString(4);

                                ret.Add(new Person(personId, firstName, lastName, phoneNumber, adress));
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
        public IEnumerable<Person> GetPersonEmployeesPlebs(int idBoss)
        {
            List<Person> ret = new List<Person>();
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ConnectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = @"SELECT DISTINCT p.Id, p.FirstName, p.LastName, p.PhoneNumber, p.Adress FROM Employee AS e
                                              LEFT JOIN Employee AS sup ON e.Id = sup.IdSupervisor
                                              JOIN Person AS p ON e.IdPerson = p.ID
                                              WHERE e.IdSupervisor = @idBoss";
                        command.Parameters.Add("@idBoss", SqlDbType.Int).Value = idBoss;
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int personId = reader.GetInt32(0);
                                string firstName = reader.GetString(1);
                                string lastName = reader.GetString(2);
                                string phoneNumber = reader.GetString(3);
                                string adress = reader.IsDBNull(4) ? "" : reader.GetString(4);

                                ret.Add(new Person(personId, firstName, lastName, phoneNumber, adress));
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
        public Person GetPersonById(int personId)
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ConnectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = @"SELECT * FROM Person WHERE Id = @id";
                        command.Parameters.Add("@id", SqlDbType.Int).Value = personId;
                        using(SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int id = reader.GetInt32(0);
                                string firstName = reader.GetString(1);
                                string lastName = reader.GetString(2);
                                string phoneNumber = reader.GetString(3);
                                string adress = reader.IsDBNull(4) ? "" : reader.GetString(4);
                                return new Person(id, firstName, lastName, phoneNumber, adress);
                            }
                            throw new Exception("There was nothing to read");
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
