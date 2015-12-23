using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karty
{
    class Deck
    {
        private List<Card> cards;
        private Random random = new Random();
        public Deck()
        {
            cards = new List<Card>();
            for (int suit = 0; suit < 4; suit++)
                for (int value = 0; value < 14; value++)
                    cards.Add(new Card((Suits)suit, (Values)value));

        }

        public Deck(IEnumerable<Card> initialCard)
        {
            cards = new List<Card>(initialCard);
        }

        public int Count { get { return cards.Count; } }

        public void AddCard(Card cardToAdd)
        {
            cards.Add(cardToAdd);
        }
        public Card Deal(int index)
        {
            Card CardToDeal = cards[index];
            cards.RemoveAt(index);
            return CardToDeal;
        }
        public void Shuffle()
        {
            List<Card> NewCard = new List<Card>();
            while (cards.Count > 0)
            {
                int CardToMove = random.Next(cards.Count);
                NewCard.Add(cards[CardToMove]);
                cards.RemoveAt(CardToMove);
            }
            cards = NewCard;
        }

        public IEnumerable<string> GetCardName()
        {
            string[] CardName = new string[cards.Count];
            for (int i = 0; i < cards.Count; i++)
                CardName[i] = cards[i].Name;
            return CardName;
        }

        public void Sort()
        {
            cards.Sort(new CompareCardBySuit());
        }

    }
}
