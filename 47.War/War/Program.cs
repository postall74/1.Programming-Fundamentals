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
            Troop soldiersFirstCountry = new Troop();
            Troop soldiersSecondCountry = new Troop();
            Console.WriteLine($"First country");
            soldiersFirstCountry.Show();
            Console.WriteLine($"Second country");
            soldiersSecondCountry.Show();
            BattleArena battleArena = new BattleArena(soldiersFirstCountry, soldiersSecondCountry);
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

        public Troop()
        {
            Random random = new Random();
            int minimalCountSolders = 15;
            int maximalCountSolders = 60;
            List<Soldier> soldiers = new List<Soldier>();

            for (int i = 0; i < random.Next(minimalCountSolders, maximalCountSolders); i++)
            {
                soldiers.Add(new Soldier());
                System.Threading.Thread.Sleep(3);
            }

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
                    _soldiers.Remove(tempTroop._soldiers[i]);
                }
            }
        }

        public void TakeDamage(Troop EnemySoldiers)
        {
            Random random = new Random();
            Soldier soldierFirstCountry = _soldiers.Find(index => index == _soldiers[random.Next(_soldiers.Count)]);
            System.Threading.Thread.Sleep(3);
            Soldier soldierSecondCountry = EnemySoldiers._soldiers.Find(index => index == EnemySoldiers._soldiers[random.Next(EnemySoldiers._soldiers.Count)]);

            if (soldierFirstCountry != null && soldierSecondCountry != null)
            {
                int damage = soldierSecondCountry.Damage;
                soldierFirstCountry.TakeDamage(damage);
            }
        }

        public static bool EndBattle(Troop soldiersFirstCountry, Troop soldiersSecondCountry)
        {
            bool isEnd = false;

            if (soldiersFirstCountry._soldiers.Count == 0 || soldiersSecondCountry._soldiers.Count == 0)
            {
                isEnd = true;
            }
            return isEnd;
        }

        public int CountSoldiers()
        {
            int count = _soldiers.Count;
            return count;
        }
    }

    public class Battle
    {
        public Battle() { }

        public void Combat(Troop soldiersFirstCountry, Troop soldiersSecondCountry)
        {
            bool isExit = false;

            while (isExit == false)
            {
                soldiersFirstCountry.TakeDamage(soldiersSecondCountry);
                soldiersFirstCountry.Die();
                soldiersSecondCountry.TakeDamage(soldiersFirstCountry);
                soldiersSecondCountry.Die();
                isExit = Troop.EndBattle(soldiersFirstCountry, soldiersSecondCountry);
            }
        }

        public void ShowWinner(Troop soldiersFirstCountry, Troop soldiersSecondCountry)
        {
            if (soldiersFirstCountry.CountSoldiers() == 0 && soldiersSecondCountry.CountSoldiers() == 0)
            {
                Console.WriteLine($"Nobody wins this war");
            }
            else if (soldiersFirstCountry.CountSoldiers() == 0)
            {
                Console.WriteLine($"This war was won by the second country");
                Console.WriteLine($"List of soldiers who are still alive:");
                soldiersSecondCountry.Show();
            }
            else if (soldiersSecondCountry.CountSoldiers() == 0)
            {
                Console.WriteLine($"This war was won by the first country");
                Console.WriteLine($"List of soldiers who are still alive:");
                soldiersFirstCountry.Show();
            }
        }
    }

    public class BattleArena
    { 
        public BattleArena(Troop soldiersFirstCountry, Troop soldiersSecondCountry)
        {
            Battle battle = new Battle();
            battle.Combat(soldiersFirstCountry, soldiersSecondCountry);
            Console.WriteLine("Press any key for know who win");
            Console.ReadKey(true);
            Console.Clear();
            battle.ShowWinner(soldiersFirstCountry, soldiersSecondCountry);
            Console.ReadKey(true);
        }
    }
}