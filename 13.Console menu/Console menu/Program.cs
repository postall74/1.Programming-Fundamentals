using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_menu
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Консольное меню:");
            string username = "";
            string userPassword = "";
            string userText = "";
            string userInput = "";

            while (userInput != "exit")
            {
                Console.WriteLine("Установить имя - SetName");
                Console.WriteLine("Показать имя - WriteName");
                Console.WriteLine("Изменение пароля - ChangePassword");
                Console.WriteLine("Ввод текста - SetText");
                Console.WriteLine("Показать текст - WriteText");
                Console.WriteLine("Завершение работы - Exit");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "SetName":
                        Console.WriteLine("Введите имя: ");
                        username = Console.ReadLine();
                        break;
                    case "WriteName":

                        if (username == "")
                        {
                            Console.WriteLine("Поле имя пусто!");
                        }
                        else
                        {
                            Console.WriteLine("Имя - " + username);
                        }
                        break;
                    case "ChangePassword":
                        Console.WriteLine("Введите пароль: ");
                        userPassword = Console.ReadLine();
                        break;
                    case "SetText":
                        Console.WriteLine("Введите текст: ");
                        userText = Console.ReadLine();
                        break;
                    case "WriteText":

                        if (userText == "")
                        {
                            Console.WriteLine("Поле текста путое!");
                        }
                        else
                        {
                            Console.WriteLine("Введите пароль: ");
                            userInput = Console.ReadLine();
                            if (userInput == userPassword)
                            {
                                Console.WriteLine("Текст: \n\t" + userText);
                            }
                            else
                            {
                                Console.WriteLine("Пароль указан не верно!");
                            }
                        }
                        break;
                    case "exit":
                        break;
                    default:
                        Console.WriteLine("Команда не распознана!");
                        break;
                }
            }
            Console.WriteLine("Good bye!");
        }
    }
}
