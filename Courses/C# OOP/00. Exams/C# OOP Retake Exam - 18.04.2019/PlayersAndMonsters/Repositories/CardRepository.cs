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
        private int count;
        private readonly List<ICard> cards;
        public CardRepository()
        {
            this.cards = new List<ICard>();
        }
        public int Count { get => count; private set => count = value; }
        public IReadOnlyCollection<ICard> Cards => this.cards.AsReadOnly();


        private static void CheckIfCardIsNull(ICard card)
        {
            if (card == null)
            {
                throw new ArgumentException($"Card cannot be null!");
            }
        }
        public void Add(ICard card)
        {
            CheckIfCardIsNull(card);
            if (Cards.Any(c => c.Name == card.Name))
            {
                throw new ArgumentException($"Card {card.Name} already exists!");
            }
            cards.Add(card);
        }

        public ICard Find(string name)
        {
            var card = cards.FirstOrDefault(c => c.Name == name);
            CheckIfCardIsNull(card);
            return card;
        }

        public bool Remove(ICard card)
        {
            CheckIfCardIsNull(card);
            return cards.Remove(card);
        }
    }
}
