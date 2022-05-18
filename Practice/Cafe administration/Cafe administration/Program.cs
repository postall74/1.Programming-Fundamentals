using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe_administration
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Table[] tables = { new Table(1, 5), new Table(2, 10), new Table(3, 20), new Table(4, 2) };
            bool isOpen = true;

            while (isOpen == true)
            {
                Console.WriteLine("Администрирование кафе\n");

                for (int i = 0; i < tables.Length; i++)
                {
                    tables[i].ShowInfo();
                }
                Console.WriteLine();
                Console.Write("Введите номер стола - ");
                int userTable = Convert.ToInt32(Console.ReadLine()) - 1;
                Console.Write("Введите кол-во мест - ");
                int userPlace = Convert.ToInt32(Console.ReadLine());
                bool isReserve = tables[userTable].Reserv(userPlace);

                if (isReserve == true)
                {
                    Console.WriteLine("Бронь прошла успешно");
                }
                else
                {
                    Console.WriteLine("Ошибка при бронировании");
                }
                Console.ReadKey(true);
                Console.Clear();
            }
            
        }
    }

    class Table
    {
        private int _number;
        private int _maxPlace;
        private int _freePlace;

        public Table(int number, int maxPlace)
        {
            _number = number;
            _maxPlace = maxPlace;
            _freePlace = maxPlace;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Стол - {_number}. Свободно мест - {_freePlace}/{_maxPlace}.");
        }

        public bool Reserv(int place)
        {
            bool isReserv;
            isReserv = _freePlace >= place;

            if (isReserv == true)
            {
                _freePlace -= place;
                return isReserv;
            }
            else
            {
                return isReserv;
            }
        }
    }
}
