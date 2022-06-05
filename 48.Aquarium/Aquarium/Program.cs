using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquarium
{
    public enum FishTitle : byte
    {
        anchovy,
        barracuda,
        bream,
        burbot,
        carp,
        catfish,
        cisco,
        cod,
        dorado,
        eel,
        flounder,
        grayling,
        grouper,
        haddock,
        hake,
        halibut,
        herring,
        ide,
        mackerel,
        mullet,
        roach,
        ruffe,
        perch,
        pike,
        pikeperch,
        piranha,
        redeye,
        sardine,
        salmon,
        saury,
        shark,
        smelt,
        sprat,
        sterlet,
        sturgeon,
        tilapia,
        trout,
        tuna,
        vobla,
        whitefish
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Aquarium aquarium = new Aquarium();
            Player player = new Player();
            bool isExit = false;

            while (isExit == false)
            {
                player.TakeALookAtAquarium(aquarium);
                string userInput;
                Console.SetCursorPosition(0, 10);
                Console.WriteLine($"1.Add a fish to the aquarium\n2.Remove fish from aquarium\n3.Exit\nFor skip time press any key...");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        player.AddFishToAquarium(aquarium);
                        break;
                    case "2":
                        player.RemoveFishFromAquarium(aquarium);
                        break;
                    case "3":
                        isExit = true;
                        Console.WriteLine("Good bye!");
                        break;
                    default:
                        Console.WriteLine($"Time skipped");
                        break;
                }
            }
        }
    }

    public class Fish
    {
        private readonly Random _random = new Random();
        private readonly int _minimalAgeAtDeath = 3;
        private readonly int _maximalAgeAtDeath = 15;
        private int _ageAtDeath;

        public bool IsDie { get; private set; }
        public FishTitle Title { get; private set; }
        public int Age { get; private set; }

        public Fish()
        {
            Age = 0;
            _ageAtDeath = _random.Next(_minimalAgeAtDeath, _maximalAgeAtDeath);
            IsDie = false;
            Title = (FishTitle)Enum.GetValues(typeof(FishTitle)).GetValue(_random.Next(Enum.GetValues(typeof(FishTitle)).Length));
        }

        public Fish(FishTitle title)
        {
            Age = 0;
            _ageAtDeath = _random.Next(_minimalAgeAtDeath, _maximalAgeAtDeath);
            IsDie = false;
            Title = title;
        }

        public void Die()
        {
            if (Age >= _ageAtDeath)
            {
                IsDie = true;
            }
        }

        public void Live()
        {
            Age++;
        }

        public void Show()
        {
            Console.Write($"Fish title - {Title} | Age - {Age} | ");

            if (IsDie == false)
            {
                Console.WriteLine($"Fish status - Alive");
            }
            else
            {
                Console.WriteLine($"Fish status - Die");
            }
        }
    }

    public class Aquarium
    {
        private List<Fish> _fishs;
        private int _maximumNumberFishInAquarium;

        public Aquarium()
        {
            Random random = new Random();
            bool isExit = false;

            while (isExit == false)
            {
                Console.Clear();
                Console.Write($"How many fish can live in an aquarium? - ");

                if (int.TryParse(Console.ReadLine(), out _maximumNumberFishInAquarium) == true)
                {
                    _fishs = new List<Fish>(_maximumNumberFishInAquarium);

                    for (int i = 0; i < random.Next(_maximumNumberFishInAquarium); i++)
                    {
                        _fishs.Add(new Fish());
                        System.Threading.Thread.Sleep(3);
                    }
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
            Console.WriteLine($"Now in the aquarium lives {_fishs.Count} fish from {_maximumNumberFishInAquarium}. Below is a list of them:");

            for (int i = 0; i < _fishs.Count; i++)
            {
                Console.Write($"{i}. ");
                _fishs[i].Show();
            }
            Console.WriteLine();
        }

        public void AddFish()
        {
            Console.Clear();

            if (_fishs.Count < _maximumNumberFishInAquarium)
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
                            _fishs.Add(new Fish((FishTitle)numberTitle));
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

            if (CountFishs() == 0)
            {
                Console.WriteLine($"The aquarium is empty");
            }
            else
            {
                bool isExit = false;

                while (isExit == false)
                {
                    Console.Clear();
                    Show();
                    Console.Write($"Enter the number of the fish you want to get - ");

                    if (int.TryParse(Console.ReadLine(), out int fishNumber) == true)
                    {
                        if (fishNumber < _fishs.Count && fishNumber > 0)
                        {
                            _fishs.RemoveAt(fishNumber);
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
        }

        public void DieOrLive()
        {
            for (int i = 0; i < _fishs.Count; i++)
            {
                if (_fishs[i].IsDie == true)
                {
                    _fishs.Remove(_fishs[i]);
                }
                else
                {
                    _fishs[i].Live();
                    _fishs[i].Die();
                }
            }
        }

        public int CountFishs()
        {
            return _fishs.Count;
        }

    }

    public class Player
    {
        public Player() { }

        public void TakeALookAtAquarium(Aquarium aquarium)
        {
            Console.Clear();
            aquarium.Show();
            aquarium.DieOrLive();
        }

        public void AddFishToAquarium(Aquarium aquarium)
        {
            aquarium.AddFish();
        }

        public void RemoveFishFromAquarium(Aquarium aquarium)
        {
            aquarium.RemoveFish();
        }
    }
}
