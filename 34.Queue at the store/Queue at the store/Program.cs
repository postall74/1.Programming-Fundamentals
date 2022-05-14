﻿using System;
using System.Collections.Generic;

namespace Queue_at_the_store
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Queue<int> shoppingQueue = new Queue<int>();
            int cashBox = 0;
            shoppingQueue = FillShoppingQueue();

            while (shoppingQueue.Count > -1)
            {
                Console.Clear();

                if (shoppingQueue.Count == 0)
                {
                    Console.WriteLine($"Очередь пуста! Сумма денег в кассе ровна {cashBox}.");
                    break;
                }
                Console.SetCursorPosition(0, 1);
                Console.WriteLine("Очередь покупок:");

                foreach (int summQueue in shoppingQueue)
                {
                    Console.WriteLine(summQueue);
                }

                Console.WriteLine($"\nСледующая покупка будет на сумму - {shoppingQueue.Peek()}");
                Console.SetCursorPosition(0, 0);
                CashBox(shoppingQueue,ref cashBox);
                Console.ReadKey(true);
            }
        }

        static Queue<int> FillShoppingQueue()
        {
            Queue<int> shoppingQueue = new Queue<int>();
            int[] array;
            Random random = new Random();
            int minimalLengthQueue = 10;
            int maximalLengthQueue = 20;
            int minimalSummShopping = 100;
            int maximalSummShopping = 5000;
            array = new int[random.Next(minimalLengthQueue, maximalLengthQueue)];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(minimalSummShopping, maximalSummShopping);
            }

            for (int i = 0; i < array.Length; i++)
            {
                shoppingQueue.Enqueue(array[i]);
            }
            return shoppingQueue;
        }
        static void CashBox(Queue<int> queue, ref int cashBox)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write($"Денег в кассе - {cashBox}");
            Console.ForegroundColor = ConsoleColor.White;
            cashBox += queue.Dequeue();
        }
    }
}
