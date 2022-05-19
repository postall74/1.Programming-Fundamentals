using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Working_with_classes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player("Jon", 100, 10, 25);
            player.ShowInfo();
        }
    }

    public class Player
    {
        private string _name;
        private int _health;
        private int _armor;
        private int _damage;

        public Player (string name, int health, int armaor, int damage)
        {
            _name = name;
            _health = health;
            _armor = armaor;
            _damage = damage;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Имя персонажа - {_name}\n\t-\nПоказатели:\nЖизни - {_health}\nБроня - {_armor}\nАтака - {_damage}");
        }
    }
}
