using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladiator_fight
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            float helth1 = rand.Next(90, 100);
            int damage1 = rand.Next(5, 20);
            int arrmor1 = rand.Next(25, 65);
            int damage2 = rand.Next(5, 50);
            float helth2 = rand.Next(80, 150);
            int arrmor2 = rand.Next(65, 100);
            float damageTaken1;
            float damageTaken2;
            Console.WriteLine("Показатели Гладиатора 1: \n" +
                              "Здоровье - " + helth1 + "\n" + 
                              "Броня - " + arrmor1 + "\n" + 
                              "Максимальная атака - " + damage1 + "\n");
            Console.WriteLine("Показатели Гладиатора 2: \n" +
                              "Здоровье - " + helth2 + "\n" +
                              "Броня - " + arrmor2 + "\n" +
                              "Максимальная атака - " + damage2 + "\n");
            Console.WriteLine("Нажмите Enter для начала боя!");
            Console.ReadKey();

            while (helth1 > 0 && helth2 > 0)
            {
                damageTaken1 = Convert.ToSingle(rand.Next(0, damage2)) / 100 * rand.Next(0, arrmor1);
                damageTaken2 = Convert.ToSingle(rand.Next(0, damage1)) / 100 * rand.Next(0, arrmor2);
                helth1 -= damageTaken1;  
                helth2 -= damageTaken2;
                Console.WriteLine("Гладиатор 1 наносит урона |" + damageTaken2);
                Console.WriteLine("Гладиатор 2 наносит урона |" + damageTaken1);
                Console.WriteLine("Гладиатор 1 |" + helth1);
                Console.WriteLine("Гладиатор 2 |" + helth2);
            }

            if (helth1 <= 0 && helth2 <= 0)
            {
                Console.WriteLine("Ничья! Оба мертвы");
            }
            else if (helth1 <= 0)
            {
                Console.WriteLine("Гладиатор 1 пал!");
            }
            else if (helth2 <= 0)
            {
                Console.WriteLine("Гладитор 2 пал!");
            }
            Console.ReadKey();
        }
    }
}
