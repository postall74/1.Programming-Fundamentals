using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Split
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = "Ночь, улица, фонарь, аптека, Бессмысленный и тусклый свет. Живи еще хоть четверть века - Все будет так. Исхода нет. Умрешь - начнешь опять сначала И повторится все, как встарь: Ночь, ледяная рябь канала, Аптека, улица, фонарь";
            string[] arrayText = text.Split(' ');

            foreach (var subString in arrayText)
            {
                Console.WriteLine(subString);
            }
            Console.ReadKey();
        }
    }
}
