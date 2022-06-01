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

        public override string Name => base.Name;
        public override float Health => base.Health;
        public override int Damage => base.Damage;

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

        public static Barbarion Create()
        {
            Barbarion barbarion;
            string name;
            bool isExit = false;

            while (isExit == false)
            {
                Console.Clear();
                Console.WriteLine($"Enter stats for Barbarion");
                Console.Write($"Enter name - ");
                name = Console.ReadLine();

                if (string.IsNullOrEmpty(name) == false)
                {
                    Console.Write($"Enter health level for {name} - ");

                    if (int.TryParse(Console.ReadLine(), out int health) == true)
                    {
                        Console.Write($"Enter damage level for {name} - ");

                        if (int.TryParse(Console.ReadLine(), out int damage) == true)
                        {
                            barbarion = new Barbarion(name, health, damage);
                            isExit = true;
                            return barbarion;
                        }
                        else
                        {
                            Console.WriteLine($"Retry");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Retry");
                    }
                }
                else
                {
                    Console.WriteLine($"Retry");
                }
            }
            return null;
        }
    }

    public class Warrior : Fighter
    {
        private int _armor;
        private int _attackNumber = 0;

        public override string Name => base.Name;
        public override float Health => base.Health;
        public override int Damage => base.Damage;
        public int Armor { get { return _armor; } private set { _armor = value; } }

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

        public static Warrior Create()
        {
            Warrior warrior;
            string name;
            bool isExit = false;

            while (isExit == false)
            {
                Console.Clear();
                Console.WriteLine($"Enter stats for Warrior");
                Console.Write($"Enter name - ");
                name = Console.ReadLine();

                if (string.IsNullOrEmpty(name) == false)
                {
                    Console.Write($"Enter health level for {name} - ");

                    if (int.TryParse(Console.ReadLine(), out int health) == true)
                    {
                        Console.Write($"Enter damage level for {name} - ");

                        if (int.TryParse(Console.ReadLine(), out int damage) == true)
                        {
                            Console.Write($"Enter armor level for {name} - ");

                            if (int.TryParse(Console.ReadLine(), out int arrmor) == true)
                            {
                                warrior = new Warrior(name, health, damage, arrmor);
                                isExit = true;
                                return warrior;
                            }
                            else
                            {
                                Console.WriteLine($"Retry");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Retry");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Retry");
                    }
                }
                else
                {
                    Console.WriteLine($"Retry");
                }
            }
            return warrior = new Warrior(" ", 100, 10, 25);
        }
    }

    public class Magic : Fighter
    {
        private int _mana;

        public override string Name => base.Name;
        public override float Health => base.Health;
        public override int Damage => base.Damage;
        public int Mana { get { return _mana; } private set { _mana = value; } }

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

        public static Magic Create()
        {
            Magic magic;
            string name;
            bool isExit = false;

            while (isExit == false)
            {
                Console.Clear();
                Console.WriteLine($"Enter stats for Magic");
                Console.Write($"Enter name - ");
                name = Console.ReadLine();

                if (string.IsNullOrEmpty(name) == false)
                {
                    Console.Write($"Enter health level for {name} - ");

                    if (int.TryParse(Console.ReadLine(), out int health) == true)
                    {
                        Console.Write($"Enter damage level for {name} - ");

                        if (int.TryParse(Console.ReadLine(), out int damage) == true)
                        {
                            Console.Write($"Enterl mana level for {name} - ");

                            if (int.TryParse(Console.ReadLine(), out int mana))
                            {
                                magic = new Magic(name, health, damage, mana);
                                isExit = true;
                                return magic;
                            }
                            else
                            {
                                Console.WriteLine($"Retry");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Retry");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Retry");
                    }
                }
                else
                {
                    Console.WriteLine($"Retry");
                }
            }
            return magic = new Magic(" ", 65, 25, 100);
        }
    }

    public class Monk : Fighter
    {
        private int _mana;
        private int _armor;

        public override string Name => base.Name;
        public override int Damage => base.Damage;
        public override float Health => base.Health;
        public int Mana { get { return _mana; } private set { _mana = value; } }
        public int Armor { get { return _armor; } private set { _armor = value; } }

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

        public static Monk Create()
        {
            Monk monk;
            string name;
            bool isExit = false;

            while (isExit == false)
            {
                Console.Clear();
                Console.WriteLine($"Enter stats for Monk");
                Console.Write($"Enter name - ");
                name = Console.ReadLine();

                if (string.IsNullOrEmpty(name) == false)
                {
                    Console.Write($"Enter health level for {name} - ");

                    if (int.TryParse(Console.ReadLine(), out int health) == true)
                    {
                        Console.Write($"Enter damage level for {name} - ");

                        if (int.TryParse(Console.ReadLine(), out int damage) == true)
                        {
                            Console.Write($"Enterl armor level for {name} - ");

                            if (int.TryParse(Console.ReadLine(), out int armor) == true)
                            {
                                Console.Write($"Enterl mana level for {name} - ");

                                if (int.TryParse(Console.ReadLine(), out int mana))
                                {
                                    monk = new Monk(name, health, damage, armor, mana);
                                    isExit = true;
                                    return monk;
                                }
                                else
                                {
                                    Console.WriteLine($"Retey");
                                }
                            }
                            else
                            {
                                Console.WriteLine($"Retry");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Retry");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Retry");
                    }
                }
                else
                {
                    Console.WriteLine($"Retry");
                }
            }
            return monk = new Monk(" ", 65, 11, 15, 100);
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
                fighters.Add(leftFighter);

                while (leftFighter.Health > 0 && rightFighter.Health > 0)
                {
                    Console.WriteLine();
                    leftFighter.TakeDamage(rightFighter.Damage);
                    rightFighter.TakeDamage(leftFighter.Damage);
                    leftFighter.Show();
                    rightFighter.Show();
                    Console.ReadKey(true);
                }
                ShowWinner(fighters, leftFighter, rightFighter);
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
                else if (fighterIndex > fighters.Count)
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

        private void ShowWinner(List<Fighter> fighters, Fighter leftFighter, Fighter rightFighter)
        {
            if (leftFighter.Health <= 0 && rightFighter.Health <= 0)
            {
                Console.WriteLine($"Both fighters are dead");
                fighters.Remove(leftFighter);
                fighters.Remove(rightFighter);
            }
            else if (leftFighter.Health <= 0)
            {
                Console.WriteLine($"{rightFighter.Name} is WIN");
                fighters.Remove(leftFighter);
            }
            else if (rightFighter.Health <= 0)
            {
                Console.WriteLine($"{leftFighter.Name} is WIN");
                fighters.Remove(rightFighter);
            }
        }

        public Fighter CreateFighter()
        {
            Fighter fighter;
            fighter = ChooseFighter();

            switch (fighter.GetType().Name)
            {
                case nameof(Barbarion):
                    Barbarion barbarion = Barbarion.Create();
                    fighter = barbarion;
                    break;
                case nameof(Warrior):
                    Warrior warrior = Warrior.Create();
                    fighter = warrior;
                    break;
                case nameof(Magic):
                    Magic magic = Magic.Create();
                    fighter = magic;
                    break;
                case nameof(Monk):
                    Monk monk = Monk.Create();
                    fighter = monk;
                    break;
                default:
                    Console.WriteLine($"Retry");
                    Console.ReadKey(true);
                    break;
            }
            return fighter;
        }

        private Fighter ChooseFighter()
        {
            int indexFighter;
            bool isExit = false;
            List<Fighter> allFighters = new List<Fighter>
            {
                new Barbarion("1", 125, 15),
                new Warrior("2", 100, 10, 20),
                new Magic("3", 75, 25, 150),
                new Monk("4", 100, 13, 15, 45)
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
