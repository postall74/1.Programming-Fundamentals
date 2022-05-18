using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Creation_of_a_computer_club
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ComputerClub computerClub = new ComputerClub(8);
            computerClub.Work();
        }
    }

    class ComputerClub
    {
        private int _money = 0;
        private List<Computer> _comparers = new List<Computer>();
        private Queue<Users> _users = new Queue<Users>();

        public ComputerClub(int computerCount)
        {
            Random random = new Random();

            for (int i = 0; i < computerCount; i++)
            {
                _comparers.Add(new Computer(random.Next(5, 15)));
            }

            CreateNewUsers(25);
        }

        private void CreateNewUsers(int count)
        {
            Random random = new Random();

            for (int i = 0; i < count; i++)
            {
                _users.Enqueue(new Users(random.Next(100, 250), random));
            }
        }

        public void Work()
        {
            while (_users.Count > 0)
            {
                Console.Clear();
                Console.WriteLine($"У компьтерного клуба сейчас {_money} рублей, ждем нового клиента.");
                Users user = _users.Dequeue();
                Console.WriteLine($"В очереди молодй челок, он хочет купить {user.DesiredMinutes} минут.");
                Console.WriteLine("\nСписок компьютеров:");
                ShowAllComputers();

                Console.Write("\nВы предлагаете компьютер под номером - ");
                int computerNumber;
                bool isTheNumber = int.TryParse(Console.ReadLine(), out computerNumber);

                if (isTheNumber == true)
                {
                    if (computerNumber >= 0 && computerNumber < _comparers.Count)
                    {
                        if (_comparers[computerNumber].IsBusy)
                        {
                            Console.WriteLine("Вы предложили пользователю компьютер который уже занят! Клиент ушел.");
                        }
                        else
                        {
                            if (user.CheckSolvency(_comparers[computerNumber]) == true)
                            {
                                Console.WriteLine("Пересчитав деньги клиент оплатил время и сел за компьютер.");
                                _money += user.ToPay();
                                _comparers[computerNumber].TakeThePlace(user);
                            }
                            else
                            {
                                Console.WriteLine("У клиента не хватило денег, клиент ушёл.");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Вы саами не знаете за какой копьютер посадить клиента. Клиент ушёл.");
                    }
                }
                else
                {
                    Console.WriteLine("Выпрями руки о забор или введите номер компьютера!");
                }
                Console.WriteLine("Для того чтобы перейти к новому клинту нажмите любую клавишу.");
                Console.ReadKey();
                Console.Clear();
                SkipMinute();
            }
        }

        private void SkipMinute()
        {
            foreach (var computer in _comparers)
            {
                computer.SkipMinutes();
            }
        }

        private void ShowAllComputers()
        {
            for (int i = 0; i < _comparers.Count; i++)
            {
                Console.Write($"{i} - ");
                _comparers[i].ShowInfo();
            }
        }
    }

    class Computer
    {
        private Users _user;
        private int _minutsLeft;

        public int PriceForMinutes { get; private set; }
        public bool IsBusy
        {
            get
            {
                return _minutsLeft > 0;
            }
        }

        public Computer(int priceForMinutes)
        {
            PriceForMinutes = priceForMinutes;
        }

        public void TakeThePlace(Users user)
        {
            _user = user;
            _minutsLeft = _user.DesiredMinutes;
        }

        public void FreeThePlace()
        {
            _user = null;
        }

        public void SkipMinutes()
        {
            _minutsLeft--;
        }

        public void ShowInfo()
        {
            if (IsBusy)
            {
                Console.WriteLine($"Компьтер занят. Осталось минут {_minutsLeft}");
            }
            else
            {
                Console.WriteLine($"Компьтер свободен. Цена за 1 минуту - {PriceForMinutes}");
            }
        }
    }

    class Users
    {
        private int _money;
        private int _moneyToPlay;

        public int DesiredMinutes { get; private set; }

        public Users(int money, Random random)
        {
            _money = money;
            DesiredMinutes = random.Next(10, 30);
        }

        public bool CheckSolvency(Computer computer)
        {
            _moneyToPlay = computer.PriceForMinutes * DesiredMinutes;

            if (_money >= _moneyToPlay)
            {
                return true;
            }
            else
            {
                _moneyToPlay = 0;
                return false;
            }
        }

        public int ToPay()
        {
            _money -= _moneyToPlay;
            return _moneyToPlay;
        }
    }
}
