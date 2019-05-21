using Data.Model;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Data.Repository
{
    public class PersonRepository:ConnectionManager
    {
        public IEnumerable<Person> GetPersons()
        {
            List<Person> ret = new List<Person>();
            Execute((command) => 
            {
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
                }
            });
            return ret;
        }

        public List<Person> GetPersonEmployeesSupervisors()
        {
            List<Person> ret = new List<Person>();
            Execute((command) => 
            {
                command.CommandText = @"SELECT DISTINCT p.Id, p.FirstName, p.LastName, p.PhoneNumber, p.Adress FROM Employee AS e
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
                }
            });
            return ret;
        }

        public bool DeletePerson(Person person)
        {
            bool success = false;
            Execute((command) => 
            {
                command.CommandText = @"DELETE FROM Person WHERE Id = @Id";
                command.Parameters.Add("@Id", SqlDbType.Int).Value = person.Id;
                if (command.ExecuteNonQuery() > 0)
                {
                    success = true;
                }
            });
            return success;
        }

        public Person GetPersonByIdEmployee(int employeeId)
        {
            Person ret = null;
            Execute((command) => 
            {
                command.CommandText = @"SELECT * FROM Person as p
                                                JOIN Employee as e ON p.Id = e.IdPerson
                                                WHERE e.Id = @employeeId";
                command.Parameters.Add("@employeeId", SqlDbType.Int).Value = employeeId;
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int personId = reader.GetInt32(0);
                        string firstName = reader.GetString(1);
                        string lastName = reader.GetString(2);
                        string phoneNumber = reader.GetString(3);
                        string adress = reader.IsDBNull(4) ? "" : reader.GetString(4);

                        ret = new Person(personId, firstName, lastName, phoneNumber, adress);
                    }
                }
            });
            return ret;
        }

        public Person GetPersonByEmployee(Employee empolyee)
        {
            Person ret = null;
            Execute((command) => 
            {
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

                        ret = new Person(personId, firstName, lastName, phoneNumber, adress);
                    }
                }
            });
            return ret;
        }

        public int InsertPerson(Person person)
        {
            int ret = -1;
            Execute((command) => 
            {
                command.CommandText = @"INSERT INTO Person (FirstName, LastName, PhoneNumber, Adress)
                                                OUTPUT INSERTED.Id
                                                VALUES (@FirstName, @Lastname, @PhoneNumber, @Adress)";
                command.Parameters.Add("@Firstname", SqlDbType.VarChar).Value = person.FirstName;
                command.Parameters.Add("@Lastname", SqlDbType.VarChar).Value = person.LastName;
                command.Parameters.Add("@PhoneNumber", SqlDbType.VarChar).Value = person.PhoneNumber;
                command.Parameters.Add("@Adress", SqlDbType.VarChar).Value = person.Adress;
                ret = (int)command.ExecuteScalar();
            });
            return ret;
        }

        public bool InsertOnlyPerson(Person person)
        {
            bool success = false;
            Execute((command) => 
            {
                command.CommandText = @"INSERT INTO Person (FirstName, LastName, PhoneNumber, Adress)
                                                VALUES (@FirstName, @Lastname, @PhoneNumber, @Adress)";
                command.Parameters.Add("@Firstname", SqlDbType.VarChar).Value = person.FirstName;
                command.Parameters.Add("@Lastname", SqlDbType.VarChar).Value = person.LastName;
                command.Parameters.Add("@PhoneNumber", SqlDbType.VarChar).Value = person.PhoneNumber;
                command.Parameters.Add("@Adress", SqlDbType.VarChar).Value = person.Adress;
                if (command.ExecuteNonQuery() > 1)
                {
                    success = true;
                }
            });
            return success;
        }

        public IEnumerable<Person> GetPersonsEmployees()
        {
            List<Person> ret = new List<Person>();
            Execute((command) => 
            {
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
                }
            });
            return ret;
        }

        public IEnumerable<Person> GetPersonEmployeesPlebs(int idBoss)
        {
            List<Person> ret = new List<Person>();
            Execute((command) => 
            {
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
                }
            });
            return ret;
        }

        public Person GetPersonById(int personId)
        {
            Person ret = null;
            Execute((command) => 
            {
                command.CommandText = @"SELECT * FROM Person WHERE Id = @id";
                command.Parameters.Add("@id", SqlDbType.Int).Value = personId;
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string firstName = reader.GetString(1);
                        string lastName = reader.GetString(2);
                        string phoneNumber = reader.GetString(3);
                        string adress = reader.IsDBNull(4) ? "" : reader.GetString(4);
                        ret =  new Person(id, firstName, lastName, phoneNumber, adress);
                    }
                }
            });
            return ret;
        }
    }
}
