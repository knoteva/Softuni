using PlayersAndMonsters.Models.Cards.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Models.Cards
{
    public class TrapCard : Card, ICard
    {
        private const int InitialDamagePoints = 120;
        private const int InitialHealthPoints = 5;

        public TrapCard(string name) 
            : base(name, InitialDamagePoints, InitialHealthPoints)
        {
        }
    }
}


//Has 120 damage points and 5 health points.
//Constructor should take the following values upon initialization:
//string name
