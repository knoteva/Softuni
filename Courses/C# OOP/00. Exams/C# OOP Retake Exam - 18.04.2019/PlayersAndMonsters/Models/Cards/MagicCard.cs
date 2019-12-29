using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Models.Cards
{
    public class MagicCard : Card
    {
        private const int initialdamagePoints = 5;
        private const int initialHealthPoints = 80;
        public MagicCard(string name) 
            : base(name, initialdamagePoints, initialHealthPoints)
        {
        }
    }
}
