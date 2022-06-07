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
            Aviary firstAviary = new Aviary(tigers, "Large aviary that contains wild cats");
            Aviary secondAviary = new Aviary(bears, "A very large area where bears can safely walk, separated by protective glass");
            Aviary thirdAviary = new Aviary(apes, "A huge cage in which a flock of chimpanzees lives");
            Aviary fourthAviary = new Aviary(wolves, "Large pen for wolves");
            Player player = new Player();

            while (isExit == false)
            {
                Console.Clear();
                Console.WriteLine($"1.Go see the first aviary\n2.Go see the second aviary\n3.Go see the third aviary\n4.Go see the fourth aviary\n5.Go away\n");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        player.TakeInfoAviary(firstAviary);
                        break;
                    case "2":
                        player.TakeInfoAviary(secondAviary);
                        break;
                    case "3":
                        player.TakeInfoAviary(thirdAviary);
                        break;
                    case "4":
                        player.TakeInfoAviary(fourthAviary);
                        break;
                    case "5":
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
            Console.WriteLine($"Description - {Descriprion}");
            Console.WriteLine($"Animals item - {_animals.First().GetType().Name}");
            Console.WriteLine($"Count animals in aviary - {_animals.Count}");
            foreach (Animal animal in _animals)
            {
                Console.WriteLine($"Name - {animal.Name} | Sex - {animal.Sex}");
            }
            Console.WriteLine($"Sound - {_animals.First().Sound}");

        }
    }

    public class Player
    {
        public Player() { }

        public void TakeInfoAviary(Aviary aviary)
        {
            aviary.Show();
        }
    }
}
