using PlayersAndMonsters.Models.Cards.Contracts;
using PlayersAndMonsters.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlayersAndMonsters.Repositories
{
    public class CardRepository : ICardRepository
    {
        private readonly List<ICard> cards;

        public CardRepository()
        {
            this.cards = new List<ICard>();
        }

        public int Count => Cards.Count();

        public IReadOnlyCollection<ICard> Cards => this.cards.AsReadOnly();

        public void Add(ICard card)
        {
            IsCardrNull(card);

            if (cards.Any(x => x.Name == card.Name))
            {
                throw new ArgumentException($"Card {card.Name} already exists!");
            }
            cards.Add(card);
        }

        public ICard Find(string name)
        {
            var card = cards.Find(x => x.Name == name);
            IsCardrNull(card);
            return card;
        }

        public bool Remove(ICard card)
        {
            IsCardrNull(card);
            return cards.Remove(card);
        }

        private static void IsCardrNull(ICard card)
        {
            if (card == null)
            {
                throw new ArgumentException($"Card cannot be null!");
            }
        }
    }
}
