using AdoNetEx;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace _08._Problem
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var ids = Console.ReadLine().Split(" ");
            var connection = new SqlConnection(Configuration.ConnectionString);

            using (connection)
            {
                connection.Open();
                var updateTownsQuerey = @"UPDATE Minions
                                        SET Name = UPPER(LEFT(Name, 1)) + SUBSTRING(Name, 2, LEN(Name)), Age += 1
                                        WHERE Id = @Id";
                var command = new SqlCommand(updateTownsQuerey, connection);
                foreach (var id in ids)
                {
                    
                    using (command)
                    {
                        command.Parameters.AddWithValue("@Id", id);
                        command.ExecuteScalar();
                    }
                }
                var minionsQuerry = @"SELECT Name, Age 
                                            FROM Minions";
                command = new SqlCommand(minionsQuerry, connection);
                using (command)
                {
                    var reader = command.ExecuteReader();
                    var minions = new Dictionary<string, int>();
                    while (reader.Read())
                    {
                        minions.Add((string)reader[0], (int)reader[1]);
                    }
                    foreach (var minion in minions)
                    {
                        Console.WriteLine($"{minion.Key} {minion.Value}");
                    }
                }
            }
        }
    }
}

