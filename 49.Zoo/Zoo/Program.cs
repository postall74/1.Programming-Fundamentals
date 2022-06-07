using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isExit = false;
            List<Animal> tigers = new List<Animal>
            {
                new Tiger("Sherkhan", "male"),
                new Tiger("Bagira", "female"),
                new Tiger("Lilu", "female")
            };
            List<Animal> bears = new List<Animal>
            {
                new Bear ("Balu", "male"),
                new Bear ("Milis", "female")
            };
            List<Animal> apes = new List<Animal>
            {
                new Monkey("Abu", "male"),
                new Monkey("Rafiki", "male"),
                new Monkey("ChiChiChi", "female"),
                new Monkey("Bambino", "male"),
                new Monkey("Toto", "male"),
                new Monkey("Anfisa", "female"),
                new Monkey("Jakony", "female"),
                new Monkey("May", "female")
            };
            List<Animal> wolves = new List<Animal>
            {
                new Wolf ("Akkela","male"),
                new Wolf ("Dakota","female"),
                new Wolf ("Leto","male"),
                new Wolf ("Shiru","female"),
                new Wolf ("Luve","female")
            };
            List<Aviary> aviaries = new List<Aviary>
            {
                new Aviary(tigers, "Large aviary that contains wild cats"),
                new Aviary(bears, "A very large area where bears can safely walk, separated by protective glass"),
                new Aviary(apes, "A huge cage in which a flock of chimpanzees lives"),
                new Aviary(wolves, "Large pen for wolves")
            };
            Zoo zoo = new Zoo(aviaries);
            Player player = new Player();

            while (isExit == false)
            {
                Console.Clear();
                Console.WriteLine($"1.Go see the aviaries\n2.Go away\n");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        player.TakeInfoAviary(zoo);
                        break;
                    case "2":
                        isExit = true;
                        Console.WriteLine($"Good bye!");
                        break;
                    default:
                        break;
                }
                Console.ReadKey(true);
            }
        }
    }

    public abstract class Animal
    {
        public string Name { get; private set; }
        public string Sex { get; private set; }
        public string Sound { get; private set; }

        public Animal(string name, string sex, string sound)
        {
            Name = name;
            Sex = sex;
            Sound = sound;
        }
    }

    public class Tiger : Animal
    {
        public Tiger(string name, string sex, string sound = "roar") : base(name, sex, sound)
        {
        }
    }

    public class Bear : Animal
    {
        public Bear(string name, string sex, string sound = "Arrr-rrr-rr") : base(name, sex, sound)
        {
        }
    }

    public class Monkey : Animal
    {
        public Monkey(string name, string sex, string sound = "Auauau") : base(name, sex, sound)
        {
        }
    }

    public class Wolf : Animal
    {
        public Wolf(string name, string sex, string sound = "awwwwww") : base(name, sex, sound)
        {
        }
    }

    public class Aviary
    {
        private List<Animal> _animals;

        public string Descriprion { get; private set; }

        public Aviary(List<Animal> animals, string descriprion)
        {
            Descriprion = descriprion;
            _animals = animals;
        }

        public void Show()
        {
            Console.Clear();
            Console.WriteLine($"Animals item - {_animals.First().GetType().Name}");
            Console.WriteLine($"Count animals in aviary - {_animals.Count}");
            foreach (Animal animal in _animals)
            {
                Console.WriteLine($"Name - {animal.Name} | Sex - {animal.Sex}");
            }
            Console.WriteLine($"Sound - {_animals.First().Sound}");

        }
    }

    public class Zoo
    {
        private List<Aviary> _aviaries;

        public Zoo(List<Aviary> aviaries)
        {
            _aviaries = aviaries;
        }

        public void ShowAviary()
        {
            Console.Clear();

            for (int i = 0; i < _aviaries.Count; i++)
            {
                Console.WriteLine($"{i}. Description - {_aviaries[i].Descriprion}");
            }
            Console.Write($"\nChoose the aviary you want to go to - ");
            int aviaryIndex;

            if (int.TryParse(Console.ReadLine(), out aviaryIndex) == true)
            {
                if (aviaryIndex < _aviaries.Count && aviaryIndex > -1)
                {
                    _aviaries[aviaryIndex].Show();
                }
                else
                {
                    Console.WriteLine($"Retry");
                }
            }
            else
            { 
                Console.WriteLine($"Retry"); 
            }

        }
    }

    public class Player
    {
        public Player() { }

        public void TakeInfoAviary(Zoo zoo)
        {
            zoo.ShowAviary();
        }
    }
}
