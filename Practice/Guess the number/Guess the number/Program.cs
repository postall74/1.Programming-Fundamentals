using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guess_the_number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number, lower, larger;
            int tryCount = 5;
            Random rand = new Random();
            int userInput;

            number =  rand.Next(0, 101);
            lower = rand.Next(number-10, number);
            larger = rand.Next(number+1, number+10);

            Console.WriteLine("Мы загадали число от 0 до 100, оно больше чем " + lower + " но меньше чем " + larger);
            Console.WriteLine("Что это за число?");

            while (tryCount-- > 0)
            {
                Console.Write("Это число: ");
                userInput = Convert.ToInt32(Console.ReadLine());

                if (userInput == number)
                {
                    Console.WriteLine("Ты угадал - это было число " + number + ".");
                    break;
                }
                else
                {
                    Console.WriteLine("Не угадал, попробуй еще разок.");
                } 
            }
            if (tryCount < 0)
            {
                Console.WriteLine("Вы проиграли, попробуй новую игру! Это было число " + number);
            }
        }
    }
}
