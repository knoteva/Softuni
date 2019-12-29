using PlayersAndMonsters.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Models.Players
{
    public class Advanced : Player
    {
        private const int initialHealth = 250;

        public Advanced(ICardRepository cardRepository, string username)
            : base(cardRepository, username, initialHealth)
        {
        }
    }

}
