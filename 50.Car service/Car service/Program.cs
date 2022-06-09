using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_service
{
    public enum PartNumber
    {
        Бампер,
        Проводка,
        Шланги,
        Сцепление,
        Тормоза,
        Трансмиссия,
        Зеркала,
        Окна,
        Экстерьер,
        Каркас,
        Сиденья,
        Кондиционер,
        Дворники,
        Шасси,
        Подвеска,
        Двигатель,
        Радиатор
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Warehouse warehouse = new Warehouse();
            CarService carService = new CarService(warehouse);
            int carsCount = 150;

            while (carsCount > 0)
            {
                Car car = new Car();
                Console.Clear();
                Console.WriteLine($"Number of clients in the queue - {carsCount}");
                carService.ShowAmountMoney();
                warehouse.ShowInfoDetails();
                carService.ShowRepairInvoice(car);
                carService.TakeCarForRepair(car);
                carsCount--;
            }
            Console.ReadKey(true);
        }
    }

    public class Detail
    {
        public PartNumber PartNumber { get; private set; }
        public int Price { get; private set; }
        public int Count { get; private set; }

        public Detail()
        {
            Random random = new Random();
            int minimalPrice = 1;
            int maximalPrice = 10;
            PartNumber = (PartNumber)random.Next(PartNumber.GetValues(typeof(PartNumber)).Length);
            Price = random.Next(minimalPrice, maximalPrice);
            System.Threading.Thread.Sleep(3);
        }

        public void Show()
        {
            Console.Write($"Part number - {PartNumber}\t| ");
            Console.Write($"Price - {Price}\t| ");
        }
    }

    public class Warehouse
    {
        private Dictionary<Detail, int> _details;

        public Warehouse()
        {
            _details = new Dictionary<Detail, int>();
            List<Detail> details = new List<Detail>();

            for (int i = 0; i < Enum.GetValues(typeof(PartNumber)).Length; i++)
            {
                details.Add(new Detail());
            }

            foreach (Detail detail in details)
            {
                _details.Add(detail, CreateCountDetail());
            }
        }

        public void ShowInfoDetails()
        {
            for (int i = 0; i < _details.Keys.Count; i++)
            {
                _details.Keys.ToArray()[i].Show();
                Console.WriteLine($"Count - {_details.Values.ToArray()[i]}\t");
            }
        }

        public bool FindDetail(PartNumber partNumber)
        {
            bool isFound = false;

            for (int i = 0; i < _details.Count; i++)
            {
                if (partNumber == _details.Keys.ToArray()[i].PartNumber)
                {
                    isFound = true;
                }
            }
            return isFound;
        }

        public void RemoveDetail(PartNumber partNumber)
        {
            for (int i = 0; i < _details.Count; i++)
            {
                if (_details.Keys.ToArray()[i].PartNumber == partNumber)
                {
                    _details[_details.Keys.ToArray()[i]] = _details.Values.ToArray()[i] - 1;
                }

                if (_details.Values.ToArray()[i] == 0)
                {
                    _details.Remove(_details.Keys.ToArray()[i]);
                }
            }
        }

        public int CostDetail(PartNumber partNumber)
        {
            for (int i = 0; i < _details.Count; i++)
            {
                if (partNumber == _details.Keys.ToArray()[i].PartNumber)
                {
                    int cost = _details.Values.ToArray()[i];
                    return cost;
                }
            }
            return 0;
        }

        private int CreateCountDetail()
        {
            Random random = new Random();
            int minimalCount = 3;
            int maximumCount = 8;
            int count = random.Next(minimalCount, maximumCount);
            System.Threading.Thread.Sleep(2);
            return count;
        }
    }

    public class CarService
    {
        private Warehouse _warehouse;
        private int _penalty;

        public int CostWork { get; private set; }
        public int Money { get; private set; }

        public CarService(Warehouse warehouse)
        {
            Random random = new Random();
            int minimalCostWork = 5;
            int maximalCostWork = 21;
            CostWork = random.Next(minimalCostWork, maximalCostWork);
            _penalty = CostWork;
            _warehouse = warehouse;
            Money = 200;
        }

        public void ShowAmountMoney()
        {
            Console.WriteLine($"This is now {Money} money in the cash box of a car service.\n");
        }

        public void TakeCarForRepair(Car car)
        {
            if (TryRepair(car) == false)
            {
                Money -= _penalty;
            }
        }

        public void ShowRepairInvoice(Car car)
        {
            car.Show();
            Console.WriteLine($"\nRepair will cost {RepairCost(car)}, where {_warehouse.CostDetail(car.BreakeDetail)} is the cost of the {car.BreakeDetail}" +
                $" part and {CostWork} is the cost of labor");
            Console.ReadKey(true);
        }

        private bool TryTakeMoney(Car car)
        {
            bool isPay;

            if (car.Pay(RepairCost(car)) == 0)
            {
                Console.WriteLine($"The client does not have enough money to pay for parts and labor.");
                isPay = false;
                return isPay;
            }
            else
            {
                Money += car.Pay(RepairCost(car));
                isPay = true;
                return isPay;
            }
        }

        private bool TryRepair(Car car)
        {
            bool isRepair;

            if (_warehouse.FindDetail(car.BreakeDetail) == true && TryTakeMoney(car) == true)
            {
                _warehouse.RemoveDetail(car.BreakeDetail);
                isRepair = true;
            }
            else
            {
                isRepair = true;

                if (_warehouse.FindDetail(car.BreakeDetail) == false)
                {
                    isRepair = false;
                    Console.WriteLine($"This part is not in stock, we cannot repair this car. We pay a penalty in the amount of work " +
                    $"and return the money for the spare part.");
                }
            }
            return isRepair;
        }

        private int RepairCost(Car car)
        {
            if (_warehouse.FindDetail(car.BreakeDetail) == false)
            {
                return 0;
            }
            else
            {
                int cost = _warehouse.CostDetail(car.BreakeDetail);
                cost += CostWork;
                return cost;
            }
        }
    }

    public class Car
    {
        public PartNumber BreakeDetail { get; private set; }
        public int Money { get; private set; }

        public Car()
        {
            Random random = new Random();
            int maximumMoney = 100;
            BreakeDetail = (PartNumber)random.Next(PartNumber.GetValues(typeof(PartNumber)).Length);
            Money = random.Next(maximumMoney);
        }

        public void Show()
        {
            Console.Write($"\nThis car has a broken part - {BreakeDetail}\n");
            Console.Write($"This client has {Money} money\n");
        }

        public int Pay(int repairCost)
        {
            if (Money >= repairCost)
            {
                Money -= repairCost;
                return repairCost;
            }
            else
            {
                return 0;
            }
        }
    }
}

