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
            Random random = new Random();
            int minimalCountSolders = 15;
            int maximalCountSolders = 60;
            List<Soldier> firstCountrySoldiers = new List<Soldier>();

            for (int i = 0; i < random.Next(minimalCountSolders, maximalCountSolders); i++)
            {
                firstCountrySoldiers.Add(new Soldier());
                System.Threading.Thread.Sleep(3);
            }
            Troop firstCountry = new Troop(firstCountrySoldiers);
            Console.WriteLine($"First country");
            firstCountry.Show();
            List<Soldier> secondCountrySoldiers = new List<Soldier>();

            for (int i = 0; i < random.Next(minimalCountSolders, maximalCountSolders); i++)
            {
                secondCountrySoldiers.Add(new Soldier());
                System.Threading.Thread.Sleep(3);
            }
            Troop secondCountry = new Troop(secondCountrySoldiers);
            Console.WriteLine($"Second country");
            secondCountry.Show();
            Battle battle = new Battle();
            battle.Combat(firstCountry, secondCountry);
            Console.WriteLine("Press any key for know who win");
            Console.ReadKey(true);
            Console.Clear();
            battle.ShowWinner(firstCountry, secondCountry);
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

        public Troop(List<Soldier> soldiers)
        {
            _soldiers = soldiers;
        }

        public void Show()
        {
            foreach (Soldier soldier in _soldiers)
            {
                soldier.Show();
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public void Die()
        {
            Troop tempTroop = this;

            for (int i = 0; i < tempTroop._soldiers.Count; i++)
            {
                if (tempTroop._soldiers[i].Health < 1)
                {
                    this._soldiers.Remove(tempTroop._soldiers[i]);
                }
            }
        }

        public void TakeDamage(Troop EnemySoldiers)
        {
            Random random = new Random();
            Soldier soldierFirstCountry = this._soldiers.Find(index => index == this._soldiers[random.Next(this._soldiers.Count)]);
            System.Threading.Thread.Sleep(3);
            Soldier soldierSecondCountry = EnemySoldiers._soldiers.Find(index => index == EnemySoldiers._soldiers[random.Next(EnemySoldiers._soldiers.Count)]);

            if (soldierFirstCountry != null && soldierSecondCountry != null)
            {
                int damage = soldierSecondCountry.Damage;
                soldierFirstCountry.TakeDamage(damage);
            }
        }

        public static bool EndBattle(Troop firstCountry, Troop secondCountry)
        {
            bool isEnd = false;

            if (firstCountry._soldiers.Count == 0 || secondCountry._soldiers.Count == 0)
            {
                isEnd = true;
            }
            return isEnd;
        }

        public int CountSoldiers()
        {
            int count = this._soldiers.Count;
            return count;
        }
    }

    public class Battle
    {
        public Battle() { }

        public void Combat(Troop firstCountry, Troop secondCountry)
        {
            bool isExit = false;

            while (isExit == false)
            {
                firstCountry.TakeDamage(secondCountry);
                firstCountry.Die();
                secondCountry.TakeDamage(firstCountry);
                secondCountry.Die();
                isExit = Troop.EndBattle(firstCountry, secondCountry);
            }
        }

        public void ShowWinner(Troop firstCountry, Troop secondCountry)
        {
            if (firstCountry.CountSoldiers() == 0 && secondCountry.CountSoldiers() == 0)
            {
                Console.WriteLine($"Nobody wins this war");
            }
            else if (firstCountry.CountSoldiers() == 0)
            {
                Console.WriteLine($"This war was won by the second country");
                Console.WriteLine($"List of soldiers who are still alive:");
                secondCountry.Show();
            }
            else if (secondCountry.CountSoldiers() == 0)
            {
                Console.WriteLine($"This war was won by the first country");
                Console.WriteLine($"List of soldiers who are still alive:");
                firstCountry.Show();
            }
        }
    }
}