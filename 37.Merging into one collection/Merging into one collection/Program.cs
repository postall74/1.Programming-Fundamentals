using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merging_into_one_collection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();
            int[] firstArrayNumbers;
            int[] secondArrayNumbers;
            FillArray(out firstArrayNumbers);
            ShowArray(firstArrayNumbers);
            FillArray(out secondArrayNumbers);
            ShowArray(secondArrayNumbers);
            MergeArrays(list, firstArrayNumbers, secondArrayNumbers);
            Console.WriteLine();
            foreach (var item in list)
            {
                Console.Write(item + " | ");
            }
            Console.WriteLine();
            Console.ReadKey();
        }

        static void FillArray(out int[] array)
        {
            Random random = new Random();
            int minimalLength = 1;
            int maximalLength = 15;
            int minimalNumber = 0;
            int maximalNumber = 100;
            array = new int[random.Next(minimalLength, maximalLength)];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(minimalNumber, maximalNumber);
            }
            System.Threading.Thread.Sleep(10);
        }

        static void ShowArray(int[] array)
        {
            foreach (int number in array)
            {
                Console.Write(number + " | ");
            }
            Console.WriteLine();
        }

        static void MergeArrays(List<int> list, int[] firstArray, int[] secondArray)
        {
            List<int> nodublicate = new List<int>();
            RemovingDuclicates(list, nodublicate, firstArray);
            RemovingDuclicates(list, nodublicate, secondArray);
            nodublicate.AddRange(list.Distinct());
            list.Clear();
            list.AddRange(nodublicate);
        }

        static void RemovingDuclicates (List<int> list, List<int> nodublicate, int[] array)
        {
            nodublicate.AddRange(array.Distinct());

            foreach (int number in nodublicate)
            {
                list.Add(number);
            }
            nodublicate.Clear();
        }
    }
}
