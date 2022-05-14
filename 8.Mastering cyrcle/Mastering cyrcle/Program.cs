using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class MasteringCyrecle
{
    public static void Main(string[] args)
    {
        string stringFromUser;
        Console.Write("Напиши что либо здесь: ");
        stringFromUser = Console.ReadLine();
        int countCyrcle;
        Console.Write("Сколько раз это повторить? ");
        countCyrcle = Convert.ToInt32(Console.ReadLine());

        for (int i = countCyrcle; i > 0; i--)
        {
            Console.WriteLine(stringFromUser);
        }
    }
}