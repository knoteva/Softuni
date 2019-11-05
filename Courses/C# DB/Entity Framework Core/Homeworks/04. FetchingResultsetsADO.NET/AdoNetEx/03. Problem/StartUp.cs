using AdoNetEx;
using System;
using System.Data.SqlClient;

namespace _03._Problem
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var id = int.Parse(Console.ReadLine());
            var connection = new SqlConnection(Configuration.ConnectionString);

            using (connection)
            {
                connection.Open();
                var villianNameQuerey = @"SELECT Name FROM Villains WHERE Id = @Id";
                var command = new SqlCommand(villianNameQuerey, connection);
                command.Parameters.AddWithValue("@Id", id);
                using (command)
                {
                    var villianName = (string)command.ExecuteScalar();
                    if (villianName == null)
                    {
                        Console.WriteLine($"No villain with ID {id} exists in the database.");
                        return;
                    }
                    Console.WriteLine($"Villain: {villianName}");
                }
                var minionsQuery = @"SELECT ROW_NUMBER() OVER (ORDER BY m.Name) as RowNum,
                                         m.Name, 
                                         m.Age
                                    FROM MinionsVillains AS mv
                                    JOIN Minions As m ON mv.MinionId = m.Id
                                   WHERE mv.VillainId = @Id
                                ORDER BY m.Name";
                command = new SqlCommand(minionsQuery, connection);
                command.Parameters.AddWithValue("@Id", id);
                using (command)
                {
                    var reader = command.ExecuteReader();
                    using (reader)
                    {
                        if (!reader.HasRows)
                        {
                            Console.WriteLine($"(no minions)");
                            return;
                        }

                        while (reader.Read())
                        {
                            var rowNumber = reader[0];
                            var minionName = reader[1];
                            var minionAge = reader[2];
                            Console.WriteLine($"{rowNumber}.{minionName} {minionAge}");
                        }
                    }
                }
            }

        }
    }

}
