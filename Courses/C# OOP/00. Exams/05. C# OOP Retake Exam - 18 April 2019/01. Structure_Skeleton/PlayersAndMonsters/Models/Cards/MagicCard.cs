using PlayersAndMonsters.Models.Cards.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Models.Cards
{
    public class MagicCard : Card, ICard
    {
        private const int InitialDamagePoints = 5;
        private const int InitialHealthPoints = 80;

        public MagicCard(string name) 
            : base(name, InitialDamagePoints, InitialHealthPoints)
        {
        }
    }
}

//Has 5 damage points and 80 health points.
//Constructor should take the following values upon initialization:
//string name
