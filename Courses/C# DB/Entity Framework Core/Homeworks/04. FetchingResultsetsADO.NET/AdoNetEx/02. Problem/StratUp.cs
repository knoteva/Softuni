using AdoNetEx;
using System;
using System.Data.SqlClient;

namespace _02._Problem
{
   public class StartUp
    {
        public static void Main(string[] args)
        {
            var connection = new SqlConnection(Configuration.ConnectionString);

            using (connection)
            {
                connection.Open();
                string sqlQuery = @"SELECT v.Name, COUNT(mv.VillainId) AS MinionsCount  
                                        FROM Villains AS v 
                                    JOIN MinionsVillains AS mv ON v.Id = mv.VillainId 
                                    GROUP BY v.Id, v.Name 
                                    HAVING COUNT(mv.VillainId) > 3 
                                    ORDER BY COUNT(mv.VillainId)";
                var command = new SqlCommand(sqlQuery, connection);
                using (command)
                {
                    var reader = command.ExecuteReader();
                    using (reader)
                    {
                        while (reader.Read())
                        {
                            var name = reader[0];
                            var count = reader["MinionsCount"];
                            Console.WriteLine($"{name} - {count}");
                        }
                    }
                }
            }
        }
    }
}
