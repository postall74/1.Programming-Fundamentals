using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynamic_array_advanced
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();
            string userInput = "";
            bool isExit = false;

            while (isExit == false)
            {
                Console.Clear();
                Console.WriteLine("\nSum - получить сумму всех чисел в List<int>\nExit - выход из программы\n");

                foreach (int number in list)
                {
                    Console.Write(number + " | ");
                }
                Console.WriteLine();
                userInput = Console.ReadLine().ToLower();

                if (userInput == "exit")
                {
                    isExit = true;
                    Console.WriteLine("До встречи!");
                }
                else if (userInput == "sum")
                {
                    foreach (int number in list)
                    {
                        Console.Write(number + " | ");
                    }
                    Console.WriteLine($"\nСумма числе в List<int> - {list.Sum()}");
                    Console.ReadKey(true);
                }
                else
                {
                    AddToList(list, userInput);
                }
            }
        }

        static void AddToList (List<int> list, string userInput)
        {
            int number;
            if (int.TryParse(userInput, out number) == true)
            {
                list.Add(number);
            }
        }
    }
}
