using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Models.Cards
{
    public class TrapCard : Card
    {
        private const int initialDamagePoints = 120;
        private const int initialHealthPoints = 5;
        //Has 120 damage points and 5 health points.
        public TrapCard(string name)
            : base(name, initialDamagePoints, initialHealthPoints)
        {
        }
    }
}
