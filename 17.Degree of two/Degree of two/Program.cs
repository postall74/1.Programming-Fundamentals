using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Degree_of_two
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int number = 2;
            int dagree = 1;
            int minNumber;
            int maxNumber;
            Console.WriteLine("Введите минимальное и максимальное число интервала: ");
            Console.Write("Минимальное число: ");
            minNumber = Convert.ToInt32(Console.ReadLine());
            Console.Write("Максимальное число: ");
            maxNumber = Convert.ToInt32(Console.ReadLine());
            int randomNumber = random.Next(minNumber, maxNumber);
            int exponentialNumber = number;
            Console.WriteLine("Загаданное число - " + randomNumber);

            while (randomNumber >= exponentialNumber)
            {
                exponentialNumber *= number;
                dagree++;
            }
            Console.WriteLine("Для числа " + randomNumber + " будет " + number + " в степени " + dagree + " т.е. " + exponentialNumber + ". " + randomNumber + " < " + exponentialNumber);
            Console.ReadKey();
        }
    }
}
