using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Card_deck
{
    enum Name : int
    {
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King,
        Ace
    }

    enum Suit : int
    {
        Peak,
        Clubs,
        Hearts,
        Diamonds
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player(new List<Card> { });
            Deck deck = new Deck(new List<Card> { });
            bool isExit = false;

            while (isExit == false)
            {
                Console.Clear();
                Console.WriteLine("Deck cards");
                Console.SetCursorPosition(0, 2);
                Console.WriteLine("1.Show the deck\n2.Suffle the deck\n3.Take on the card from deck\n" +
                    "4.Teke several cards from the deck\n5.Show player card \n6.Exit");
                string userInput;
                Console.SetCursorPosition(0, 11);
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        deck.Show();
                        break;
                    case "2":
                        deck.Shuffle();
                        break;
                    case "3":
                        deck.GiveCard(player);
                        break;
                    case "4":
                        deck.GiveCards(player);
                        break;
                    case "5":
                        player.Show();
                        break;
                    case "6":
                        isExit = true;
                        Console.WriteLine("God bye!");
                        break;
                    default:
                        Console.WriteLine($"Retype the command");
                        break;
                }
                Console.ReadKey(true);
            }
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
        private List<Card> _cards;

        public Deck(List<Card> deck)
        {
            _cards = deck;
            Create();
        }
        
        public void Shuffle()
        {
            Random random = new Random();

            for (int i = _cards.Count - 1; i > 0; i--)
            {
                int cardIndex = random.Next(i + 1);
                Card tempCard = _cards[i];
                _cards[i] = _cards[cardIndex];
                _cards[cardIndex] = tempCard;
            }
        }

        public void Show()
        {
            if (IsEmpty() == false)
            {
                foreach (var card in _cards)
                {
                    Console.Write($"{card.Name} {card.Suit} | ");
                }
                Console.WriteLine();
            }
        }

        public Card GiveCard(Player player)
        {
            Card card = null;

            if (IsEmpty() == false)
            {
                List<Card> tempDeck = _cards;
                card = tempDeck.First();
                tempDeck.Remove(card);
                _cards = tempDeck;
                player.TakeCard(card);
            }
            return card;
        }

        public List<Card> GiveCards(Player player)
        {
            List<Card> cards = new List<Card>();

            if (IsEmpty() == false)
            {
                List<Card> tempDeck = _cards;
                int count;
                Console.Write("Enter the number of cards you want to take - ");

                if (int.TryParse(Console.ReadLine(), out count) == false)
                {
                    Console.WriteLine($"You didn't enter a number");
                }
                else
                {
                    if (_cards.Count >= count)
                    {
                        for (int i = 0; i < count; i++)
                        {
                            cards.Add(GiveCard(player));
                        }
                    }
                    else
                    {
                        Console.WriteLine($"The number of cards in the deck is less than what you ask for");
                    }
                }
            }
            return cards;
        }

        private void Create()
        {
            int nameCards = Enum.GetValues(typeof(Name)).Length;
            int suitCards = Enum.GetValues(typeof(Suit)).Length;

            for (int i = 0; i < suitCards; i++)
            {
                for (int j = 0; j < nameCards; j++)
                {
                    Card card = new Card((Name)j, (Suit)i);
                    _cards.Add(card);
                }
            }
        }

        private bool IsEmpty()
        {
            bool isEmpty = false;

            if (_cards.Count <= 0)
            {
                Console.WriteLine($"Empty deck");
                isEmpty = true;
            }
            return isEmpty;
        }

    }

    class Player
    {
        private List<Card> _cards;

        public Player(List<Card> cards)
        {
            _cards = cards;
        }

        public void TakeCard(Card card)
        {
            _cards.Add(card);
        }

        public void TakeCards(List<Card> cards)
        {
            foreach (var card in cards)
            {
                TakeCard(card);
            }
        }

        public void Show()
        {
            if (IsEmpty() == false)
            {
                foreach (var card in _cards)
                {
                    Console.Write($"{card.Name} {card.Suit} | ");
                }
            }
        }

        private bool IsEmpty()
        {
            bool isEmpty = false;

            if (_cards.Count <= 0)
            {
                Console.WriteLine($"Player's deck is empty");
                isEmpty = true;
            }
            return isEmpty;
        }
    }
}
