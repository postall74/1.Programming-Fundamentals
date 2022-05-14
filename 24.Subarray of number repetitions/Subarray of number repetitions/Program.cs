using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Subarray_of_number_repetitions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int minimalNumberInArray = 0;
            int maximalNumberInArray = 2;
            int[] array = new int[30];
            int number = 0;
            int numberOfRepetitions = 0;

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(minimalNumberInArray, maximalNumberInArray);
            }

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " | ");
            }
            Console.WriteLine();
            int currenceNumberOfRepetitions = 0;
            int currenceNumber = array[0];

            for (int i = 0; i < array.Length; i++)
            {
                if (currenceNumber == array[i])
                {
                    currenceNumberOfRepetitions++;
                }
                else
                {
                    currenceNumber = array[i];
                    currenceNumberOfRepetitions = 1;
                }

                if (currenceNumberOfRepetitions >= numberOfRepetitions)
                {
                    numberOfRepetitions = currenceNumberOfRepetitions;
                    number = currenceNumber;
                }
            }
            Console.WriteLine("Кол-во повторений - " + numberOfRepetitions + " числа - " + number + "\n\n");
            Console.ReadKey();
        }
    }
}
