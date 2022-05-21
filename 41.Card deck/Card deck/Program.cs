using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Card_deck
{
    enum Name : int
    {
        two,
        three,
        four,
        five,
        six,
        seven,
        eight,
        nine,
        ten,
        Jack,
        Queen,
        King,
        Ace
    }

    enum Suit : int
    {
        peak,
        clubs,
        hearts,
        tambourine
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Deck deck = new Deck(new List<Card> { });
            deck.CreateDeck();
            deck.Show();
            Console.WriteLine();
            Card card = deck.TakeCard();
            Console.WriteLine(card.Name + " " + card.Suit);
            Console.WriteLine();
            deck.Show();
        }
    }

    class Card
    {
        public Name Name { get; private set; }
        public Suit Suit { get; private set; }

        public Card(Name name, Suit siut)
        {
            Name = name;
            Suit = siut;
        }
    }

    class Deck
    {
        private List<Card> _deck;

        public Deck(List<Card> deck)
        {
            _deck = deck;
        }

        public List<Card> CreateDeck()
        {
            int nameCards = 13;
            int suitCards = 4;

            for (int i = 0; i < suitCards; i++)
            {
                for (int j = 0; j < nameCards; j++)
                {
                    Card card = new Card((Name)j, (Suit)i);
                    _deck.Add(card);
                }
            }
            return _deck;
        }
        public List<Card> Shuffle()
        {
            Random random = new Random();
            List<Card> tempDeck = new List<Card>(_deck);

            for (int i = _deck.Count - 1; i > 0; i--)
            {
                int cardIndex = random.Next(i + 1);
                Card tempCard = tempDeck[i];
                tempDeck[i] = tempDeck[cardIndex];
                tempDeck[cardIndex] = tempCard;
            }
            _deck = tempDeck;
            return _deck;
        }

        public void Show()
        {
            foreach (var card in _deck)
            {
                Console.Write($"{card.Name} {card.Suit} | ");
            }
            Console.WriteLine();
        }

        public Card TakeCard()
        {
            Card card = null;
            List<Card> tempDeck = _deck;
            card  = tempDeck.First();
            tempDeck.Remove(card);
            _deck = tempDeck;
            return card;
        }
    }

    // class Player
    //{
    //   public int   
    // }
}
