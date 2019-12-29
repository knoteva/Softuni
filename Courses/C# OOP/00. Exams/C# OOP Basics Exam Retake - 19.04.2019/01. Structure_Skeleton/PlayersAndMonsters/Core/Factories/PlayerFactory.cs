using PlayersAndMonsters.Core.Factories.Contracts;
using PlayersAndMonsters.Models.Players;
using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Core.Factories
{
    public class PlayerFactory : IPlayerFactory
    {
        public IPlayer CreatePlayer(string type, string username)
        {
            Player player = null;
            switch (type)
            {
                case "Advanced":
                    player = new Advanced(new CardRepository(), username);
                    break;
                case "Beginner":
                    player = new Beginner(new CardRepository(), username);
                    break;
                default:
                    return null;
            }
            return player;
        }
    }
}
