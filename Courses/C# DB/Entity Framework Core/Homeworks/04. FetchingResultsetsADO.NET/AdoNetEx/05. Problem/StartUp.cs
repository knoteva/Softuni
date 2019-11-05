using AdoNetEx;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace _05._Problem
{
    public class StratUp
    {
        public static void Main(string[] args)
        {
            var country = Console.ReadLine();
            var connection = new SqlConnection(Configuration.ConnectionString);

            using (connection)
            {
                connection.Open();
                var updateTownsQuerey = @"UPDATE Towns
                                            SET Name = UPPER(Name)
                                            WHERE CountryCode = (SELECT c.Id FROM Countries AS c WHERE c.Name = @countryName)";
                var command = new SqlCommand(updateTownsQuerey, connection);

                using (command)
                {
                    command.Parameters.AddWithValue("@countryName", country);
                    int count = command.ExecuteNonQuery();
                    Console.WriteLine($"{count} town names were affected.");
                }
                var selectTownsQuerry = @"SELECT t.Name 
                                                FROM Towns as t
                                                JOIN Countries AS c ON c.Id = t.CountryCode
                                                WHERE c.Name = @countryName";

                command = new SqlCommand(selectTownsQuerry, connection);
                using (command)
                {
                    command.Parameters.AddWithValue("@countryName", country);
                    var reader = command.ExecuteReader();
                    var towns = new List<string>();
                    while (reader.Read())
                    {
                        towns.Add((string)reader[0]);
                    }

                    Console.WriteLine('[' + string.Join(", ", towns) + ']');
                }
            }
        }
    }
}
