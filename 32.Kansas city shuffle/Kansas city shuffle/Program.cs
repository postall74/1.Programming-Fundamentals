using System;

namespace Kansas_city_shuffle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] cardDeck = { "2♠", "2♣", "2♥", "2♦", "3♠", "3♣", "3♥", "3♦", "4♠", "4♣", "4♥", "4♦", "5♠", "5♣", "5♥", "5♦", "6♠", "6♣", "6♥", "6♦", "7♠", "7♣", "7♥", "7♦", "8♠", "8♣", "8♥", "8♦", "9♠", "9♣", "9♥", "9♦", "10♠", "10♣", "10♥", "10♦", "J♠", "J♣", "J♥", "J♦", "Q♠", "Q♣", "Q♥", "Q♦", "K♠", "K♣", "K♥", "K♦", "A♠", "A♣", "A♥", "A♦" };
            Console.WriteLine("Колода карт:\n");

            for (int i = 0; i < cardDeck.Length; i++)
            {
                Console.Write(cardDeck[i] + " ");
            }
            Console.WriteLine("\n\nПеремешанная колода:\n");
            Shuffle(cardDeck);

            for (int i = 0; i < cardDeck.Length; i++)
            {
                Console.Write(cardDeck[i] + " ");
            }
            Console.WriteLine();
            Console.ReadKey(true);
        }

        static void Shuffle(string[] cardDeck)
        {
            Random random = new Random();

            for (int i = cardDeck.Length - 1; i > 0; i--)
            {
                int cardIndex = random.Next(i + 1);
                string tempCardDeck = cardDeck[i];
                cardDeck[i] = cardDeck[cardIndex];
                cardDeck[cardIndex] = tempCardDeck;
            }
        }
    }
}
