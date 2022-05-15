using System;
using System.Collections.Generic;

namespace HR_records_advanced
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> humanResourceRecords = new Dictionary<string, string>();
            humanResourceRecords.Add("Мельников П.С.", "Инженер поддерки продаж");
            humanResourceRecords.Add("Султанов С.А.", "Специалист тех.поддержки");
            humanResourceRecords.Add("Корнеев О.В.", "Специалист по снабжению");
            humanResourceRecords.Add("Геиль П.А.", "Главный юрист-консул");
            humanResourceRecords.Add("Жуков К.А.", "Менеджер по продажам");
            bool isExit = false;

            while (isExit == false)
            {
                Console.Clear();
                Console.WriteLine("Команды:\n\n1.Добавить досье\n2.Вывести все досье\n3.Удалить досье\n4.Поиск по фамилии\n5.Выход\n");

                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1:
                        Supplement(humanResourceRecords);
                        break;
                    case 2:
                        PrintAllDosiers(humanResourceRecords);
                        break;
                    case 3:
                        RemoveDosier(humanResourceRecords);
                        break;
                    case 4:
                        SearchFullName(humanResourceRecords);
                        break;
                    case 5:
                        Console.WriteLine("До встречи!");
                        isExit = true;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Команды:\n\n1.Добавить досье\n2.Вывести все досье\n3.Удалить досье\n4.Поиск по фамилии\n5.Выход\n");
                        break;
                }

                Console.ReadKey(true);
            }
        }

        static void Supplement(Dictionary<string, string> dictionary)
        {
            string fullName;
            string position;
            Console.Write("Введите имя сотрудника - ");
            fullName = Console.ReadLine();
            Console.Write("Введите должность сотрудника - ");
            position = Console.ReadLine();

            if (dictionary.ContainsKey(fullName) == false)
            {
                dictionary.Add(fullName, position);
            }
            else
            {
                Console.WriteLine("Сотрудник с таким именем уже есть!");
            }
        }

        static void PrintAllDosiers(Dictionary<string, string> dictionary)
        {
            foreach (var item in dictionary)
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }
        }

        static void RemoveDosier(Dictionary<string, string> dictionary)
        {
            Console.Write("Введите фамилию сотрудника которого хотите удалить - ");
            string fullName = Console.ReadLine();
            dictionary.Remove(fullName);
        }

        static void SearchFullName(Dictionary<string, string> dictionary)
        {
            Console.Write("Введите имя сотрудника для поиска - ");
            string fullName = Console.ReadLine();
            string position;

            if (dictionary.TryGetValue(fullName, out position))
            {
                Console.WriteLine($"{fullName} - {position}");
            }
            else
            {
                Console.WriteLine("Такого сотрудника нет в данном списке!");
            }
        }
    }
}
