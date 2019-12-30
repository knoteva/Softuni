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
        private readonly List<IPlayer> players;

        public PlayerRepository()
        {
            this.players = new List<IPlayer>();
        }

        public int Count => Players.Count();

        public IReadOnlyCollection<IPlayer> Players => this.players.AsReadOnly();
        public void Add(IPlayer player)
        {
            IsPlayerNull(player);

            if (players.Any(x => x.Username == player.Username))
            {
                throw new ArgumentException($"Player {player.Username} already exists!");
            }
            players.Add(player);
        }
  
        //•	If the player is null, throw an ArgumentException with message "Player cannot be null".
        //•	If a player exists with a name equal to the name of the given player, throw an ArgumentException with message "Player {username} already exists!".

        public IPlayer Find(string username)
        {
            var player = players.Find(x => x.Username == username);
            IsPlayerNull(player);
            return player;
        }

        //  Removes a player from the collection.
        //•	If the player is null, throw an ArgumentException with message "Player cannot be null".

        public bool Remove(IPlayer player)
        {
            IsPlayerNull(player);
            return players.Remove(player);
        }


        private static void IsPlayerNull(IPlayer player)
        {
            if (player == null)
            {
                throw new ArgumentException($"Player cannot be null");
            }
        }
    }
}
