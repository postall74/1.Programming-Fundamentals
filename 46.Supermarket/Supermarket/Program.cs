using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class Product
    {
        private string _name;
        private float _price;

        public string Name
        {
            get
            {
                return _name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value) == false)
                {
                    Console.WriteLine($"The product must have a title.");
                }
                else
                {
                    _name = value;
                }
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
                if (float.TryParse(Convert.ToString(value), out _price) == false)
                {
                    Console.WriteLine($"The price must be a number");
                }
                else
                {
                    _price = value;
                }
            }
        }
    }
}
