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
            using (SqlConnection connection = new SqlConnection(Shared.CONNECTION_STRING))
            {
                try
                {
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
            using (SqlConnection connection = new SqlConnection(Shared.CONNECTION_STRING))
            {
                try
                {
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
                                string adress = reader.GetString(4);

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
    }
}
