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
            Arena arena = new Arena(fighters);

            while (isExit == false)
            {
                Console.Clear();
                Console.WriteLine($"1.Crete fihter\n2.Fight\n3.Exit");
                string usertInput;
                usertInput = Console.ReadLine();

                switch (usertInput)
                {
                    case "1":
                        CreateFighters(fighters);
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

        public static void CreateFighters(List<Fighter> fighters)
        {
            Fighter fighter;
            fighter = ChooseFighter();

            switch (fighter.GetType().Name)
            {
                case nameof(Barbarion):
                    fighters.Add(Barbarion.Create());
                    break;
                case nameof(Warrior):
                    fighters.Add(Warrior.Create());
                    break;
                case nameof(Magic):
                    fighters.Add(Magic.Create());
                    break;
                case nameof(Monk):
                    fighters.Add(Monk.Create());
                    break;
                default:
                    Console.WriteLine($"Retry");
                    Console.ReadKey(true);
                    break;
            }
        }

        private static Fighter ChooseFighter()
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
                    if (indexFighter > allFighters.Count - 1)
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

    public abstract class Fighter
    {
        private string _name;
        private float _health;
        private int _damage;

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
        public virtual float Health { get { return _health; } set { _health = value; } }
        public virtual int Damage { get { return _damage; } set { _damage = value; } }

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
        private int percentCriticalDamage = 75;

        public override string Name => base.Name;
        public override float Health => base.Health;
        public override int Damage => base.Damage;

        public Barbarion(string name, float health, int damage) : base(name, health, damage)
        {
        }

        public override void TakeDamage(int damage)
        {
            int oneHundredPercent = 100;
            int minimumHealthForCriticalDamage = 20;

            if (Health <= minimumHealthForCriticalDamage)
            {
                Damage += Damage / oneHundredPercent * percentCriticalDamage;
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
            return barbarion = new Barbarion(" ", 120, 75);
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
            int oneHundredPercent = 100;

            if (_attackNumber == 3)
            {
                Console.WriteLine($"Warrior {Name} blocked the attack");
                _attackNumber = 0;
            }
            else
            {
                _attackNumber++;
                Health -= (float)damage - ((float)damage / oneHundredPercent * Armor);
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
        public override int Damage { get => base.Damage; set => base.Damage = value; }
        public override float Health { get => base.Health; set => base.Health = value; }
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
            int oneHundredPercent = 100;
            int minimalMana = 5;
            int amountOfManaPerSpell = 5;
            int amountOfHealthRestored = 3;

            Health -= (float)damage - ((float)damage / oneHundredPercent * Armor);

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
        private List<Fighter> _fighters;

        public Arena(List<Fighter> fighters)
        {
            _fighters = fighters;
        }

        public void Fight(List<Fighter> fighters)
        {
            if (fighters.Count < 2)
            {
                Console.WriteLine($"Not enough fighters");
            }
            else
            {
                Fighter leftFighter = fighters[SelectFighterForFight(fighters)];
                Fighter rightFighter = fighters[SelectFighterForFight(fighters)];

                while (leftFighter.Health > 0 && rightFighter.Health > 0)
                {
                    Console.WriteLine();
                    leftFighter.TakeDamage(rightFighter.Damage);
                    rightFighter.TakeDamage(leftFighter.Damage);
                    leftFighter.Show();
                    rightFighter.Show();
                    Console.ReadKey(true);
                }
                List<Fighter> result = new List<Fighter>
                {
                    leftFighter,
                    rightFighter
                };
                ShowWinner(fighters, leftFighter, rightFighter);
            }
        }

        private int SelectFighterForFight(List<Fighter> fighters)
        {
            int fighterIndex = 0;
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

                if (int.TryParse(Console.ReadLine(), out fighterIndex) == false)
                {
                    Console.WriteLine($"Retry");
                }
                else if (fighterIndex > fighters.Count)
                {
                    Console.WriteLine($"There is no fighter with this number, retry.");
                }
                else
                {
                    isExit = true;
                }
            }
            return fighterIndex;
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
    }
}
