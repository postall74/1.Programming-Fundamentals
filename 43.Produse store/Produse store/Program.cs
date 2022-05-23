using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Produse_store
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Buyer buyer = new Buyer();
            Seller seller = new Seller
            (
                new List<Product>
                {
                    new Product("Колбаса", 400),
                    new Product("Молоко", 90),
                    new Product("Хлеб", 40),
                    new Product("Яйца", 110),
                    new Product("Мин.вода", 60)
                }
            );
            bool isExit = false;

            while (isExit == false)
            {
                Console.Clear();
                Console.WriteLine($"Shop");
                Console.SetCursorPosition(0, 6);
                Console.WriteLine($"1.Show products in shop\n2.Show the items in the customer's cart\n" +
                    $"3.Make a purchase\n4.Exit");
                string userInput;
                Console.SetCursorPosition(0, 2);
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        seller.Show();
                        break;
                    case "2":
                        buyer.Show();
                        break;
                    case "3":
                        seller.GiveProduct(buyer);
                        break;
                    case "4":
                        isExit = true;
                        Console.WriteLine($"Good bye!");
                        break;
                    default:
                        Console.WriteLine($"Retype the command");
                        break;
                }
                Console.ReadKey(true);

            }
        }
    }

    class Product
    {
        public string Name { get; private set; }
        public int Price { get; private set; }

        public Product(string name, int price)
        {
            Name = name;
            Price = price;
        }
    }

    class Seller
    {
        private List<Product> _products;
        public int Money { get; private set; }

        public Seller(List<Product> products)
        {
            Money = 0;
            _products = products;
        }

        public void Show()
        {
            Console.SetCursorPosition(0, 15);
            foreach (Product product in _products)
            {
                if (_products.Count > 0)
                {
                    Console.Write($"{product.Name}: price {product.Price}");
                }
                else
                {
                    Console.WriteLine($"Products ran out");
                }
                Console.WriteLine();
            }
        }

        public void GiveProduct(Buyer buyer)
        {
            Show();
            Console.Write($"Choose what you want to buy - ");
            string productName = Console.ReadLine();
            Product soldProduct = _products.Find(product => product.Name == productName);

            if (soldProduct.Name == productName)
            {
                if (buyer.Money >= soldProduct.Price)
                {
                    Money += buyer.TakeProduct(soldProduct);
                    _products.Remove(soldProduct);
                }
                else
                {
                    Console.WriteLine($"You don't have enough funds");
                }
            }
            else
            {
                Console.WriteLine($"There is no such product");
            }
        }
    }

    class Buyer
    {
        private List<Product> _products;
        public int Money { get; private set; }

        public Buyer()
        {
            Console.Write($"How much money do you have? - ");
            int money;
            bool isNumber = false;

            while (isNumber == false)
            {
                isNumber = int.TryParse(Console.ReadLine(), out money);

                if (isNumber == true)
                {
                    Money = money;
                    _products = new List<Product>();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine($"Please repeat");
                    Console.Write($"How much money do you have? - ");
                    isNumber = int.TryParse(Console.ReadLine(), out money);
                }
            }
        }

        public int TakeProduct(Product product)
        {
            int purchasePrice = product.Price; 
            Money -= product.Price;
            _products.Add(product);
            return purchasePrice;

        }

        public void Show()
        {
            Console.SetCursorPosition(0, 15);
            Console.WriteLine($"Аmount of money - {Money}");

            if (_products.Count > 0)
            {
                foreach (Product product in _products)
                {
                    Console.Write($"{product.Name}");
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine($"Shopping cart is empty");
            }
        }
    }
}
