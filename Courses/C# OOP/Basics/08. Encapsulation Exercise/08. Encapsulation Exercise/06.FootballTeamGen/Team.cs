using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballTeamGen
{
    public class Team
    {
        private string name;
        private List<Player> players;

        public Team(string name)
        {
            Name = name;
            players = new List<Player>();
        }

        public string Name
        {
            get => name; 
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }

                name = value;
            }
        }
        public List<Player> Players { get => players; set => players = value; }

        public void AddPlayer(Player player)
        {
            this.players.Add(player);
        }

        public double GetRating()
        {
            if (this.players.Count == 0)
            {
                return 0;
            }
            else
            {
                return this.players.Select(p => p.SkillLevel).Average();
            }
        }
        public void RemovePlayer(string playerName)
        {
            if (!this.players.Any(p => p.Name == playerName))
            {
                throw new ArgumentException($"Player {playerName} is not in {this.Name} team.");
            }

            this.players.Remove(players.Find(p => p.Name == playerName));
        }

        public void PrintRating()
        {
            Console.WriteLine($"{this.Name} - {Math.Round((this.GetRating()))}");
        }
    }
}
