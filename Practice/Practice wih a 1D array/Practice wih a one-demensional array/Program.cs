using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_wih_a_one_demensional_array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] tables = { 5, 6, 8, 9, 1, 5, 3, 4 };
            bool isOpen = true;

            while (isOpen)
            {
                Console.SetCursorPosition(0, 19);

                for (int i = 0; i < tables.Length; i++)
                {
                    Console.WriteLine("За стол " + (i + 1) + " свободно " + tables[i] + " мест");
                }
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("Администрирование кафе.");
                Console.WriteLine("\n\n1 - Забронировать место\n\n2 - Выход из программы");
                Console.WriteLine("\nВведите номер команды: ");

                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1:
                        int userTable;
                        int userPlace;
                        Console.WriteLine("За каким столиком вы хотети забранировать место? ");
                        userTable = Convert.ToInt32(Console.ReadLine()) - 1;

                        if (tables.Length <= userTable || userTable < 0)
                        {
                            Console.WriteLine("Такого стола нет!");
                            break;
                        }
                        Console.WriteLine("Сколько мест вы хотите забронировать за столиком " + userTable);
                        userPlace = Convert.ToInt32(Console.ReadLine());

                        if (tables[userTable] < userPlace || userPlace <= 0)
                        {
                            if (userPlace < 0)
                            {
                                Console.WriteLine("Не корректное число мест!");
                                break;
                            }
                            Console.WriteLine("Не достаточно мест");
                            break;
                        }
                        tables[userTable] -= userPlace;
                        break;
                    case 2:
                        isOpen = false;
                        Console.WriteLine("До встречи!");
                        break;
                    default:
                        Console.Clear();
                        break;
                }
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
