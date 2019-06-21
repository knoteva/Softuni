using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Team_Projects
{
    class Program
    {
        static void Main(string[] args)
        {
            int teamCount = int.Parse(Console.ReadLine());
            var teams = new List<Team>();

            for (int i = 0; i < teamCount; i++)
            {
                string[] data = Console.ReadLine().Split("-");
                string user = data[0];
                string teamName = data[1];

                if (teams.Any(x => x.TeamName == teamName))
                {
                    Console.WriteLine($"Team {teamName} was already created!");
                    continue;
                }

                if (teams.Any(x => x.Creator == user))
                {
                    Console.WriteLine($"{user} cannot create another team!");
                    continue;
                }

                teams.Add(CreateTeam(data));
                Console.WriteLine($"Team {teamName} has been created by {user}!");
            }


            //string command = string.Empty;

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end of assignment")
                {
                    break;
                }

                string[] information = input.Split("->");
                string user = information[0];
                string teamName = information[1];

                if (!teams.Any(x => x.TeamName == teamName))
                {
                    Console.WriteLine($"Team {teamName} does not exist!");
                    continue;
                }

                if (teams.Any(x => x.Users.Contains(user)) || teams.Any(x => x.Creator == user))
                {
                    Console.WriteLine($"Member {user} cannot join team {teamName}!");
                    continue;
                }

                if (teams.Any(x => x.TeamName == teamName))
                {
                    Team existingTeam = teams.First(x => x.TeamName == teamName);
                    existingTeam.Users.Add(user);
                }
            }

            List<Team> disbanded = teams.Where(x => x.Users.Count == 0).ToList();
            teams = teams.Where(x => x.Users.Count > 0).ToList();
            foreach (var team in teams.OrderByDescending(x => x.Users.Count).ThenBy(x => x.TeamName))
            {
                Console.WriteLine($"{team.TeamName}");

                Console.WriteLine($"- {team.Creator}");

                foreach (var user in team.Users.OrderBy(x => x))
                {
                    Console.WriteLine($"-- {user}");
                }
            }

            Console.WriteLine($"Teams to disband:");

            foreach (var team in disbanded.OrderBy(x => x.TeamName))
            {
                Console.WriteLine(team.TeamName);
            }
        }

        public static Team CreateTeam(string[] information)
        {
            string creator = information[0];
            string teamName = information[1];

            return new Team
            {
                TeamName = teamName,
                Creator = creator,
                Users = new List<string>()
            };
        }
    }

    public class Team
    {
        public string TeamName { get; set; }
        public string Creator { get; set; }
        public List<string> Users { get; set; }
    }
}
