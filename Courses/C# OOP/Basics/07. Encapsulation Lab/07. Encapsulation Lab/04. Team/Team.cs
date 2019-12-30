namespace PersonsInfo
{
    using System.Collections.Generic;
    public class Team
    {
        private string name;
        private List<Person> firstTeam;
        private List<Person> reserveTeam;

        public Team(string name)
        {
            Name = name;
            this.firstTeam = new List<Person>();
            this.reserveTeam = new List<Person>();
        }

        public string Name { get => name; set => name = value; }
        public List<Person> FirstTeam { get => firstTeam; }
        public List<Person> ReserveTeam { get => reserveTeam; }

        public void AddPlayer(Person player)
        {
            if (player.Age < 40)
            {
                firstTeam.Add(player);
            }
            else
            {
                reserveTeam.Add(player);
            }
        }
    }
}
