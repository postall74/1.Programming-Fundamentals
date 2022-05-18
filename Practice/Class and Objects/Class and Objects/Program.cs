using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_and_Objects
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Renderer renderer = new Renderer();
            Player player = new Player(5, 5);
            renderer.DrawPlayer(player.X, player.Y);

            /*
            Knight knight = new Knight(100, 50);
            Barbarian barbarian = new Barbarian(100, 1, 20, 2);
            barbarian.TakeDamage(500);
            knight.TakeDamage(120);
            barbarian.ShowInfo();
            knight.ShowInfo();
            */
            /*
            User user1 = new User("Виталий");
            User user2 = new User("Алексей");
            List list = new List(new Task[] { new Task(user1, "Мытьё окон"), new Task(user2, "Почистил плиту") });
            list.ShowAllTasks();
            Console.ReadKey(true);
            */
        }
    }

    class Player
    {
        public int X { get;private set; }
        public int Y { get;private set; }

        public Player(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

    class Renderer
    {
        public void DrawPlayer(int x, int y, char ch = '@')
        {
            Console.SetCursorPosition(x, y);
            Console.Write(ch);
        }
    }


    /*
    class Warrior
    {
        protected int Health;
        protected int Armor;
        protected int Damage;

        public Warrior(int health, int armor, int damage)
        {
            Health = health;
            Armor = armor;
            Damage = damage;
        }

        public void TakeDamage(int damage)
        {
            Health -= damage - Armor;
        }

        public void ShowInfo()
        {
            Console.WriteLine(Health);
        }
    }

    class Barbarian : Warrior
    {
        public Barbarian(int health, int armor, int damage, int attackSpeed) : base(health, armor, damage * attackSpeed)
        {
        }
        public void Berserker()
        {
            Armor -= 2;
            Damage += 4;
            Health += 5;
        }
    }

    class Knight : Warrior
    {
        public Knight(int health, int damage) : base(health, 5, damage) { }

        public void Pray()
        {
            Armor += 2;
        }
    }
    */
    /*
    class Task
    {
        public User Worker;
        public string Description;

        public Task(User worker, string description)
        {
            Worker = worker;
            Description = description;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Отвественный - {Worker.Name}\nОписание задачи - {Description}");
        }
    }

    class List
    {
        public Task[] Tasks;

        public List(Task[] tasks)
        {
            Tasks = tasks;
        }

        public void ShowAllTasks()
        {
            for (int i = 0; i < Tasks.Length; i++)
            {
                Tasks[i].ShowInfo();
            }
        }
    }

    class User
    {
        public string Name;

        public User(string name)
        {
            this.Name = name;
        }
    }
    */
    /*
    class Tank
    {
        public int Health;
        public int Arrmor;
        public int Damage;
        public int Speed;

        public Tank(int health, int arrmor, int damage, int speed)
        {
            Health = health;
            Arrmor = arrmor;
            Damage = damage;
            Speed = speed;
        }

        public Tank()
        {
            Health = 100;
        }

        public void ShowStats()
        {
            Console.WriteLine($"Здровье - {Health}\nБроня - {Arrmor}\nУрон - {Damage}\nСкорость - {Speed}");
        }

        public void TakeDamage(int damage)
        {
            Health -= damage - Arrmor;
        }
    }
    */
}
