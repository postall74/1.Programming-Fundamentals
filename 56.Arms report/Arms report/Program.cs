using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arms_report
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Soldier> soldiersPlatoonA = new List<Soldier>
            {
                new Soldier("Иванов","Рядовой"),
                new Soldier("Баранкин","Ефрейтор"),
                new Soldier("Бубнов","Рядовой"),
                new Soldier("Борисов","Рядовой"),
                new Soldier("Ванбков","Рядовой"),
                new Soldier("Шу","Рядовой"),
                new Soldier("Синяков","Рядовой"),
                new Soldier("Цветков","Рядовой"),
                new Soldier("Камнев","Рядовой"),
                new Soldier("Бесараб","Рядовой"),
                new Soldier("Блиновский","Ефрейтор"),
                new Soldier("Костылев","Рядовой"),
                new Soldier("Дудкин","Рядовой"),
                new Soldier("Чесноков","Рядовой"),
                new Soldier("Бузина","Сержант")
            };
            List<Soldier> soldiersPlatoonB = new List<Soldier>
            {
                new Soldier("Беркут","Сержант"),
                new Soldier("Дубинин","Ефрейтор"),
                new Soldier("Кипелов","Сержант"),
                new Soldier("Маргулис","Рядовой"),
                new Soldier("Шпротов","Рядовой"),
                new Soldier("Ясенев","Рядовой"),
                new Soldier("Волков","Рядовой"),
                new Soldier("Трахимчик","Рядовой"),
                new Soldier("Гумеров","Рядовой"),
                new Soldier("Болоболов","Рядовой"),
                new Soldier("Исаков","Рядовой"),
                new Soldier("Куликов","Рядовой"),
                new Soldier("Денисов","Рядовой"),
                new Soldier("Васин","Рядовой"),
                new Soldier("Строев","Лейтенант")
            };
            Platoon platoonA = new Platoon(soldiersPlatoonA);
            Platoon platoonB = new Platoon(soldiersPlatoonB);
            Console.WriteLine("Platoon A");
            platoonA.Show();
            Console.WriteLine("Platoon B");
            platoonB.Show();
            Console.WriteLine("Transfer soldiers from platoonA to platoonB");
            platoonB.TakeSoldiers(platoonA.GiveSoldiers());
            Console.WriteLine("Platoon A");
            platoonA.Show();
            Console.WriteLine("Platoon B");
            platoonB.Show();
            Console.ReadKey(true);
        }
    }

    public class Soldier
    {
        public string Surname { get; private set; }
        public string Rank { get; private set; }

        public Soldier(string surname, string rank)
        {
            Surname = surname;
            Rank = rank;
        }

        public void Show()
        {
            Console.WriteLine($"Full Name - {Surname} | Rank - {Rank}");
        }
    }

    public class Platoon
    {
        private List<Soldier> _soldiers;

        public Platoon(List<Soldier> soldiers)
        {
            _soldiers = soldiers;
        }

        public void Show()
        {
            foreach (Soldier soldier in _soldiers)
            {
                soldier.Show();
            }
        }

        public List<Soldier> GiveSoldiers()
        {
            List<Soldier> transferredSoldiers = _soldiers.Where(_soldiers => _soldiers.Surname.ToUpper().StartsWith("Б")).ToList();
            _soldiers = _soldiers.Except(transferredSoldiers).ToList();
            return transferredSoldiers;
        }

        public void TakeSoldiers(List<Soldier> soldiers)
        {
            _soldiers = _soldiers.Union(soldiers).ToList();
        }
    }
}
