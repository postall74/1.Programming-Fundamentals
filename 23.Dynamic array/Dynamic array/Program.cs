using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynamic_array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[0];
            int sum = 0;
            string userInput = "";
            bool isExit = false;

            while (isExit == false)
            {
                Console.Clear();
                Console.WriteLine("\nSum - получить сумму всех введеных чисел в массиве\nExit - завершить программу\n");
                userInput = Console.ReadLine();

                switch (userInput.ToLower())
                {
                    case "exit":
                        isExit = true;
                        Console.WriteLine("До свидания!");
                        break;
                    case "sum":
                        for (int i = 0; i < array.Length; i++)
                        {
                            sum += array[i];
                        }

                        for (int i = 0; i < array.Length; i++)
                        {
                            Console.Write(array[i] + " | ");
                        }
                        Console.WriteLine("Сумма все чисел массива - " + sum);
                        Console.ReadKey();
                        sum = 0;
                        break;
                    default:
                        int[] tempArray = new int[array.Length + 1];

                        for (int i = 0; i < array.Length; i++)
                        {
                            tempArray[i] = array[i];
                        }
                        tempArray[tempArray.Length - 1] = Convert.ToInt32(userInput);
                        array = tempArray;

                        for (int i = 0; i < array.Length; i++)
                        {
                            Console.Write(array[i] + " | ");
                        }
                        Console.ReadKey();
                        break;
                }
            }
            Console.ReadKey();
        }
    }
}
