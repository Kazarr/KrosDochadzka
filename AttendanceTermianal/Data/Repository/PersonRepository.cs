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
                                                JOIN Employee as e ON p.Id = e.Id_person
                                                WHERE e.Id_person = @employeeId";
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
        public bool InsertPerson(Person person)
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ConnectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = @"INSERT INTO Person (First_name, Last_name, Phone_number, Adress)
                                                VALUES (@FirstName, @Lastname, @PhoneNumber, @Adress)";
                        command.Parameters.Add("@Firstname", SqlDbType.VarChar).Value = person.First_name;
                        command.Parameters.Add("@Lastname", SqlDbType.VarChar).Value = person.Last_name;
                        command.Parameters.Add("@PhoneNumber", SqlDbType.VarChar).Value = person.Phone_number;
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
                        command.CommandText = @"SELECT e.Id, p.First_name, p.Last_name, p.Phone_number, p.Adress FROM Person as p
                                                JOIN Employee as e ON p.ID = e.Id_person";
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
    }
}
