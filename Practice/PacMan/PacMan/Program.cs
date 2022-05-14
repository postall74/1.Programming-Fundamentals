using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PacMan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConsoleColor defaultColor = ConsoleColor.White;
            ConsoleColor playerColor = ConsoleColor.DarkYellow;
            ConsoleColor ghostColor = ConsoleColor.DarkBlue;
            Console.CursorVisible = false;
            char wallSymbols = '#';
            bool isPlaying = true;
            char[,] map;
            char pacManSymbol = '☺';
            int pacManX;
            int pacManY;
            int pacManDirectionX = 0;
            int pacManDirectionY = 1;
            bool isAlive = true;
            Random random = new Random();
            char ghostSymbol = '☻';
            int ghostX;
            int ghostY;
            int ghostDirectionX = -1;
            int ghostDirectionY = 0;
            char dotsSymbol = '·';
            int allDots = 0;
            int collectDots = 0;
            map = ReadMap("map1", pacManSymbol, ghostSymbol, out pacManX, out pacManY, out ghostX, out ghostY, ref allDots, dotsSymbol);
            DrawMap(map);
            while (isPlaying)
            {
                Console.SetCursorPosition(40, 0);
                Console.Write($"Счёт:{collectDots}/{allDots}");

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    ChangeDirection(key, ref pacManDirectionX, ref pacManDirectionY);
                }

                if (map[pacManX + pacManDirectionX, pacManY + pacManDirectionY] != wallSymbols)
                {
                    CollectDots(map, pacManX, pacManY, ref collectDots, dotsSymbol);
                    Move(map, pacManSymbol, ref pacManX, ref pacManY, pacManDirectionX, pacManDirectionY, playerColor, defaultColor);
                }

                if (map[ghostX + ghostDirectionX, ghostY + ghostDirectionY] != wallSymbols)
                {
                    Move(map, ghostSymbol, ref ghostX, ref ghostY, ghostDirectionX, ghostDirectionY, ghostColor, defaultColor);
                }
                else
                {
                    ChangeDirection(random, ref ghostDirectionX, ref ghostDirectionY);
                }
                System.Threading.Thread.Sleep(100);

                if (ghostX == pacManX && ghostY == pacManY)
                {
                    isAlive = false;
                    isPlaying = GameOver(isAlive);
                }
                else
                {
                    isPlaying = GameWin(collectDots, allDots);
                }
            }
            Console.ReadKey(true);
        }
        static void CollectDots(char[,] map, int playerPositionX, int playerPositionY, ref int collectDots, char dotSymbol)
        {
            if (map[playerPositionX, playerPositionY] == dotSymbol)
            {
                collectDots++;
                map[playerPositionX, playerPositionY] = ' ';
            }
        }
        static bool GameOver (bool isAlive)
        {
            bool isGameOver = true;

            if (!isAlive)
            {
                isGameOver = false;
                Console.SetCursorPosition(9, 11);
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("GameOver\n\n\n\n\n\n\n\n\n\n\n\n");
                Console.ForegroundColor = ConsoleColor.White;
            }

            return isGameOver;
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
        static void ChangeDirection(ConsoleKeyInfo key, ref int directionX, ref int directionY)
        {
            switch (key.Key)
            {
                case ConsoleKey.LeftArrow:
                    directionX = 0;
                    directionY = -1;
                    break;
                case ConsoleKey.UpArrow:
                    directionX = -1;
                    directionY = 0;
                    break;
                case ConsoleKey.RightArrow:
                    directionX = 0;
                    directionY = 1;
                    break;
                case ConsoleKey.DownArrow:
                    directionX = 1;
                    directionY = 0;
                    break;
                default:
                    break;
            }
        }
        static void ChangeDirection(Random random, ref int directionX, ref int directionY)
        {
            int enemyDirection = random.Next(1, 5);
            switch (enemyDirection)
            {
                case 3:
                    directionX = 0;
                    directionY = -1;
                    break;
                case 1:
                    directionX = -1;
                    directionY = 0;
                    break;
                case 4:
                    directionX = 0;
                    directionY = 1;
                    break;
                case 2:
                    directionX = 1;
                    directionY = 0;
                    break;
                default:
                    break;
            }
        }
        static void Move(char[,] map, char characterSymbol, ref int characterPositionX, ref int characterPositionY, int directionX, int directionY,
                         ConsoleColor playerColor, ConsoleColor defaultColor)
        {
            Console.SetCursorPosition(characterPositionY, characterPositionX);
            Console.Write(map[characterPositionX, characterPositionY]);
            characterPositionX += directionX;
            characterPositionY += directionY;
            Console.SetCursorPosition(characterPositionY, characterPositionX);
            Console.ForegroundColor = playerColor;
            Console.Write(characterSymbol);
            Console.ForegroundColor = defaultColor;
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
        static char[,] ReadMap(string mapName, char playerSymbol, char enemySymbol, out int playerPositionX, out int playerPositionY, out int enemyPositionX,
                               out int enemyPositionY, ref int allDots, char dotsSymbol)
        {
            playerPositionX = 0;
            playerPositionY = 0;
            enemyPositionX = 0;
            enemyPositionY = 0;
            string[] newFile = File.ReadAllLines($"Maps/{mapName}.txt");
            char[,] map = new char[newFile.Length, newFile[0].Length];
            map = DrawSymbolCharacters(newFile, map, ref playerPositionX, ref playerPositionY, ref enemyPositionX, ref enemyPositionY, ref allDots, playerSymbol,
                          enemySymbol, dotsSymbol);
            return map;
        }
        static char[,] DrawSymbolCharacters(string[] newFile, char[,] map, ref int playerPositionX, ref int playerPositionY, ref int enemyPositionX,
                                            ref int enemyPositionY, ref int allDots, char playerSymbol, char enemySymbol, char dotsSymbol)
        {
            DrawCharactersAndDots(newFile, map, playerSymbol, ref playerPositionX, ref playerPositionY,enemySymbol,ref enemyPositionX, ref enemyPositionY, dotsSymbol, ref allDots);
            return map;
        }
        static void DrawCharactersAndDots(string[] newFile, char[,] map, char playerSymbol, ref int playerPositionX, ref int playerPositionY, char enemySymbol,
                                    ref int enemyPositionX, ref int enemyPositionY,  char dotsSymbol, ref int allDots)
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
                    else if (map[i, j] == enemySymbol)
                    {
                        enemyPositionX = i;
                        enemyPositionY = j;
                        map[i, j] = dotsSymbol;
                    }
                    else if (map[i,j] == ' ')
                    {
                        map[i, j] = dotsSymbol;
                        allDots++;
                    }
                }
            }
        }

    }
}
