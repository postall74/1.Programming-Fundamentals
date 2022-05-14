using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Readint
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number;
            number = ReadIntInString();
            Console.WriteLine($"Конввертировано в {number}");
            Console.ReadKey();
        }

        static int ReadIntInString()
        {
            int number;
            bool isSuccess;
            string text;
            Console.WriteLine("Напишите в строке что нибудь и мы узнаем является ли это числом:");
            text = Console.ReadLine();
            isSuccess = int.TryParse(text, out number);

            while (isSuccess == false)
            {
                Console.WriteLine($"Не получилось конвертировать '{text}', попробуй еще раз");
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine("Напишите в строке что нибудь и мы узнаем является ли это числом:");
                text = Console.ReadLine();
                isSuccess = int.TryParse(text, out number);
            }
            return number;
        }
    }
}
