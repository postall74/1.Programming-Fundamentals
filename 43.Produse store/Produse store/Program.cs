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
            int moneySeller = 0;
            int moneyByer = 300;
            Buyer buyer = new Buyer(new List<Product>(), moneyByer);
            Seller seller = new Seller
            (
                new List<Product>
                {
                    new Product("Колбаса", 400),
                    new Product("Молоко", 90),
                    new Product("Хлеб", 40),
                    new Product("Яйца", 110),
                    new Product("Мин.вода", 60)
                },
                moneySeller
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

    class Seller : Human
    {
        private List<Product> _products;
        new public int Money { get; private set; }

        public Seller(List<Product> products, int money) : base(products, money)
        {
            Money = money;
            _products = products;
        }

        new public void Show()
        {
            base.Show();
        }

        new public void GiveProduct(Buyer buyer)
        {
            base.GiveProduct(buyer);
        }
    }

    class Buyer : Human
    {
        private List<Product> _products;
        new public int Money { get; private set; }

        public Buyer(List<Product> products, int money) : base(products, money)
        {
            Money = money;
            _products = products;
        }

        new public int TakeProduct(Product product)
        {
            int price = base.TakeProduct(product);
            return price;
        }

        new public void Show()
        {
            base.Show();
        }
    }

    class Human
    {
        private List<Product> _products;

        public int Money { get; private set; }

        public Human(List<Product> products, int money)
        {
            Money = money;
            _products = products;
        }

        public void Show()
        {
            Console.SetCursorPosition(0, 15);
            Console.WriteLine($"Аmount of money - {Money}\n");

            if (_products.Count > 0)
            {
                foreach (Product product in _products)
                {
                    Console.Write($"{product.Name}: price {product.Price}");
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine($"Products ran out");
            }
        }

        public int TakeProduct(Product product)
        {
            int purchasePrice = product.Price;
            Money -= product.Price;
            _products.Add(product);
            return purchasePrice;
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
}