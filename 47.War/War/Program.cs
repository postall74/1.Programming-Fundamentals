using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace War
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Troop firstCountry = new Troop();
            Troop secondCountry = new Troop();
            bool isExit = false;
            Troop.Show(firstCountry, secondCountry);

            while (isExit == false)
            {
                firstCountry.TakeDamage(secondCountry);
                firstCountry.Die();
                secondCountry.TakeDamage(firstCountry);
                secondCountry.Die();

                if (firstCountry.Soldiers.Count == 0 || secondCountry.Soldiers.Count == 0)
                {
                    isExit = true;
                }
            }
            Console.WriteLine("Press any key for know who win");
            Console.ReadKey(true);
            Console.Clear();

            if (firstCountry.Soldiers.Count == 0 && secondCountry.Soldiers.Count == 0)
            {
                Console.WriteLine($"Nobody wins this war");
            }
            else if (firstCountry.Soldiers.Count == 0)
            {
                Console.WriteLine($"This war was won by the second country");
                secondCountry.Show();
            }
            else if (secondCountry.Soldiers.Count == 0)
            {
                Console.WriteLine($"This war was won by the first country");
                firstCountry.Show();
            }
            Console.ReadKey(true);
        }
    }

    public class Soldier
    {
        public virtual int Health { get; private set; }
        public virtual int Damage { get; private set; }
        public virtual int Armor { get; private set; }

        public Soldier()
        {
            Random random = new Random();
            int minimunHealth = 40;
            int maximumHelath = 100;
            int minimunDamage = 11;
            int maximunDamage = 25;
            int maximunArmor = 10;
            Health = random.Next(minimunHealth, maximumHelath);
            Damage = random.Next(minimunDamage, maximunDamage);
            Armor = random.Next(maximunArmor);
        }

        public void Show()
        {
            Console.Write($"Health - {Health} | Armor - {Armor} | Damage - {Damage}");
        }

        public void TakeDamage(int damage)
        {
            Health -= damage - Armor;
        }
    }

    public class Troop
    {
        private List<Soldier> _soldiers;

        public List<Soldier> Soldiers
        {
            get
            {
                return _soldiers;
            }
            private set
            {
                _soldiers = value;
            }
        }

        public Troop()
        {
            Random random = new Random();
            int minimalCountSolders = 15;
            int maximalCountSolders = 60;
            Soldiers = new List<Soldier>();

            for (int i = 0; i < random.Next(minimalCountSolders, maximalCountSolders); i++)
            {
                Soldiers.Add(new Soldier());
                System.Threading.Thread.Sleep(3);
            }
        }

        public void Show()
        {
            foreach (Soldier soldier in Soldiers)
            {
                soldier.Show();
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public void Die()
        {
            Troop tempTroop = this;

            for (int i = 0; i < tempTroop.Soldiers.Count; i++)
            {
                if (tempTroop.Soldiers[i].Health < 1)
                {
                    this.Soldiers.Remove(tempTroop.Soldiers[i]);
                }
            }
        }

        public void TakeDamage(Troop soldiers)
        {
            Random random = new Random();
            Soldier soldierFirstCountry = this.Soldiers.Find(index => index == this.Soldiers[random.Next(this.Soldiers.Count)]);
            System.Threading.Thread.Sleep(3);
            Soldier soldierSecondCountry = soldiers.Soldiers.Find(index => index == soldiers.Soldiers[random.Next(soldiers.Soldiers.Count)]);

            if (soldierFirstCountry != null && soldierSecondCountry != null)
            {
                int damage = soldierSecondCountry.Damage;
                soldierFirstCountry.TakeDamage(damage);
            }
        }

        public static void Show(Troop firstCountry, Troop secondCountry)
        {
            Troop tempFirstCountry = new Troop();
            tempFirstCountry.Soldiers.Clear();
            Troop tempSecondCountry = new Troop();
            tempSecondCountry.Soldiers.Clear();

            foreach (Soldier soldier in firstCountry.Soldiers)
            {
                tempFirstCountry.Soldiers.Add(soldier);
            }

            foreach (Soldier soldier in secondCountry.Soldiers)
            {
                tempSecondCountry.Soldiers.Add(soldier);
            }

            bool isExit = false;
            Console.Write($"             Firs Country             ");
            Console.WriteLine($"             Second Country");

            while (isExit == false)
            {
                if (tempFirstCountry.Soldiers.Count > 0)
                {
                    Console.Write($"Health - {tempFirstCountry.Soldiers.First().Health}");
                    Console.Write($" | Armor - {tempFirstCountry.Soldiers.First().Armor}");
                    Console.Write($" | Damage - {tempFirstCountry.Soldiers.First().Damage}");
                    tempFirstCountry.Soldiers.Remove(tempFirstCountry.Soldiers.First());
                }
                else
                {
                    Console.Write($"                                     ");
                }

                if (tempSecondCountry.Soldiers.Count > 0)
                {
                    Console.Write($"   ");
                    Console.Write($"Health - {tempSecondCountry.Soldiers.First().Health}");
                    Console.Write($" | Armor - {tempSecondCountry.Soldiers.First().Armor}");
                    Console.Write($" | Damage - {tempSecondCountry.Soldiers.First().Damage}\n");
                    tempSecondCountry.Soldiers.Remove(tempSecondCountry.Soldiers.First());
                }
                else
                {
                    Console.WriteLine();
                }

                if (tempFirstCountry.Soldiers.Count == 0 && tempSecondCountry.Soldiers.Count == 0)
                {
                    isExit = true;
                }
            }
        }
    }
}