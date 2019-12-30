using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Models.Players
{
    public class Beginner : Player, IPlayer
    {
        private const int initialHealth = 50;
         public Beginner(ICardRepository cardRepository, string username)
            : base(cardRepository, username, initialHealth)
        {
        }
    }
}


//Has 50 initial health points.
//Constructor should take the following values upon initialization:
//ICardRepository cardRepository, string username
