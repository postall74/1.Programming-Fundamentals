using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Working_with_specific_rows_columns
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int maxRows = 10;
            int minRows = 2;
            int maxColumns = 10;
            int minColums = 2;
            int maxNumber = 100;
            int minNumber = -100;
            int sum = 0;
            long multiplication = 1;
            int rows = random.Next(minRows, maxRows);
            int colums = random.Next(minColums, maxColumns);
            int[,] array = new int[colums, rows];

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    int number = random.Next(minNumber, maxNumber);
                    array[i, j] = number;
                    Console.Write(array[i, j] + " | ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (i == 1 || j == 0)
                    {
                        Console.Write(array[i, j] + " | ");
                    }
                    else
                    {
                        Console.Write(" | ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            for (int i = 0; i < array.GetLength(0); i++)
            {
                sum += array[i, 0];
            }

            for (int i = 0; i < array.GetLength(1); i++)
            {
                multiplication *= array[1, i];
            }
            Console.WriteLine();
            Console.WriteLine("\n Сумма второй строки - " + sum + " и произведение первого столбца - " + multiplication);
            Console.ReadKey();
        }
    }
}
