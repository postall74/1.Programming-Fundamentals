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
            }
        }

        public void TakeProduct(Buyer buyer)
        {
            Show();
            Console.Write($"Choose what you want to buy - ");
            string productName = Console.ReadLine();

            if (_products.Find(product => productName == product.Name).ToString() == productName)
            {
                Money += buyer.Purchase(productName);
                _products.Remove(_products.Find(product => productName == product.Name));
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
            bool isNumber = int.TryParse(Console.ReadLine(), out money);

            while (isNumber == false)
            {
                if (isNumber == true)
                {
                    Money = money;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine($"Please repeat");
                    Console.Write($"How much money do you have? - ");
                    isNumber = int.TryParse(Console.ReadLine(), out money);
                }
            }
            _products = new List<Product>();
        }

        public int Purchase(string productName)
        {
            int purchasePrice;
            List<Product> products = _products;

            return purchasePrice;
        }
    }
}
