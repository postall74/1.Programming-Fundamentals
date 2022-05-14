using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multiples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            int minNumberN = 1;
            int maxNumberN = 28;
            int counter = 0;
            int maxLengthNumber = 3;
            int numberN = rand.Next(minNumberN,maxNumberN);
            int summThreeDigitMultiples = numberN;

            Console.WriteLine(minNumberN + " < " + numberN + " < " + maxNumberN);

            while (summThreeDigitMultiples.ToString().Length <= maxLengthNumber)
            {
                summThreeDigitMultiples += numberN;

                if (summThreeDigitMultiples.ToString().Length == maxLengthNumber)
                {
                    counter++;
                }
            }
            Console.WriteLine("Количество 3-х значных натрульных "+ numberN+ " ровно "  +counter);
            Console.ReadKey();
        }
    }
}
