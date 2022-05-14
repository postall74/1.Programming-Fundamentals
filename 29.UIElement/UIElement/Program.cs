using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIElement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int health;
            int mana;
            int endurance;
            bool isQuit = false;

            while (isQuit == false)
            {
                Console.Clear();
                health = 0;
                mana = 0;
                endurance = 0;
                Console.WriteLine("1.Введите количество процентов здоровья, маны и выносливости\n2.Выход");
                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1:
                        Console.SetCursorPosition(0, 0);
                        Console.Clear();
                        DrawBar(ref health, "здоровья", ConsoleColor.Red,'@');
                        DrawBar(ref mana, "маны", ConsoleColor.Blue);
                        DrawBar(ref endurance, "выносливости", ConsoleColor.Green);
                        break;
                    case 2:
                        isQuit = true;
                        Console.WriteLine("Счастлово!");
                        break;
                    default:
                        Console.WriteLine("Повторите ввод!");
                        break;
                }
                Console.ReadKey();
            }
        }

        static void DrawBar(ref int value, string message, ConsoleColor color, char symbol = '#')
        {
            ConsoleColor defaultColor = Console.ForegroundColor;
            string bar = "";
            int maxValue = 10;
            EnteringValueForDrawBar(ref value, message);
            int positionX = 0;
            EnteringCoordinatesOfDrawingLocation(ref positionX);
            int positionY = 0;
            EnteringCoordinatesOfDrawingLocation(ref positionY);
            Console.Clear();
            PercentageConversion(ref value, maxValue);

            for (int i = 0; i < value; i++)
            {
                bar += symbol;
            }
            Console.SetCursorPosition(positionY, positionX);
            Console.Write("[");
            Console.ForegroundColor = color;
            Console.Write(bar);
            Console.ForegroundColor = defaultColor;
            bar = "";

            for (int i = value; i < maxValue; i++)
            {
                bar += '_';
            }
            Console.Write(bar + ']' + "\n");
            Console.ReadKey();
        }

        static void EnteringValueForDrawBar(ref int value, string message)
        {
            Console.Write("Введите значение " + message + " в процентах: ");
            value += Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
        }

        static void EnteringCoordinatesOfDrawingLocation(ref int position)
        {
            Console.WriteLine("Введите координаты места прорисовки: ");
            position = Convert.ToInt32(Console.ReadLine());
        }

        static void PercentageConversion(ref int value, int maxValue)
        {
            int oneHundredPercent = 100;
            int maxCharsInBar = 10;
            value = maxValue - ((oneHundredPercent - value) / maxValue);

            if (value > maxCharsInBar)
            {
                value = maxCharsInBar;
            }
        }
    }
}
