using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passenger_train_configurator
{
    enum CarType
    {
        Плацкарт,
        Купе,
        СВ
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int minimalDirection = 1;
            int maximalDirection = 5;
            int directionsCount = random.Next(minimalDirection, maximalDirection);
            Console.SetCursorPosition(0, 2);
            bool isExit = false;
            Queue<Direction> directions = new Queue<Direction>();
            Queue<Passengers> passengers = new Queue<Passengers>();
            List<Wagon> cars = new List<Wagon>();
            Train train = new Train(passengers, directions, cars);
            isExit = false;
            string userInput;

            while (isExit == false)
            {
                if (train.Directions.Count > 0)
                {
                    train.ShowCurrentDirection();
                    train.SellTickets();
                    train.FormTrain();
                    train.Send();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine($"Create more directions for the train or leave the program?\n1.Create\n2.Exit");
                    userInput = Console.ReadLine();

                    switch (userInput.ToLower())
                    {
                        case "1":
                        case "create":
                            train.CreateDirection();
                            break;
                        case "2":
                        case "Exit":
                            isExit = true;
                            Console.WriteLine("God bye!");
                            break;
                        default:
                            Console.WriteLine($"Retype the command");
                            break;
                    }
                }
                Console.ReadKey(true);
            }
        }
    }

    class Passengers
    {
        private Random _random = new Random();
        private int _minimalPassangers = 10;
        private int _maximalPassangers = 300;
        public int Count { get; private set; }

        public Passengers()
        {
            Count = _random.Next(_minimalPassangers, _maximalPassangers);
        }

        public static void Show(Passengers passengers)
        {
            Console.Write($" The number of passengers who want to buy tickets for the flight - {passengers.Count}");
        }
    }

    class Direction
    {
        private string _departureStation;
        private string _arrivalStation;

        public string DepartureStation
        {
            get
            {
                return _departureStation;
            }
            private set
            {
                while (value == null)
                {
                    if (value == null)
                    {
                        Console.Write($"Enter the departure station - ");
                        value = Console.ReadLine();
                        _departureStation = value;
                    }
                    else
                    {
                        _departureStation = value;
                    }
                }

            }
        }
        public string ArrivalStation
        {
            get
            {
                return _arrivalStation;
            }
            private set
            {
                while (value == null)
                {
                    if (value != null)
                    {
                        _arrivalStation = value;
                    }
                    else
                    {
                        Console.Write($"Enter the station of arrival - ");
                        value = Console.ReadLine();
                        _arrivalStation = value;
                    }
                }
            }
        }

        public Direction(ref string departureStation, ref string arrivalStation)
        {
            DepartureStation = departureStation;
            ArrivalStation = arrivalStation;
        }

        public static void Show(Queue<Direction> directions)
        {
            Console.SetCursorPosition(18, 0);

            if (directions.First().DepartureStation == null && directions.First().ArrivalStation == null)
            {

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Destination list is empty");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.WriteLine($"Departure Station - {directions.First().DepartureStation} | Arrival Station - {directions.First().ArrivalStation}");
            }
        }
    }

    class Wagon
    {
        private int _capacity;
        private CarType _carType;

        public int Capacity
        {
            get
            {
                return _capacity;
            }
        }
        public CarType CarType
        {
            get
            {
                return _carType;
            }
            private set
            {
                _carType = value;

                switch (_carType)
                {
                    case CarType.СВ:
                        _capacity = 5;
                        break;
                    case CarType.Купе:
                        _capacity = 10;
                        break;
                    case CarType.Плацкарт:
                        _capacity = 30;
                        break;
                    default:
                        _capacity = 30;
                        Console.WriteLine($"The default carriage is a reserved seat");
                        break;
                }
            }
        }

        public Wagon(CarType carType = CarType.Плацкарт)
        {
            CarType = carType;
        }

        public static void Show(List<Wagon> wagons)
        {
            for (int i = 0; i < Enum.GetValues(typeof(CarType)).Length; i++)
            {
                Console.WriteLine($"{i}.Wagon type - {Enum.GetNames(typeof(CarType))[i]}. ");
            }
        }
    }

    class Train
    {
        private Queue<Passengers> _passengers;
        private Queue<Direction> _directions;
        private List<Wagon> _wagons;

        public Queue<Direction> Directions
        {
            get
            {
                return _directions;
            }
        }
        public List<Wagon> Cars
        {
            get
            {
                return _wagons;
            }
            private set
            {
                if (value == null)
                {
                    Console.WriteLine($"A train cannot be without wagons");
                }
                else
                {
                    _wagons = value;
                }
            }
        }

        public Train(Queue<Passengers> passengers, Queue<Direction> directions, List<Wagon> cars)
        {
            _passengers = passengers;
            _directions = directions;
            Cars = cars;
        }

        public Queue<Direction> CreateDirection()
        {
            Console.Clear();
            Console.SetCursorPosition(0, 2);
            string departureStation = null;
            string arrivalStation = null;
            Direction temmpDirections = new Direction(ref departureStation, ref arrivalStation);
            _directions.Enqueue(temmpDirections);
            return _directions;
        }

        public void ShowCurrentDirection()
        {
            Direction.Show(_directions);
        }

        public void ShowAllDirections()
        {
            int index = 0;
            foreach (var direction in _directions)
            {
                Console.WriteLine($"{index}.Departure Station - {direction.DepartureStation} | Arrival Station - {direction.ArrivalStation}");
                index++;
            }
        }

        public void SellTickets()
        {
            Passengers tempPassengers = new Passengers();
            Passengers.Show(tempPassengers);
            _passengers.Enqueue(tempPassengers);
        }

        public void FormTrain()
        {
            int countPassengers = _passengers.First().Count;
            int numberOfSeats = 0;

            while (numberOfSeats <= countPassengers)
            {
                Console.Clear();
                ShowCurrentDirection();
                Console.SetCursorPosition(0, 4);
                ShowAllCarTypes();
                Console.SetCursorPosition(0, 2);
                Console.Write("Add a wagon to a train - ");
                Train.ShowCyrrentPassengers(_passengers);
                Console.SetCursorPosition(0, 3);
                string userInput = Console.ReadLine();
                Console.SetCursorPosition(0, 10);

                switch (userInput)
                {
                    case "0":
                    case "Плацкарт":
                        Wagon reservedSeat = new Wagon(CarType.Плацкарт);
                        _wagons.Add(reservedSeat);
                        numberOfSeats += reservedSeat.Capacity;
                        break;
                    case "1":
                    case "Купе":
                        Wagon сoupe = new Wagon(CarType.Купе);
                        _wagons.Add(сoupe);
                        numberOfSeats += сoupe.Capacity;
                        break;
                    case "2":
                    case "СВ":
                        Wagon svCar = new Wagon(CarType.СВ);
                        _wagons.Add(svCar);
                        numberOfSeats += svCar.Capacity;
                        break;
                    default:
                        Console.WriteLine($"Retype the command");
                        break;
                }
                Console.ReadKey(true);
            }
        }

        public void Send()
        {
            Console.WriteLine();
            Direction direction = _directions.Peek();
            Passengers passengers = _passengers.Peek();
            Console.WriteLine($"Train {direction.DepartureStation}-{direction.ArrivalStation} safely departed. It has {passengers.Count} passengers. " +
                $"The train is made up of wagons");
            ShowMadeUpWagons(_wagons);
            _directions.Dequeue();
            _passengers.Dequeue();
            _wagons.Clear();
        }

        private static void ShowCyrrentPassengers(Queue<Passengers> passengers)
        {
            Passengers.Show(passengers.First());
        }

        private void ShowAllCarTypes()
        {
            Wagon.Show(_wagons);
        }

        private void ShowMadeUpWagons(List<Wagon> wagons)
        {
            foreach (var wagon in wagons)
            {
                Console.Write($"{wagon.CarType} {wagon.Capacity} seat | ");
            }
            Console.WriteLine();
        }
    }
}
