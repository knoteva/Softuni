using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Models.Cards
{
    public class TrapCard : Card
    {
        private const int initialdamagePoints = 120;
        private const int initialHealthPoints = 5;
        public TrapCard(string name)
            : base(name, initialdamagePoints, initialHealthPoints)
        {
        }
    }
}
