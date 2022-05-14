using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Name_output
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string userName;
            char userSymbol;
            Console.WriteLine("Введите имя пользователя: ");
            userName = Console.ReadLine();
            Console.WriteLine("Введите симвод обвода имени: ");
            userSymbol = Convert.ToChar(Console.ReadLine());

            for (int i = 0; i < userName.Length + 2; i++)
            {
                Console.Write(userSymbol);
            }
            Console.Write("\n" + userSymbol + userName + userSymbol + "\n");
            
            for (int i = 0; i < userName.Length + 2; i++)
            {
                Console.Write(userSymbol);
            }
            Console.WriteLine();
        }
    }
}
