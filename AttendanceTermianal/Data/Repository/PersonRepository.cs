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
    class PersonRepository
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
    }
}
