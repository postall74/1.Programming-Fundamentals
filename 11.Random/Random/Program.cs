using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Randomize
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            int number = rand.Next(0, 100);
            int summAllPositiveNumbers = number;
            int stepThree = 3;
            int stepFive = 5;
            Console.WriteLine("Рандомное число: " + number);
            Console.WriteLine("Список чисел от 0 до " + number + " :");

            for (int i = 0; i < number; i++)
            {
                if (i % stepThree == 0 || i % stepFive == 0)
                {
                    Console.WriteLine(i);
                    summAllPositiveNumbers += i;
                }
            }
            Console.WriteLine("Сумма всех полодительных чисел, которые кратны 3 и 5. И рандомного числа: " + summAllPositiveNumbers);
        }
    }
}