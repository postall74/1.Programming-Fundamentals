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
            render.DrawPlayer(player.X, player.Y, player.Simbol);
        }
    }

    public class Player
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public char Simbol { get; private set; }

        public Player(int x, int y, char simbol = '@')
        { 
            X = x;
            Y = y;
            Simbol = simbol;
        }
    }

    public class Render
    { 
        public void DrawPlayer (int positionX, int positionY, char symbol)
        {
            Console.SetCursorPosition(positionX, positionY);
            Console.Write(symbol);
        }
    }
}
