using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Models.Cards
{
    public class MagicCard : Card
    {
        private const int initialHealthPoints = 80;
        private const int initialDamagePoints = 5;
        public MagicCard(string name) 
            : base(name, initialDamagePoints, initialHealthPoints)
        {
        }
    }
}
