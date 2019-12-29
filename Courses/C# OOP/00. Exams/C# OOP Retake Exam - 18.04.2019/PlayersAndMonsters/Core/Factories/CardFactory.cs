using PlayersAndMonsters.Core.Factories.Contracts;
using PlayersAndMonsters.Models.Cards;
using PlayersAndMonsters.Models.Cards.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Core.Factories
{
    public class CardFactory : ICardFactory
    {
        public ICard CreateCard(string type, string name)
        {
            switch (type)
            {
                case "Magic":
                    return new MagicCard(name);
                case "Trap":
                    return new TrapCard(name);
                default:
                    return null;
            }
        }
    }
}
