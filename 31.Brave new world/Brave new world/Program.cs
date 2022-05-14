using System;
using System.IO;
using System.Threading.Tasks;

namespace Brave_new_world
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConsoleColor defaultColor = ConsoleColor.White;
            ConsoleColor playerColor = ConsoleColor.DarkYellow;
            Console.CursorVisible = false;
            char[,] map;
            bool isPlaying = true;
            char playerSymbol = '☺';
            char wallSymbol = '#';
            char dotSymbol = '·';
            int playerPositionX;
            int playerPositionY;
            int playerDirectionX = 0;
            int playerDirectionY = 1;
            int allDots = 0;
            int collectDots = 0;
            map = ReadMap("map", playerSymbol, out playerPositionX, out playerPositionY, ref allDots, dotSymbol);
            DrawMap(map);
            while (isPlaying)
            {
                Console.SetCursorPosition(40, 0);
                Console.Write($"Счёт:{collectDots}/{allDots}");

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    ChangeDirection(key, ref playerDirectionX, ref playerDirectionY);
                }

                if (map[playerPositionX + playerDirectionX, playerPositionY + playerDirectionY] != wallSymbol)
                {
                    Move(map, playerSymbol, ref playerPositionX, ref playerPositionY, playerDirectionX, playerDirectionY, playerColor, defaultColor);
                    CollectDots(map, playerPositionX, playerPositionY, ref collectDots, dotSymbol);
                }
                isPlaying = GameWin(collectDots, allDots);
                System.Threading.Thread.Sleep(100);
            }
        }
        static bool GameWin(int collectDots, int allDots)
        {
            bool isWin;
            if (collectDots == allDots)
            {
                isWin = false;
                Console.SetCursorPosition(11, 11);
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("WIN\n\n\n\n\n\n\n\n\n\n\n\n");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                isWin = true;
            }
            return isWin;
        }
        static void CollectDots(char[,] map, int playerPositionX, int playerPositionY, ref int colectDots, char dotSymbol)
        {
            if (map[playerPositionX,playerPositionY] == dotSymbol)
            {
                colectDots++;
                map[playerPositionX,playerPositionY] = ' ';
            }
        }
        static void ChangeDirection(ConsoleKeyInfo key, ref int directionX, ref int directionY)
        {
            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    directionX = -1;
                    directionY = 0;
                    break;
                case ConsoleKey.DownArrow:
                    directionX = 1;
                    directionY = 0;
                    break;
                case ConsoleKey.LeftArrow:
                    directionX = 0;
                    directionY = -1;
                    break;
                case ConsoleKey.RightArrow:
                    directionX = 0;
                    directionY = 1;
                    break;
                default:
                    break;
            }
        }
        static void Move(char[,] map, 
                         char playerSymbol, ref int playerPositionX, ref int playerPositionY, 
                         int directionX, int directionY, 
                         ConsoleColor playerColor, ConsoleColor defaultColor)
        {
            Console.SetCursorPosition(playerPositionY, playerPositionX);
            Console.Write(map[playerPositionX, playerPositionY]);
            playerPositionX += directionX;
            playerPositionY += directionY;
            Console.ForegroundColor = playerColor;
            Console.SetCursorPosition(playerPositionY, playerPositionX);
            Console.Write(playerSymbol);
            Console.ForegroundColor = defaultColor;
        }
        static char[,] ReadMap(string mapFile,
                               char playerSymbol, out int playerPositionX, out int playerPositionY,
                               ref int allDots, char dotsSymbol)
        {
            playerPositionX = 0;
            playerPositionY = 0;
            string[] newFile = File.ReadAllLines($"{mapFile}.txt");
            char[,] map = new char[newFile.Length, newFile[0].Length];
            map = DrawSymbolCharacterAndDots(newFile, map,
                                             playerSymbol, ref playerPositionX, ref playerPositionY, 
                                             ref allDots, dotsSymbol);
            return map;
        }
        static void DrawMap(char[,] map)
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write(map[i, j]);
                }
                Console.WriteLine();
            }
        }
        static char[,] DrawSymbolCharacterAndDots(string[] newFile, char[,] map,
                                                  char playerSymbol, ref int playerPositionX, ref int playerPositionY,
                                                  ref int allDots, char dotsSymbol)
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    map[i, j] = newFile[i][j];

                    if (map[i, j] == playerSymbol)
                    {
                        playerPositionX = i;
                        playerPositionY = j;
                        map[i, j] = dotsSymbol;
                    }
                    else if (map[i, j] == ' ')
                    {
                        map[i, j] = dotsSymbol;
                        allDots++;
                    }
                }
            }
            return map;
        }
    }


}
