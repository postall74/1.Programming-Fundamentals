using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Work_with_strings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string yourName;
            Console.WriteLine("Как тебя зовут?");
            yourName = Console.ReadLine();
            string yourAge;
            Console.WriteLine("Сколько тебе лет?");
            yourAge = Console.ReadLine();
            string yourZodiacSign;
            Console.WriteLine("Кто ты по знаку зодиака?");
            yourZodiacSign = Console.ReadLine();
            string youProfession;
            Console.WriteLine("Кто ты по профессии?");
            youProfession = Console.ReadLine();
            Console.WriteLine("Твое имя " + yourName + ", твой возраст " + yourAge + " По гороскопу ты " + yourZodiacSign + ". Ты работаешь " + youProfession);
            Console.ReadKey();
        }
    }
}
