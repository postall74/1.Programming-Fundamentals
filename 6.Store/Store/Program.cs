using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int crystalPrice = 150;
            Console.WriteLine("Сколько золота у вас в кошельке?");
            int goldInWallet = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Сколько кристалов ты хочешь купить?");
            int countCrystals = Convert.ToInt32(Console.ReadLine());
            goldInWallet = goldInWallet - (crystalPrice * countCrystals);
            Console.WriteLine("Теперь у тебя в кошельке " + goldInWallet + " золота и " + countCrystals + " кристалов");
            Console.ReadKey();
        }
    }
}
