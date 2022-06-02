using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket
{
    public enum ProductName : byte
    {
        Bread,
        Milk,
        Sausage,
        Candies,
        Tea,
        Coffee,
        Cigarettes,
        Pasta,
        Potato,
        Tomato,
        cucumber,
        Mushrooms,
        Orange,
        Banana,
        Meat,
        Pizza,
        Juice,
        SourСream,
        IceСream,
        Cognac,
        Crisps
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int maximalCustomerCount;
            bool isExit = false;
            float basketPriceAmount;
            Queue<Customer> customers = new Queue<Customer> { };
            Cashbox cashbox = new Cashbox();

            while (isExit == false)
            {
                Console.Write($"How many customers are in line? - ");

                if (int.TryParse(Console.ReadLine(), out maximalCustomerCount) == true)
                {
                    for (int i = 0; i < maximalCustomerCount; i++)
                    {
                        customers.Enqueue(new Customer(new Basket()));
                    }
                    isExit = true;
                }
                else
                {
                    Console.WriteLine($"Retry");
                }
            }
            isExit = false;

            while (isExit == false)
            {
                Console.Clear();
                basketPriceAmount = cashbox.TakePurshareAmount(customers.First());
                Console.WriteLine($"The cost of all items in the basket is the same - {basketPriceAmount}");
                customers.First().Show();
                Console.ReadKey(true);

                if (customers.First().Money > basketPriceAmount)
                {
                    customers.Dequeue();
                }
                else
                {
                    while (customers.First().Money <= basketPriceAmount)
                    {
                        Console.Clear();
                        Console.WriteLine($"The buyer does not have enough funds to pay for the goods. One random item will be removed from the cart.");
                        customers.First().DeleteProductFromBasket();
                        basketPriceAmount = cashbox.TakePurshareAmount(customers.First());
                        Console.WriteLine($"The cost of all items in the basket is the same - {basketPriceAmount}");
                        customers.First().Show();
                        Console.ReadKey(true);
                    }
                    customers.Dequeue();
                }

                if (customers.Count == 0)
                {
                    isExit = true;
                    Console.WriteLine($"Good bye");
                }
            }
        }
    }

    public class Product
    {
        private ProductName _name;
        private float _price;

        public ProductName Name
        {
            get
            {
                return _name;
            }
            private set
            {
                _name = value;
            }
        }
        public float Price
        {
            get
            {
                return _price;
            }
            private set
            {
                _price = value;
            }
        }

        public Product()
        {
            Random random = new Random();
            int minimalPrice = 40;
            int maximumPrice = 1000;
            int lengthPriceName = Enum.GetValues(typeof(ProductName)).Length - 1;
            Name = (ProductName)Enum.GetValues(typeof(ProductName)).GetValue(random.Next(lengthPriceName)); ;
            Price = random.Next(minimalPrice, maximumPrice);
        }
    }

    public class Basket
    {
        private List<Product> _products;

        public List<Product> Products
        {
            get
            {
                return _products;
            }
            private set
            {
                _products = value;
            }
        }

        public Basket()
        {
            int minimalCountProductInBasket = 2;
            int maximalCountProductInBasket = 20;
            Random random = new Random();
            _products = new List<Product>();

            for (int i = 0; i < random.Next(minimalCountProductInBasket, maximalCountProductInBasket); i++)
            {
                _products.Add(new Product());
                System.Threading.Thread.Sleep(1);
            }
        }

        public virtual void Show()
        {
            foreach (var product in _products)
            {
                Console.WriteLine($"{product.Name} - {product.Price}");
            }
        }
    }

    public class Customer
    {
        private readonly Random _random = new Random();
        private readonly int _maximumAmountOfMoney = 10000;

        public float Money { get; private set; }

        public Basket Basket { get; private set; }

        public Customer(Basket basket)
        {
            Basket = basket;
            Money = _random.Next(_maximumAmountOfMoney);
        }

        public void Show()
        {
            Console.WriteLine($"Money from the buyer {Money}");
            Basket.Show();
        }

        public void DeleteProductFromBasket()
        {
            Random random = new Random();
            Basket.Products.Remove(Basket.Products[random.Next(Basket.Products.Count)]);
        }
    }

    public class Cashbox
    {
        public Customer Customer { get; private set; }

        public Cashbox() { }

        public float TakePurshareAmount(Customer customer)
        {
            float prushareAmount = 0;

            for (int i = 0; i < customer.Basket.Products.Count; i++)
            {
                prushareAmount += customer.Basket.Products[i].Price;
            }
            return prushareAmount;
        }
    }
}
