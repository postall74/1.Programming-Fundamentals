using System;

namespace Local_maxima
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int maximumLengthArray = 50;
            int minimumNumberInArray = 0;
            int maximumNumberInArray = 100;
            int[] array = new int[maximumLengthArray];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(minimumNumberInArray, maximumNumberInArray);
            }

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " | ");
            }
            Console.WriteLine("\n");

            if (array[0] > array[1])
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(array[0]);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" | ");
            }
            else
            {
                Console.Write(array[0] + " | ");
            }

            for (int i = 1; i < array.Length - 1; i++)
            {
                if (array[i - 1] < array[i] && array[i] > array[i + 1])
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(array[i]);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(" | ");
                }
                else
                {
                    Console.Write(array[i] + " | ");
                }
            }

            if (array[array.Length - 1] > array[array.Length - 2])
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(array[array.Length - 1]);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" | ");
            }
            else
            {
                Console.Write(array[array.Length - 1] + " | ");
            }
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
