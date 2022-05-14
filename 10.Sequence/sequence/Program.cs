using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sequence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //выбран цикл for т.к. в задании дана верхняя нраница счетчика
            int minValue = 5;
            int maxValue = 96;
            int step = 7;

            for (int i = minValue; i <= maxValue; i+=step)
            {
                    Console.WriteLine(i);   
            }
        }
    }
}
