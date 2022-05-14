using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_records
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] arrayFullName = new string[] { "Мельников П.С.", "Султанов С.А.", "Корнеев О.В.", "Геиль П.А.", "Жуков К.А." };
            string[] arrayPosition = new string[] { "Инженер поддерки продаж", "Специалист тех.поддержки", "Специалист по снабжению", "Главный юрист-консул", "Менеджер по продажам" };
            bool isExit = false;

            while (isExit == false)
            {
                Console.Clear();
                Console.WriteLine("Команды:\n\n1.Добавить досье\n2.Вывести все досье\n3.Удалить досье\n4.Поиск по фамилии\n5.Выход");
                Console.WriteLine();

                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1:
                        Console.WriteLine("\n");
                        Supplement(ref arrayFullName, ref arrayPosition);
                        break;
                    case 2:
                        Console.WriteLine("\n");
                        Console.WriteLine(ShowAllDossiers(arrayFullName, arrayPosition));
                        break;
                    case 3:
                        Console.WriteLine("\n");
                        DeleteDossier(ref arrayFullName, ref arrayPosition);
                        break;
                    case 4:
                        Console.WriteLine("\n");
                        Console.WriteLine(SearchByFullName(arrayFullName, arrayPosition));
                        break;
                    case 5:
                        Console.WriteLine("\n");
                        isExit = true;
                        Console.WriteLine("До встречи!");
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Команды:\n\n1.Добавить досье\n2.Вывести все досье\n3.Удалить досье\n4.Поиск по фамилии\n5.Выход");
                        Console.WriteLine();
                        break;
                }
                Console.ReadKey();
                Console.Clear();
            }
        }
        static void Supplement(ref string[] arrayFullName, ref string[] arrayPosition)
        {
            Console.Write("Введите имя сотрудника - ");
            string fullName = Console.ReadLine();
            arrayFullName = ArrayExpension(arrayFullName, fullName);
            Console.Write("Введите должность сотрудника - ");
            string position = Console.ReadLine();
            arrayPosition = ArrayExpension(arrayPosition, position);
        }
        static string[] ArrayExpension(string[] array, string text)
        {
            string[] tempArray = new string[array.Length + 1];

            for (int i = 0; i < array.Length; i++)
            {
                tempArray[i] = array[i];
            }
            tempArray[tempArray.Length - 1] = text;
            array = tempArray;
            return array;
        }
        static string ShowAllDossiers(string[] arrayFullName, string[] arrayPosition)
        {
            string allDossiers = "";

            for (int i = 0; i < arrayFullName.Length; i++)
            {
                allDossiers += Convert.ToString(i + 1) + ". " + arrayFullName[i] + " - " + arrayPosition[i] + "\n";
            }
            return allDossiers;
        }
        static void DeleteDossier(ref string[] arrayFullName, ref string[] arrayPosition)
        {
            Console.Write("Введите номер досье которое надо удалить - ");
            int index = Convert.ToInt32(Console.ReadLine()) - 1;

            if (index < 0)
            {
                Console.WriteLine("Введите правильный номер досье");
            }
            else if (arrayFullName.Length == 0 && arrayPosition.Length == 0)
            {
                Console.WriteLine("Список досье пуст!");
            }
            else
            {
                arrayFullName = ReductionOfTheArray(arrayFullName, index);
                arrayPosition = ReductionOfTheArray(arrayPosition, index);
            }
        }
        static string[] ReductionOfTheArray(string[] array, int index)
        {
            string[] tempArray = new string[array.Length - 1];

            for (int i = 0; i < index; i++)
            {
                tempArray[i] = array[i];
            }

            for (int i = index + 1; i < array.Length; i++)
            {
                tempArray[i - 1] = array[i];
            }
            array = tempArray;
            return array;
        }
        static string SearchByFullName(string[] arrayFullName, string[] arrayPosition)
        {
            Console.Write("Введите ФИО - ");
            string serchName = Console.ReadLine();
            int index = Array.IndexOf(arrayFullName, serchName);

            if (index >= 0)
            {
                serchName = "\n" + Convert.ToString(index + 1) + ". " + arrayFullName[index] + " - " + arrayPosition[index];
            }
            else
            {
                serchName = "Запрашиваемого имени нет!";
            }
            return serchName;
        }
    }
}
