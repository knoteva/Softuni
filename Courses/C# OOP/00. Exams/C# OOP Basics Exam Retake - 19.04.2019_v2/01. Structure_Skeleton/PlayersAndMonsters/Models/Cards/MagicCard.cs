using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Models.Cards
{
    public class MagicCard : Card
    {
        private const int initialDamagePoints = 5;
        private const int initialHealthPoints = 80;
        //Has 5 damage points and 80 health points.
        public MagicCard(string name) 
            : base(name, initialDamagePoints, initialHealthPoints)
        {
        }
    }
}
