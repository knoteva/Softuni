using AdoNetEx;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace _07._Problem
{
    public class StratUp
    {
        public static void Main(string[] args)
        {
            //var name = Console.ReadLine();
            var connection = new SqlConnection(Configuration.ConnectionString);

            using (connection)
            {
                connection.Open();
                var minionsNameQuerey = @"SELECT Name FROM Minions";
                var command = new SqlCommand(minionsNameQuerey, connection);
                //command.Parameters.AddWithValue("@Id", id);
                using (command)
                {
                    var reader = command.ExecuteReader();
                    var minions = new List<string>();
                    while (reader.Read())
                    {
                        minions.Add((string)reader[0]);
                    }

                    for (int i = 0; i < minions.Count / 2; i++)
                    {
                        Console.WriteLine(minions[i]);
                        Console.WriteLine(minions[minions.Count - 1 - i]);
                    }
                    if (minions.Count % 2 != 0)
                    {
                        Console.WriteLine(minions[minions.Count / 2]);
                    }
                }
            }
        }
    }
}
