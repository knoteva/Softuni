using AdoNetEx;
using System;
using System.Data.SqlClient;

namespace _06._problem
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
                var villainNameQuery = @"SELECT Name FROM Villains WHERE Id = @villainId";
                var command = new SqlCommand(villainNameQuery, connection);

                using (command)
                {
                    command.Parameters.AddWithValue("@villainId", id);
                    var villainName = command.ExecuteScalar();
                    if (villainName == null)
                    {
                        Console.WriteLine($"No such villain was found.");
                        return;
                    }
                    Console.WriteLine($"{villainName} was deleted.");
                }
                var deletedVilliansMinions = deleteMinionVilliansById(connection, id);
                Console.WriteLine($"{deletedVilliansMinions} minions were released.");
                var deletedVillians = deleteVilianById(connection, id);
                //Console.WriteLine(deletedVillians);
            }
        }

        private static int deleteVilianById(SqlConnection connection, int id)
        {
            var deleteVillianQuery = @"DELETE FROM Villains
                                        WHERE Id = @villainId";
            var command = new SqlCommand(deleteVillianQuery, connection);
            using (command)
            {
                command.Parameters.AddWithValue("@villainId", id);
                var deletedVillians = command.ExecuteNonQuery();
                return deletedVillians;
            }
        }

        private static int deleteMinionVilliansById(SqlConnection connection, int id)
        {
            var deleteVillainQuery = @"DELETE FROM MinionsVillains 
                                        WHERE VillainId = @villainId";
            var command = new SqlCommand(deleteVillainQuery, connection);
            using (command)
            {
                command.Parameters.AddWithValue("@villainId", id);
                var deletedVillians = command.ExecuteNonQuery();
                return deletedVillians;
            }
        }
    }
}
