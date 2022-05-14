using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swapping_values
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = "Петров";
            string surname = "Иван";
            Console.WriteLine(name + " " + surname);
            string additionalVariable = name;
            name = surname;
            surname = additionalVariable;
            Console.WriteLine(name + " " + surname);
            Console.ReadKey();
        }
    }
}
