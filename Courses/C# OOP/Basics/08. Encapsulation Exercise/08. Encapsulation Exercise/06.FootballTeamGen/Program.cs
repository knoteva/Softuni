namespace FootballTeamGen
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {

            //var list = new List<int>();
            //list.Add(80);
            //list.Add(83);
            //Console.WriteLine(list.Average());
            var teams = new List<Team>();
            var line = string.Empty;

            while ((line = Console.ReadLine()) != "END")
            {
                string command = line.Split(";")[0];
                string currName = line.Split(";")[1];

                if (command == "Team")
                {
                    teams.Add(new Team(currName));
                }
                else
                {
                    Team team = teams.Find(t => t.Name == currName);

                    if (team == null)
                    {
                        Console.WriteLine($"Team {currName} does not exist.");
                        continue;
                    }

                    try
                    {
                        string[] commandLine = line.Split(';');

                        if (command == "Add")
                        {
                            team.AddPlayer(new Player(commandLine[2], int.Parse(commandLine[3]),
                            int.Parse(commandLine[4]), int.Parse(commandLine[5]), int.Parse(commandLine[6]), int.Parse(commandLine[7])));
                        }
                        else if (commandLine[0] == "Remove")
                        {
                            team.RemovePlayer(commandLine[2]);
                        }
                        else if (commandLine[0] == "Rating")
                        {
                            team.PrintRating();
                        }
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

                
            }
        }
    }
}
