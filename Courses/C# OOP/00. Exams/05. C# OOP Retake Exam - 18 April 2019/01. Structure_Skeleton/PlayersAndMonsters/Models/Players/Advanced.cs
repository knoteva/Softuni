using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Models.Players
{
    public class Advanced : Player, IPlayer
    {
        private const int initialHealth = 250;
        public Advanced(ICardRepository cardRepository, string username) 
            : base(cardRepository, username, initialHealth)
        {
        }
    }
}


//Has 250 initial health points.
//Constructor should take the following values upon initialization:
//ICardRepository cardRepository, string username
