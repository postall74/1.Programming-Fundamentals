using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Array_shift
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int minimalLengthArray = 10;
            int maximalLengthArray = 20;
            int minimalNumberInArray = -100;
            int maximalNumberInArray = 100;
            int[] array = new int[random.Next(minimalLengthArray, maximalLengthArray)];
            int tempNumber;
            int userInputArrayShift;

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(minimalNumberInArray, maximalNumberInArray);
            }

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " | ");
            }
            Console.WriteLine("\n");

            Console.Write("На какое кол-во произвести сдвиг массива - ");
            userInputArrayShift = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < userInputArrayShift; i++)
            {
                tempNumber = array[0];
                for (int j = 0; j < array.Length - 1; j++)
                {
                    array[j] = array[j + 1];
                }
                array[array.Length - 1] = tempNumber;
            }
            Console.WriteLine("\n");

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " | ");
            }
            Console.WriteLine("\n");
            Console.ReadLine();

        }
    }
}
