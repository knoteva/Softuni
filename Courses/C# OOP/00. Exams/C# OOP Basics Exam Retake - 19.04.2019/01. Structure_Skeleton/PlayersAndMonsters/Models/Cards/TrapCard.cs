using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Models.Cards
{
    public class TrapCard : Card
    {
        private const int initialHealthPoints = 5;
        private const int initialDamagePoints = 120;

        public TrapCard(string name) 
            : base(name, initialDamagePoints, initialHealthPoints)
        {
        }
    }
}
