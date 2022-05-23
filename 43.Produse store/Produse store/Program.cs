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
        public int Count { get; private set; }
        public int Price { get; private set; }

        public Product(string name, int count, int price)
        {
            Name = name;
            Count = count;
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
                if (product.Count > 0)
                {
                    Console.Write($"{product.Name}: price {product.Price}");
                }
            }
        }

        public void TakeProduct()
        {

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

        public void Purchase()
        {
            List<Product> products = _products;

        }
    }
}
