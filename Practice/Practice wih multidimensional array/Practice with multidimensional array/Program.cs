using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_with_multidimensional_array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[,] books = { 
                { "Пушкин",  "Лермонтов", "Маяковский"}, 
                { "Стивен Кинг", "Говард Лавкрафт", "Брем Стокер" }, 
                { "Перумов", "Лукяненко", "Джорж Мартин"} };
            bool isOpen = true;

            while (isOpen)
            {
                Console.WriteLine("Библиотека");
                Console.WriteLine("1 - Узнать что за книга зная её индекс\n\n2 - Найти книгу по автору\n\n3 - Вывести все книги\n\n4 - Выход\n");
                Console.Write("Введите пункт меню - ");

                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1:
                        int rows;
                        int cols;
                        Console.Write("Введите номер полки: ");
                        rows = Convert.ToInt32(Console.ReadLine()) - 1;
                        Console.Write("Введите номер : ");
                        cols = Convert.ToInt32(Console.ReadLine()) - 1;
                        Console.WriteLine("\nЭта книга - " + books[rows,cols]); 
                        break;
                    case 2:
                        string author;
                        Console.Write("Введите нужного автора - ");
                        author = Console.ReadLine();
                        bool wasFound = false;

                        for (int i = 0; i < books.GetLength(0); i++)
                        {
                            for (int j = 0; j < books.GetLength(1); j++)
                            {
                                if (author.ToLower() == books[i,j].ToLower())
                                {
                                    Console.WriteLine("Автор - " + books[i,j] + " находиться по адресу " + (i + 1) + " | " + (j + 1));
                                    wasFound = true;
                                }
                            }
                        }
                        if (wasFound == false)
                        {
                            Console.WriteLine("Такого автора нет!");
                        }
                        break;
                    case 3:
                        Console.WriteLine("\nВесь список авторов книг:\n");
                        for (int i = 0; i < books.GetLength(0); i++)
                        {
                            for (int j = 0; j < books.GetLength(1); j++)
                            {
                                Console.WriteLine(books[i, j] + "\n");
                            }
                        }
                        break;
                    case 4:
                        isOpen = false;
                        Console.WriteLine("\nДо встречи");
                        break;
                    default:
                        Console.WriteLine("Err");
                        Console.WriteLine(new Exception("Err").ToString());
                        break;
                }
                Console.WriteLine("\nНажмите любую клавишу для продолжения");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
