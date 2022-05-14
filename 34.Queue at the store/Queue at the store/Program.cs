using System;
using System.Collections.Generic;

namespace Queue_at_the_store
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Queue<int> shoppingQueue = new Queue<int>();
            Random random = new Random();
            int maximalLengthQueue = 20;
            int maximalSummShopping = 5000;
            int cashBox = 0;
            FillShoppingQueue(shoppingQueue, maximalLengthQueue, maximalSummShopping, random);
            bool isCloseCashBox = false;

            while (isCloseCashBox == false)
            {
                Console.Clear();
                Console.SetCursorPosition(0, 1);
                Console.WriteLine("Очередь покупок:");

                foreach (int summQueue in shoppingQueue)
                {
                    Console.WriteLine(summQueue);
                }
                Console.WriteLine($"\nСледующая покупка будет на сумму - {shoppingQueue.Peek()}");
                Console.SetCursorPosition(0, 0);
                PaymentForPurchase(shoppingQueue, ref cashBox, ref isCloseCashBox);
                Console.ReadKey(true);
            }
        }

        private static void FillShoppingQueue(Queue<int> queue, int maximalLength, int maximalSummShopping, Random random)
        {
            for (int i = 0; i < random.Next(maximalLength); i++)
            {
                queue.Enqueue(random.Next(maximalSummShopping));
            }
        }

        private static void PaymentForPurchase(Queue<int> queue, ref int cashBox, ref bool isCloseCashBox)
        {
            if (queue.Count == 1)
            {
                isCloseCashBox = true;
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write($"Денег в кассе - {cashBox}");
                Console.ForegroundColor = ConsoleColor.White;
                cashBox += queue.Dequeue();
                Console.ReadKey(true);
                Console.Clear();
                Console.WriteLine($"Очередь пуста! Сумма денег в кассе ровна {cashBox}.");
            }
            else
            {
                isCloseCashBox = false;
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write($"Денег в кассе - {cashBox}");
                Console.ForegroundColor = ConsoleColor.White;
                cashBox += queue.Dequeue();
            }
        }
    }
}