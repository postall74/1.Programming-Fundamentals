using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exit_control
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string userInput;
            Console.WriteLine("Привет друг! Напиши как тебя зовут! ");
            userInput = Console.ReadLine();

            while (userInput != "exit")
            {
                Console.WriteLine("Купи слона?!");
                userInput = Console.ReadLine();
            }
        }
    }
}