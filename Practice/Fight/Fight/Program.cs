using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fight
{   
    internal class Program
    {
        static void Main(string[] args)
        {
            Fighter[] fighters = new Fighter[] { new Fighter("Jonj", 500, 50, 0), new Fighter("Mark", 250, 20, 25),
                                                 new Fighter("Alex", 150, 100, 10), new Fighter("Boris", 300, 30, 0) };

            for (int i = 0; i < fighters.Length; i++)
            {
                Console.Write($"{i} - ");
                fighters[i].ShowStats();
            }
            Console.Write("Select right gate fighter: ");
            int rightFighterIndex = Convert.ToInt32(Console.ReadLine());
            Fighter rightFighter = fighters[rightFighterIndex];
            Console.Write("Select left gate fighter: ");
            int leftFighterIndex = Convert.ToInt32(Console.ReadLine());
            Fighter leftFighter = fighters[leftFighterIndex];

            while (leftFighter.Health > 0 && rightFighter.Health > 0)
            {
                Console.WriteLine();
                leftFighter.TakeDamage(rightFighter.Damage);
                rightFighter.TakeDamage(leftFighter.Damage);
                leftFighter.ShowStats();
                rightFighter.ShowStats(); 
            }
        }
    }

    class Fighter
    {
        private int _health;
        private string _name;
        private int _damage;
        private int _armor;

        public int Health 
        { 
            get
            {
                return _health;
            } 
        }

        public Fighter(string name, int health, int damage, int armor)
        {
            _name = name;
            _health = health;
            _damage = damage;
            _armor = armor;
        }

        public void ShowStats()
        {
            Console.WriteLine($"{_name} HP - {_health} DMG - {_damage} Armor - {_armor}");
        }

        public void TakeDamage(int damage)
        {
            _health -= damage - _armor;
        }

        public int Damage 
        {
            get
            {
                return _damage;
            }
        }
    }
}
