using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Definition_of_overdue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>
            {
                new Product("Свинная", new DateTime(2020,01,25), new DateTime(2023,01,26) ),
                new Product("Говяжья", new DateTime(2019,10,1), new DateTime(2021,10,1) ),
                new Product("Свинная", new DateTime(2020,01,25), new DateTime(2023,01,26) ),
                new Product("Говяжья", new DateTime(2019,10,1), new DateTime(2021,10,1) ),
                new Product("Говяжья", new DateTime(2019,10,1), new DateTime(2021,10,1) ),
                new Product("Говяжья", new DateTime(2019,10,1), new DateTime(2021,10,1) ),
                new Product("Конина", new DateTime(2010,04,03), new DateTime(2022,07,26) ),
                new Product("Говяжья", new DateTime(2019,10,1), new DateTime(2021,10,1) ),
                new Product("Говяжья", new DateTime(2020,08,15), new DateTime(2022,08,15) ),
                new Product("Говяжья", new DateTime(2020,08,15), new DateTime(2022,08,15) ),
                new Product("Свинная", new DateTime(2020,01,25), new DateTime(2023,01,26) ),
                new Product("Свинная", new DateTime(2020,01,25), new DateTime(2023,01,26) ),
                new Product("Конина", new DateTime(2010,04,03), new DateTime(2022,07,26) ),
                new Product("Свинная", new DateTime(2020,01,25), new DateTime(2023,01,26) ),
                new Product("Свинная", new DateTime(2020,01,25), new DateTime(2023,01,26) ),
                new Product("Конина", new DateTime(2010,04,03), new DateTime(2022,07,26) ),
                new Product("Говяжья", new DateTime(2020,08,15), new DateTime(2022,08,15) ),
                new Product("Говяжья", new DateTime(2020,08,15), new DateTime(2022,08,15) ),
                new Product("Говяжья", new DateTime(2020,08,15), new DateTime(2022,06,15) ),
                new Product("Говяжья", new DateTime(2020,08,15), new DateTime(2022,06,15) ),
                new Product("Конина", new DateTime(2010,04,03), new DateTime(2022,07,26) ),
                new Product("Говяжья", new DateTime(2020,08,15), new DateTime(2022,06,15) ),
                new Product("Говяжья", new DateTime(2020,08,15), new DateTime(2022,06,15) )
            };
            Store store = new Store(products);
            store.ShowAllProducts();
            Console.WriteLine();
            store.ShowOverdue();
            Console.ReadKey(true);
        }
    }

    public class Product
    {
        public string Title { get; private set; }
        public DateTime ProductionDate { get; private set; }
        public DateTime ExpirationDate { get; private set; }

        public Product(string title, DateTime productionDate, DateTime expirationDate)
        {
            Title = title;
            ProductionDate = productionDate;
            ExpirationDate = expirationDate;
        }

        public void Show()
        {
            Console.WriteLine($"Product name - {Title} | Product year - {ProductionDate.ToShortDateString()} | Expiration date - {ExpirationDate.ToShortDateString()}");
        }
    }

    public class Store
    {
        private List<Product> _products;

        public Store(List<Product> products)
        {
            _products = products;
        }

        public void ShowAllProducts()
        {
            foreach (Product product in _products)
            {
                product.Show();
            }
        }

        public void ShowOverdue()
        {
            List<Product> overdueProducts;
            overdueProducts = _products.Where(_products => _products.ExpirationDate < DateTime.Now).ToList();

            foreach (Product product in overdueProducts)
            {
                product.Show();
            }
        }
    }
}
