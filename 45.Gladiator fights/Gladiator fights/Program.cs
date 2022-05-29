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

            while (isExit == false)
            {
                Console.Clear();
                Console.WriteLine($"1.Crete fihters\n2.Fight\n3.Exit");
                string usertInput;
                usertInput = Console.ReadLine();

                switch (usertInput)
                {
                    case "1":
                        fighters = CreateFighters();
                        break;
                    case "2":
                        Fight(fighters);
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

        public static void Fight(List<Fighter> fighters)
        {
            Fighter leftFighter = fighters[SelectFighter(fighters)];
            Fighter rightFighter = fighters[SelectFighter(fighters)];

            while (leftFighter.Health > 0 && rightFighter.Health > 0)
            {
                if (leftFighter.Health <= 0)
                {
                    Console.WriteLine($"{rightFighter.Name} is WIN");
                }
                else if (rightFighter.Health <= 0)
                {
                    Console.WriteLine($"{leftFighter.Name} is WIN");
                }
                else if(leftFighter.Health <= 0 || rightFighter.Health <= 0)
                {
                    Console.WriteLine($"Both fighters are dead");
                }
                else
                {
                    Console.WriteLine();
                    leftFighter.TakeDamage(rightFighter.Damage);
                    rightFighter.TakeDamage(leftFighter.Damage);
                    leftFighter.Show();
                    rightFighter.Show();
                }
                Console.ReadKey(true);
            }

            if (leftFighter.Health <= 0)
            {
                fighters.Remove(leftFighter);
            }

            if (rightFighter.Health <= 0)
            {
                fighters.Remove(rightFighter);
            }
        }

        public static int SelectFighter(List<Fighter> fighters)
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

        public static List<Fighter> CreateFighters()
        {
            List<Fighter> fighters = new List<Fighter>();
            string userInput;
            bool isExit = false;

            while (isExit == false)
            {
                Console.Clear();
                Console.WriteLine($"1.Barbarian\n2.Warrior\n3.Magic\n4.Monk\n5.Exit");
                userInput = Console.ReadLine();

                switch (userInput.ToLower())
                {
                    case "1":
                    case "barbarion":
                        Barbarion barbarion = CreateBarbarion();
                        fighters.Add(barbarion);
                        break;
                    case "2":
                    case "warrior":
                        Warrior warrior = CreateWarrior();
                        fighters.Add(warrior);
                        break;
                    case "3":
                    case "magic":
                        Magic magic = CreateMagic();
                        fighters.Add(magic);
                        break;
                    case "4":
                    case "monk":
                        Monk monk = CreateMonk();
                        fighters.Add(monk);
                        break;
                    case "5":
                    case "exit":
                        isExit = true;
                        break;
                    default:
                        Console.WriteLine($"Retry");
                        break;
                }
            }
            return fighters;
        }

        public static Barbarion CreateBarbarion()
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
            return _ = new Barbarion(" ", 120, 75);
        }

        public static Warrior CreateWarrior()
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
            return _ = new Warrior(" ", 100, 10, 25);
        }

        public static Magic CreateMagic()
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
            return _ = new Magic(" ", 65, 25, 100);
        }

        public static Monk CreateMonk()
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
            return _ = new Monk(" ", 65, 11, 15, 100);
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
        private int critical = 75;

        public override string Name => base.Name;
        public override float Health => base.Health;
        public override int Damage => base.Damage;

        public Barbarion(string name, float health, int damage) : base(name, health, damage)
        {
        }

        public override void TakeDamage(int damage)
        {
            if (Health <= Health / 5)
            {
                Damage = Damage + (Damage / 100 * critical);
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
            if (_attackNumber == 3)
            {
                Console.WriteLine($"Warrior {Name} blocked the attack");
                _attackNumber = 0;
            }
            else
            {
                _attackNumber++;
                Health -= (float)damage - ((float)damage / 100 * Armor);
            }
        }

        public override void Show()
        {
            Console.WriteLine($"{Name} - HP: {Health} | Dammage: {Damage} | Armor: {Armor}");
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

            if (Damage > 0)
            {
                takeDamage = Damage;
            }

            if (Mana < Damage)
            {
                Console.WriteLine($"Out of mana, can't attack");
                Damage = 0;
            }
            else
            {
                Damage = takeDamage;
                Mana -= Damage;
            }
            Health -= damage;
            Mana += 5;
        }

        public override void Show()
        {
            Console.WriteLine($"{Name} - HP: {Health} | Dammage: {Damage} | Mana {Mana}");
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
            Health -= (float)damage - ((float)damage / 100 * Armor);

            if (Mana > 5)
            {
                Health += 3;
                Mana -= 5;
            }
            Mana++;
        }
    }
}
