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
        public int Count => Cards.Count;

        public IReadOnlyCollection<ICard> Cards => this.cards.AsReadOnly();

        public void Add(ICard card)
        {
            //•	If the card is null, throw an ArgumentException with message "Card cannot be null!".
            //•	If a card exists with a name equal to the name of the given card, throw an ArgumentException with message "Card {name} already exists!".
            IsCarExist(card);
            //if (this.cards.Contains(card))
            if (this.Cards.Any(x => x.Name == card.Name))
            {
                throw new ArgumentException($"Card {card.Name} already exists!");
            }
            cards.Add(card);
        }

       

        public ICard Find(string name)
        {
            var card = Cards.FirstOrDefault(x => x.Name == name);
            return card;
        }

        public bool Remove(ICard card)
        {
            IsCarExist(card);
            return cards.Remove(card);
        }

        private static void IsCarExist(ICard card)
        {
            if (card == null)
            {
                throw new ArgumentException("Card cannot be null!");
            }
        }
    }
}
