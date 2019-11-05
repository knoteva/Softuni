using AdoNetEx;
using System;
using System.Data.SqlClient;

namespace _04._Problem
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var connection = new SqlConnection(Configuration.ConnectionString);

            connection.Open();

            try
            {
                using (connection)
                {
                    var minionInfo = Console.ReadLine().Split(" ");

                    var minionName = minionInfo[1];
                    var minionAge = int.Parse(minionInfo[2]);
                    var town = minionInfo[3];

                    var villianInfo = Console.ReadLine().Split(" ");

                    var villianName = villianInfo[1];



                    var cmdTown = new SqlCommand($"SELECT Name FROM Towns WHERE Name = '{town}'", connection);
                    var townName = (string)cmdTown.ExecuteScalar();

                    var cmdVilian = new SqlCommand($"SELECT Name FROM Villains  WHERE Name = '{villianName}'", connection);
                    var villian = (string)cmdVilian.ExecuteScalar();

                    var cmdMinion = new SqlCommand($"SELECT Name FROM Minions WHERE Name = '{minionName}' and age = {minionAge}", connection);
                    var minion = (string)cmdMinion.ExecuteScalar();


                    if (string.IsNullOrEmpty(townName))
                    {
                        var insertTownsSQL = $"INSERT INTO Towns (Name) VALUES ('{town}')";
                        ExecuteCommand(insertTownsSQL, connection);
                    }

                    if (string.IsNullOrEmpty(minion))
                    {

                        var cmdTown2 = new SqlCommand($"SELECT Id FROM Towns WHERE Name = '{town}'", connection);

                        var townName2 = (int)cmdTown2.ExecuteScalar();

                        var insertMinionsSQL = $"INSERT INTO Minions (Name, Age, TownId) VALUES ('{minionName}',{minionAge},{townName2})";

                        ExecuteCommand(insertMinionsSQL, connection);
                    }

                    if (string.IsNullOrEmpty(villian))
                    {
                        var insertVillainsSQL = $"INSERT INTO Villains (Name, EvilnessFactorId) VALUES ('{villian}', 4)";

                        ExecuteCommand(insertVillainsSQL, connection);
                        Console.WriteLine($"Villain {villian} was added to the database.");
                    }

                    Console.WriteLine($"Successfully added {minionName} to be minion of {villianName}.");



                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }

        }

        private static void ExecuteCommand(string command, SqlConnection connection)
        {
            var cmd = new SqlCommand(command, connection);
            cmd.ExecuteNonQuery();

        }
    }
}
