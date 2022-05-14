using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Largest_element
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            //Минимальное и максимальное число записываемое в каждую ячейку массива
            int minimalNumber = 0;
            int maximalNumber = 100;
            //Переменные для поиска максимального числа в массиве и индекса ячейки массива 
            int maximumNumberInArray = 0;
            //Массив размером 10х10
            int[,] array = new int[10, 10];
            Console.WriteLine("Исходная матрица 10Х10");

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = random.Next(minimalNumber, maximalNumber);
                    Console.Write(array[i, j]);

                    if (array[i, j] > 9)
                    {
                        Console.Write(" | ");
                    }
                    else
                    {
                        Console.Write("  | ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] > maximumNumberInArray)
                    {
                        maximumNumberInArray = array[i, j];
                    }
                }
            }
            Console.WriteLine("Получившаяся матрица");

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] == maximumNumberInArray)
                    {
                        array[i, j] = 0;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(array[i, j]);
                        Console.ForegroundColor = ConsoleColor.White;

                        if (array[i, j] > 9)
                        {
                            Console.Write(" | ");
                        }
                        else
                        {
                            Console.Write("  | ");
                        }
                    }
                    else
                    {
                        Console.Write(array[i, j]);

                        if (array[i, j] > 9)
                        {
                            Console.Write(" | ");
                        }
                        else
                        {
                            Console.Write("  | ");
                        }
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("Максимальное чисо -  " + maximumNumberInArray);
            Console.ReadKey();
        }
    }
}
