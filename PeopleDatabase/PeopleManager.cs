using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace PeopleDatabase
{
    public class PeopleManager
    {
        private string _connectionstring;

        public PeopleManager(string _Connectionstring)
        {
            _connectionstring = _Connectionstring;
        }
        public List<Person> GetPeople()
        {
            SqlConnection con = new SqlConnection(_connectionstring);
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "Select * From Person";
            List<Person> people = new List<Person>();
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                people.Add(new Person
                {
                    id = (int)reader["id"],
                    FirstName = (string)reader["FirstName"],
                    LastName = (string)reader["LastName"],
                    Age = (int)reader["Age"]
                });
            }
            con.Close();
            con.Dispose();
            return people;

        }
        public void AddPerson(Person p)
        {
            SqlConnection con = new SqlConnection(_connectionstring);
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = @"insert into Person
                                Values(@FirstName, @LastName,@Age)";      
            cmd.Parameters.AddWithValue("@FirstName", p.FirstName);
            cmd.Parameters.AddWithValue("@LastName", p.LastName);
            cmd.Parameters.AddWithValue("@Age", p.Age);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            con.Dispose();
        }
    }
}
