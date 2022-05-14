using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Password_protected_program
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string userInput = "";
            string password = "123456";
            Console.WriteLine("Введите пароль, для прочтения сообщения! ");
            string message = "Доступ к секретику!";
            int inputCount = 3;

            for (int i = inputCount; i >= 1; i--)
            {
                userInput = Console.ReadLine();

                if (userInput == password)
                {
                    Console.WriteLine("Секретное сообщение: " + message);
                    break;
                }
                else
                {
                    Console.WriteLine("Повторите ввод пароля! У вас осталось " + (i - 1) + " попыток.");
                }
            }
            Console.WriteLine("До встречи!");
            Console.ReadKey();
        }
    }
}
