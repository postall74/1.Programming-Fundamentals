using System;

namespace Sorting_numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int minimalLengthArray = 10;
            int maximalLengthArray = 30;
            int minimalNumberInArray = -100;
            int maximalNumberInArray = 100;
            int[] array = new int[random.Next(minimalLengthArray, maximalLengthArray)];
            int tempNumber;

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(minimalNumberInArray, maximalNumberInArray);
            }

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " | ");
            }
            Console.WriteLine("\n");

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] > array[j])
                    {
                        tempNumber = array[i];
                        array[i] = array[j];
                        array[j] = tempNumber;
                    }
                }
            }

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " | ");
            }
            Console.WriteLine("\n");
            Console.ReadLine();
        }
    }
}
