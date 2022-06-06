using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquarium
{
    public enum FishTitle : byte
    {
        Anchovy,
        Barracuda,
        Bream,
        Burbot,
        Carp,
        Catfish,
        Cisco,
        Cod,
        Dorado,
        Eel,
        Flounder,
        Grayling,
        Grouper,
        Haddock,
        Hake,
        Halibut,
        Herring,
        Ide,
        Mackerel,
        Mullet,
        Roach,
        Ruffe,
        Perch,
        Pike,
        Pikeperch,
        Piranha,
        Redeye,
        Sardine,
        Salmon,
        Saury,
        Shark,
        Smelt,
        Sprat,
        Sterlet,
        Sturgeon,
        Tilapia,
        Trout,
        Tuna,
        Vobla,
        Whitefish
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Player player = new Player(new Aquarium());
            bool isExit = false;

            while (isExit == false)
            {
                player.TakeLookAquarium();
                string userInput;
                Console.WriteLine($"1.Add a fish to the aquarium\n2.Remove fish from aquarium\n3.Remove die fish\n4.Skip the time\n5.Exit");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        player.AddFishToAquarium();
                        break;
                    case "2":
                        player.RemoveFishFromAquarium();
                        break;
                    case "3":
                        player.RemoveDieFish();
                        break;
                    case "4":
                        player.SkipTime();
                        break;
                    case "5":
                        isExit = true;
                        Console.WriteLine("\nGood bye!");
                        break;
                    default:
                        Console.WriteLine("Retey");
                        break;
                }
            }
        }
    }

    public class Fish
    {
        private readonly int _ageAtDeath;

        public bool IsDie => Age >= _ageAtDeath;
        public FishTitle Title { get; private set; }
        public int Age { get; private set; }

        public Fish(FishTitle title)
        {
            Random _random = new Random();
            int _minimalAgeAtDeath = 3;
            int _maximalAgeAtDeath = 15;
            Age = 0;
            _ageAtDeath = _random.Next(_minimalAgeAtDeath, _maximalAgeAtDeath);
            Title = title;
        }

        public void Live()
        {
            if (IsDie == false)
            {
                Age++;
            }
        }

        public void Show()
        {
            Console.Write($"Fish title - {Title} | Age - {Age} | Fish status - ");

            if (IsDie == false)
            {
                Console.WriteLine($"Alive");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Die");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }

    public class Aquarium
    {
        private int _capacity;
        private List<Fish> _fishes;

        public int CountFishes
        {
            get
            {
                return _fishes.Count;
            }
        }

        public Aquarium()
        {
            Create();
        }

        private void Create()
        {
            bool isExit = false;

            while (isExit == false)
            {
                Console.Clear();
                Console.Write($"How many fish can live in an aquarium? - ");

                if (int.TryParse(Console.ReadLine(), out _capacity) == true)
                {
                    _fishes = new List<Fish>(_capacity);
                    isExit = true;
                }
                else
                {
                    Console.WriteLine($"Retry");
                    Console.ReadKey(true);
                }
            }
        }

        public void Show()
        {
            Console.WriteLine($"Now in the aquarium lives {_fishes.Count} fish from {_capacity}. Below is a list of them:");

            for (int i = 0; i < _fishes.Count; i++)
            {
                Console.Write($"{i}. ");
                _fishes[i].Show();
            }
            Console.WriteLine();
        }

        public void AddFish()
        {
            Console.Clear();

            if (_fishes.Count < _capacity)
            {
                for (int i = 0; i < Enum.GetValues(typeof(FishTitle)).Length; i++)
                {
                    Console.WriteLine($"{i}. Fish - {Enum.GetValues(typeof(FishTitle)).GetValue(i)}");
                }
                Console.WriteLine($"Select the number of fish to add to the aquarium?");
                bool isExit = false;

                while (isExit == false)
                {
                    if (int.TryParse(Console.ReadLine(), out int numberTitle) == true)
                    {
                        if (numberTitle > Enum.GetValues(typeof(FishTitle)).Length)
                        {
                            Console.WriteLine("Retry select the number");
                        }
                        else
                        {
                            _fishes.Add(new Fish((FishTitle)numberTitle));
                            isExit = true;
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine($"The number of fish in the aquarium is already at the maximum");
            }
        }

        public void RemoveFish()
        {
            Console.Clear();

            if (CountFishes > 0)
            {
                bool isExit = false;

                while (isExit == false)
                {
                    Console.Clear();
                    Show();
                    Console.Write($"Enter the number of the fish you want to get - ");

                    if (int.TryParse(Console.ReadLine(), out int fishNumber) == true)
                    {
                        if (fishNumber < _fishes.Count && fishNumber > -1)
                        {
                            _fishes.RemoveAt(fishNumber);
                            isExit = true;
                        }
                        else
                        {
                            Console.WriteLine($"Retry");
                            Console.ReadKey(true);
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Retry");
                        Console.ReadKey(true);
                    }
                }

            }
            else
            {
                Console.WriteLine($"The aquarium is empty");
                Console.ReadKey(true);
            }
        }

        public void TryToLive()
        {
            foreach (Fish fish in _fishes)
            {
                fish.Live();
            }
        }

        public void RemoveDieFish()
        {
            List<Fish> tempFishes = new List<Fish>();

            foreach (Fish fish in _fishes)
            {
                if (fish.IsDie == false)
                {
                    tempFishes.Add(fish);
                }
            }
            _fishes = tempFishes;
        }

    }

    public class Player
    {
        private Aquarium _aquarium;

        public Player(Aquarium aquarium)
        {
            _aquarium = aquarium;
        }

        public void TakeLookAquarium()
        {
            Console.Clear();
            _aquarium.Show();
        }

        public void AddFishToAquarium()
        {
            _aquarium.AddFish();
        }

        public void RemoveFishFromAquarium()
        {
            _aquarium.RemoveFish();
        }

        public void RemoveDieFish()
        {
            _aquarium.RemoveDieFish();
        }

        public void SkipTime()
        {
            _aquarium.TryToLive();
            Console.WriteLine($"Time skipped");
        }
    }
}
