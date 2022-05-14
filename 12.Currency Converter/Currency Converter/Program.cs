using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currency_Converter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //USD - доллары США
            //RUB - Российские рубли
            //KZT - Казахские тенге
            float rateRubToUsd = 72.51F;
            float rateUsdToKzt = 446.49F;
            float rateRubToKzt = 6.18F;
            float rateUsdToRub = 1 / rateRubToUsd;
            float rateKztToUsd = 1 / rateUsdToKzt;
            float rateKztToRub = 1 / rateRubToKzt;
            float currencyCount;
            float balanceRub;
            float balanceKzt;
            float balanceUsd;
            string userInput = "";
            Console.WriteLine("Добро пожаловать в обменник!");
            Console.WriteLine("Сегодня у нас вы можете поменять Российские рубли, доллары США или Казахские тенге");
            Console.WriteLine("Сегодняшние курсы у нас такие:");
            Console.WriteLine("За 1 доллар США вы получите " + rateRubToUsd + " Российских рублей");
            Console.WriteLine("За 1 доллар США вы получите " + rateUsdToKzt + " Казахских тенге");
            Console.WriteLine("За 1 Российский рубль вы получите " + rateRubToKzt + " Казахских тенге\n");
            Console.Write("Введите ваш баланс в долларах США: ");
            balanceUsd = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите ваш баланс в Российских рублях: ");
            balanceRub = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите ваш баланс в Кахаских тенге: ");
            balanceKzt = Convert.ToInt32(Console.ReadLine());

            while (userInput != "exit" && userInput != "Exit")
            {
                Console.WriteLine("1 - Что бы обменять доллары США на Российские рубли\n" +
                                  "2 - Что бы обменять Российские рубли на доллары США\n" +
                                  "3 - Что бы обменять доллары США на Казахские тенге\n" +
                                  "4 - Что бы обменять Казахские тенге на доллары США\n" +
                                  "5 - Что бы обменять Российские рубли на Казахские тенге\n" +
                                  "6 - Что бы обменять Казахские тенге на Российские рубли\n" +
                                  "exit - Завершение сеанса");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        Console.WriteLine("Обмен долларов США на Российские рубли.");
                        Console.WriteLine("Колличество долларов США, которое вы хотите обменять: ");
                        currencyCount = Convert.ToSingle(Console.ReadLine());
                            
                        if (balanceUsd >= currencyCount)
                        {
                            balanceUsd -= currencyCount;
                            balanceRub += currencyCount * rateRubToUsd;
                            Console.WriteLine("Ваш баланс " + balanceRub + " Российских рублей и " + balanceUsd + " долларов США.");
                        }
                        else
                        {
                            Console.WriteLine("У вас недостаточно средств на балансе!");
                        }
                        break;
                    case "2":
                        Console.WriteLine("Обмен Российских рублий на доллары США. ");
                        Console.WriteLine("Колличество Российских рублей, которое вы хотите обменять: ");
                        currencyCount = Convert.ToSingle(Console.ReadLine());

                        if (balanceRub >= currencyCount)
                        {
                            balanceRub -= currencyCount;
                            balanceUsd += currencyCount * rateUsdToRub;
                            Console.WriteLine("Ваш баланс " + balanceUsd + " долларов США и " + balanceRub + " Российских рублей.");
                        }
                        else
                        {
                            Console.WriteLine("У вас недостаточно средств на балансе!");
                        }
                        break;
                    case "3":
                        Console.WriteLine("Обмен долларов США на Казахские тенге. ");
                        Console.WriteLine("Колличество долларов США, которое вы хотите обменять: ");
                        currencyCount = Convert.ToSingle(Console.ReadLine());

                        if (balanceUsd >= currencyCount)
                        {
                            balanceUsd -= currencyCount;
                            balanceKzt += currencyCount * rateUsdToKzt;
                            Console.WriteLine("Ваш баланс " + balanceKzt + " Казахских тенге и " + balanceUsd + " долларов США.");
                        }
                        else
                        {
                            Console.WriteLine("У вас недостаточно средств на балансе!");
                        }
                        break;
                    case "4":
                        Console.WriteLine("Обмен Казахских тенге на доллары США. ");
                        Console.WriteLine("Колличество Казахских тенге, которое вы хотите обменять: ");
                        currencyCount = Convert.ToSingle(Console.ReadLine());

                        if (balanceKzt >= currencyCount)
                        {
                            balanceKzt -= currencyCount;
                            balanceUsd += currencyCount * rateKztToUsd;
                            Console.WriteLine("Ваш баланс " + balanceUsd + " долларов США и " + balanceKzt + " Казахских тенге.");
                        }
                        else
                        {
                            Console.WriteLine("У вас недостаточно средств на балансе!");
                        }
                        break;
                    case "5":
                        Console.WriteLine("Обмен Российских рублей на Казахские тенге. ");
                        Console.WriteLine("Колличество Российских рублей, которое вы хотите обменять: ");
                        currencyCount = Convert.ToSingle(Console.ReadLine());

                        if (balanceRub >= currencyCount)
                        {
                            balanceRub -= currencyCount;
                            balanceKzt += currencyCount * rateRubToKzt;
                            Console.WriteLine("Ваш баланс " + balanceKzt + " Казахских тенге и " + balanceRub + " Российских рублей.");
                        }
                        else
                        {
                            Console.WriteLine("У вас недостаточно средств на балансе!");
                        }
                        break;
                    case "6":
                        Console.WriteLine("Обмен Казахских тенге на Российские рубли. ");
                        Console.WriteLine("Колличество Казахских тенге, которое вы хотите обменять: ");
                        currencyCount = Convert.ToSingle(Console.ReadLine());

                        if (balanceKzt >= currencyCount)
                        {
                            balanceKzt -= currencyCount;
                            balanceRub += currencyCount * rateKztToRub;
                            Console.WriteLine("Ваш баланс " + balanceRub + "Российских рублей и " + balanceKzt + " Казахских тенге.");
                        }
                        else
                        {
                            Console.WriteLine("У вас недостаточно средств на балансе!");
                        }
                        break;
                    case "exit":
                    case "Exit":
                        break; 
                    default:
                        Console.WriteLine("Команда не расспознана, повторите ввод");
                        break;
                }
                Console.WriteLine("До встречи!");
            }

        }
    }
}
