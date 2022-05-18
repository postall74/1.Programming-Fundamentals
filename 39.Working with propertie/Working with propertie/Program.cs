using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Working_with_propertie
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player(5, 10);
            Render render = new Render();
            render.DrawPlayer(player.X, player.Y, '*');
        }
    }

    public class Player
    {
        private int _x;
        private int _y;

        public int X { get; private set; }
        public int Y { get; private set; }

        public Player(int x, int y)
        { 
            X = x;
            Y = y;
        }
    }

    public class Render
    { 
        public void DrawPlayer (int x, int y, char playerSymbol = '@')
        {
            Console.SetCursorPosition(x, y);
            Console.Write(playerSymbol);
        }
    }
}
