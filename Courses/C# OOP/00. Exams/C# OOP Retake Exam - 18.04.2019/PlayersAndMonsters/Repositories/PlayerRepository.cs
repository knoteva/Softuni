using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlayersAndMonsters.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private int count;
        private readonly List<IPlayer> players;
        public PlayerRepository()
        {
            this.players = new List<IPlayer>();
        }
        public int Count { get => count; private set => count = value; }
        public IReadOnlyCollection<IPlayer> Players => this.players.AsReadOnly();

        private static void CheckIfPlayerIsNull(IPlayer player)
        {
            if (player == null)
            {
                throw new ArgumentException($"Player cannot be null");
            }
        }
        public void Add(IPlayer player)
        {
            CheckIfPlayerIsNull(player);
            if (Players.Any(p => p.Username == player.Username))
            {
                throw new ArgumentException($"Player {player.Username} already exists!");
            }
            players.Add(player);
        }        

        public IPlayer Find(string username)
        {
            var player = players.FirstOrDefault(p => p.Username == username);
            CheckIfPlayerIsNull(player);
            return player;
        }

        public bool Remove(IPlayer player)
        {
            CheckIfPlayerIsNull(player);
            return players.Remove(player);
        }
    }
}
