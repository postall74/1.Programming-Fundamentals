using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladiator_fights
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isExit = false;
            List<Fighter> fighters = new List<Fighter>();
            Arena arena = new Arena();

            while (isExit == false)
            {
                Console.Clear();
                Console.WriteLine($"1.Crete fihter\n2.Fight\n3.Exit");
                string usertInput;
                usertInput = Console.ReadLine();

                switch (usertInput)
                {
                    case "1":
                        fighters.Add(arena.CreateFighter());
                        break;
                    case "2":
                        arena.Fight(fighters);
                        break;
                    case "3":
                        isExit = true;
                        Console.WriteLine($"Good bye!");
                        break;
                    default:
                        Console.WriteLine($"Retype the command");
                        break;
                }
                Console.ReadKey(true);
            }
        }
    }

    public abstract class Fighter
    {
        private string _name;

        public virtual string Name
        {
            get
            {
                return _name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value) == false)
                {
                    _name = value;
                }
                else
                {
                    Console.Write("Retry - ");
                    value = Console.ReadLine();
                    _name = value;
                }
            }
        }
        public virtual float Health { get; protected set; }
        public virtual int Damage { get; protected set; }

        public Fighter(string name, float health, int damage)
        {
            Name = name;
            Health = health;
            Damage = damage;
        }

        public abstract void TakeDamage(int damage);

        public abstract void Show();
    }

    public class Barbarion : Fighter
    {
        private int _percentCriticalDamage = 75;

        public Barbarion(string name, float health, int damage) : base(name, health, damage) { }

        public override void TakeDamage(int damage)
        {
            int numberInPrecent = 100;
            int minimumHealthForCriticalDamage = 20;

            if (Health <= minimumHealthForCriticalDamage)
            {
                Damage += Damage * _percentCriticalDamage / numberInPrecent;
            }
            Health -= damage;
        }

        public override void Show()
        {
            Console.WriteLine($"{Name} - HP: {Health} | Dammage: {Damage}");
        }
    }

    public class Warrior : Fighter
    {
        private int _armor;
        private int _attackNumber = 0;

        public int Armor { get; private set; }

        public Warrior(string name, float health, int damage, int armor) : base(name, health, damage)
        {
            Armor = armor;
        }

        public override void TakeDamage(int damage)
        {
            int numberInPrecent = 100;

            if (_attackNumber == 3)
            {
                Console.WriteLine($"Warrior {Name} blocked the attack");
                _attackNumber = 0;
            }
            else
            {
                _attackNumber++;
                Health -= (float)damage - ((float)damage * Armor / numberInPrecent);
            }
        }

        public override void Show()
        {
            Console.WriteLine($"{Name} - HP: {Health} | Dammage: {Damage} | Armor: {Armor}");
        }
    }

    public class Magic : Fighter
    {
        public int Mana { get; private set; }

        public Magic(string name, float health, int damage, int mana) : base(name, health, damage)
        {
            Mana = mana;
        }

        public override void TakeDamage(int damage)
        {
            int takeDamage = Damage;
            int amountOfManaRestored = 5;
            int nullDamage = 0;

            if (Damage > nullDamage)
            {
                takeDamage = Damage;
            }

            if (Mana < Damage)
            {
                Console.WriteLine($"Out of mana, can't attack");
                Damage = nullDamage;
            }
            else
            {
                Damage = takeDamage;
                Mana -= Damage;
            }
            Health -= damage;
            Mana += amountOfManaRestored;
        }

        public override void Show()
        {
            Console.WriteLine($"{Name} - HP: {Health} | Dammage: {Damage} | Mana {Mana}");
        }
    }

    public class Monk : Fighter
    {
        public int Mana { get; private set; }
        public int Armor { get; private set; }

        public Monk(string name, float health, int damage, int armor, int mana) : base(name, health, damage)
        {
            Armor = armor;
            Mana = mana;
        }

        public override void Show()
        {
            Console.WriteLine($"{Name} - HP: {Health} | Dammage: {Damage} | Armor: {Armor} | Mana {Mana}");
        }

        public override void TakeDamage(int damage)
        {
            int numberInPrecent = 100;
            int minimalMana = 5;
            int amountOfManaPerSpell = 5;
            int amountOfHealthRestored = 3;

            Health -= (float)damage - ((float)damage * Armor / numberInPrecent);

            if (Mana > minimalMana)
            {
                Health += amountOfHealthRestored;
                Mana -= amountOfManaPerSpell;
            }
            Mana++;
        }
    }

    public class Arena
    {
        public Arena() { }

        public void Fight(List<Fighter> fighters)
        {
            if (fighters.Count < 2)
            {
                Console.WriteLine($"Not enough fighters");
            }
            else
            {
                Fighter leftFighter = SelectFighterForFight(fighters);
                fighters.Remove(leftFighter);
                Fighter rightFighter = SelectFighterForFight(fighters);
                fighters.Remove(rightFighter);

                while (leftFighter.Health > 0 && rightFighter.Health > 0)
                {
                    Console.WriteLine();
                    leftFighter.TakeDamage(rightFighter.Damage);
                    rightFighter.TakeDamage(leftFighter.Damage);
                    leftFighter.Show();
                    rightFighter.Show();
                    Console.ReadKey(true);
                }
                ShowWinner(leftFighter, rightFighter);
            }
        }

        private Fighter SelectFighterForFight(List<Fighter> fighters)
        {
            Fighter fighter = null;
            bool isExit = false;

            while (isExit == false)
            {
                Console.Clear();

                for (int i = 0; i < fighters.Count; i++)
                {
                    Console.Write($"{i}. ");
                    fighters[i].Show();
                }
                Console.Write($"Select fighter - ");

                if (int.TryParse(Console.ReadLine(), out int fighterIndex) == false)
                {
                    Console.WriteLine($"Retry");
                }
                else if (fighterIndex > fighters.Count || fighterIndex < 0)
                {
                    Console.WriteLine($"There is no fighter with this number, retry.");
                }
                else
                {
                    fighter = fighters[fighterIndex];
                    isExit = true;
                }
            }
            return fighter;
        }

        private void ShowWinner(Fighter leftFighter, Fighter rightFighter)
        {
            if (leftFighter.Health <= 0 && rightFighter.Health <= 0)
            {
                Console.WriteLine($"Both fighters are dead");
            }
            else if (leftFighter.Health <= 0)
            {
                Console.WriteLine($"{rightFighter.Name} is WIN");
            }
            else if (rightFighter.Health <= 0)
            {
                Console.WriteLine($"{leftFighter.Name} is WIN");
            }
        }

        public Fighter CreateFighter()
        {
            Fighter fighter;
            fighter = ChooseFighter();

            return fighter;
        }

        private Fighter ChooseFighter()
        {
            int indexFighter;
            bool isExit = false;
            List<Fighter> allFighters = new List<Fighter>
            {
                new Barbarion("Barbarion", 125, 15),
                new Warrior("Warrior", 100, 10, 20),
                new Magic("Magic", 75, 25, 150),
                new Monk("Monk", 100, 13, 15, 45)
            };

            while (isExit == false)
            {
                Console.Clear();

                    for (int i = 0; i < allFighters.Count; i++)
                {
                    Console.WriteLine($"{i}.{allFighters[i].GetType().Name}");
                }
                Console.Write($"Choose index fighter - ");

                if (int.TryParse(Console.ReadLine(), out indexFighter) == true)
                {
                    if (indexFighter > allFighters.Count - 1 || indexFighter < 0)
                    {
                        Console.WriteLine($"There is no such fighter");
                        Console.ReadKey(true);
                    }
                    else
                    {
                        isExit = true;
                        return allFighters[indexFighter];
                    }
                }
                else
                {
                    Console.WriteLine($"Retry");
                    Console.ReadKey(true);
                }
            }
            return null;
        }
    }
}
