using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unification_of_troops
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Soldier> soldiers = new List<Soldier>
            {
                new Soldier("Иванов","Автомат АК","Солдат", 10),
                new Soldier("Сидоров","Гаубица","Лейтенант", 14),
                new Soldier("Петров","Танк","Майор", 120),
                new Soldier("Стоянов","Крейсер","Капитан-Адмирал", 18),
                new Soldier("Якубович","Штык-нож","Ефрейтор", 5),
                new Soldier("Тарасюк","РПГ","Капитан", 60),
                new Soldier("Попов","Самолёт","Подполковник", 9),
            };

            foreach (Soldier soldier in soldiers)
            {
                soldier.Show();
            }
            Console.WriteLine();
            var listSolders = soldiers.Select(soldier => new
            {
                Name = soldier.Name,
                Rank = soldier.Rank
            });

            foreach (var soldier in listSolders)
            {
                Console.WriteLine($"Name - {soldier.Name} | Rank - {soldier.Rank}");
            }
            Console.ReadKey(true);
        }
    }

    public class Soldier
    {
        public string Name { get; private set; }
        public string Armament { get; private set; }
        public string Rank { get; private set; }
        public int TimeDuty { get; private set; }

        public Soldier(string name, string armament, string rank, int timeDuty)
        {
            Name = name;
            Armament = armament;
            Rank = rank;
            TimeDuty = timeDuty;
        }

        public void Show()
        {
            Console.WriteLine($"Name - {Name} | Rank - {Rank} | Time of duty - {TimeDuty} | Armament - {Armament}");
        }
    }
}
