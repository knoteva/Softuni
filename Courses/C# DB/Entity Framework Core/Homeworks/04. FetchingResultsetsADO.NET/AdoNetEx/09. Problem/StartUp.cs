using AdoNetEx;
using System;
using System.Data;
using System.Data.SqlClient;

namespace _09._Problem
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int id = int.Parse(Console.ReadLine());
            var connection = new SqlConnection(Configuration.ConnectionString);
            using (connection)
            {
                connection.Open();
               
                var command = new SqlCommand(Procedure.CreateProcedure, connection);
                using (command)
                {
                    command.ExecuteNonQuery();
                }
                command = new SqlCommand("usp_GetOlder", connection);
                using (command)
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                }

                command = new SqlCommand(Procedure.SelectMinionQuery, connection);
                using (command)
                {
                    command.Parameters.AddWithValue("@Id", id);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        string name = (string)reader[0];
                        int age = (int)reader[1];
                        Console.WriteLine($"{name} - {age} years old");
                    }
                }
            }
        }
    }
}
