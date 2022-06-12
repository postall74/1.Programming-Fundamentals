using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finding_the_criminal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Criminal> criminals = new List<Criminal>
            {
                new Criminal("Martin Bormann", true, 180, 85, "Немец"),
                new Criminal("Hermann Wilhelm Göring",true,178,90,"Немец"),
                new Criminal("Rudolf Heß",false,173,70,"Египтянин"),
                new Criminal("Karl Dönitz",false,185,75,"Немец"),
                new Criminal("Ernst Friedrich Christoph «Fritz» Sauckel",true,165,60,"Немец"),
                new Criminal("Arthur Seyß-Inquart",true,170,65,"Австро-Венгр"),
                new Criminal("Alfred Jodl",true,175,70,"Немец"),
                new Criminal("Ernst Kaltenbrunner",true,180,65,"Австро-Венгр"),
                new Criminal("Wilhelm Bodewin Johann Gustav Keitel",true,173,70,"Немец"),
                new Criminal("Gustav Georg Friedrich Maria Krupp von Bohlen und Halbach",false,165,65,"Голандец"),
                new Criminal("Robert Ley",true,165,55,"Немец"),
                new Criminal("Konstantin von Neurath",false,180,85,"Немец"),
                new Criminal("Franz Joseph Hermann Michael Maria von Papen",false,184,90,"Немец"),
                new Criminal("Erich Johann Albert Raeder",false,175,80,"Немец"),
                new Criminal("Ulrich Friedrich Wilhelm Joachim von Ribbentrop",true,174,75,"Немец"),
                new Criminal("Alfred Rosenberg",true,185,75,"Русский"),
                new Criminal("Hans Michael Frank",true,182,90,"Немец"),
                new Criminal("Wilhelm Frick",true,182,90,"Немец"),
                new Criminal("Hans Fritzsche",false,172,55,"Немец"),
                new Criminal("Walther Emanuel Funk",false,161,62,"Прусс"),
                new Criminal("Hjalmar Horace Greeley Schacht",false,170,85,"Немец"),
                new Criminal("Baldur Benedikt von Schirach",false,170,85,"Немец"),
                new Criminal("Albert Speer",false,165,72,"Немец"),
                new Criminal("Julius Streicher",true,164,55,"Баварец")
            };
            Detective detective = new Detective(criminals);
            detective.FindingCriminal();
        }
    }

    public class Criminal
    {
        private string _fullName;
        private bool _isIncarcerated;
        private int _growth;
        private int _weight;
        private string _nationality;

        public string FullName { get { return _fullName; } }
        public bool IsIncarcerated { get { return _isIncarcerated; } }
        public int Growth { get { return _growth; } }
        public int Weight { get { return _weight; } }
        public string Nationality { get { return _nationality; } }

        public Criminal(string fullName, bool isIincarcerated, int growth, int weight, string nationality)
        {
            _fullName = fullName;
            _isIncarcerated = isIincarcerated;
            _growth = growth;
            _weight = weight;
            _nationality = nationality;
        }
    }

    public class Detective
    {
        private List<Criminal> _criminals;

        public Detective(List<Criminal> criminals)
        {
            _criminals = criminals;
        }

        public List<Criminal> FindingCriminal()
        {
            List<Criminal> result = new List<Criminal>();
            bool isExit = false;
            Console.Clear();

            while (isExit == false)
            {
                Console.Write($"Enter height - ");

                if (int.TryParse(Console.ReadLine(), out int growth) == true)
                {
                    result = SearchByGrowth(growth);
                    Console.Write($"Enter weight - ");

                    if (int.TryParse(Console.ReadLine(), out int weight) == true)
                    {
                        result.Union(SearchByWeight(weight));
                        Console.Write($"Enter nationality - ");
                        result.Union(SearchByNationality(Console.ReadLine()));
                        result.Distinct();

                        foreach (var item in result)
                        {
                            Console.WriteLine($"Name - {item.FullName} | Growth - {item.Growth} | Weight - {item.Weight} | Nationality - {item.Nationality}");
                        }
                        isExit = true;
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
            return result;
        }

        private List<Criminal> SearchByGrowth(int growth)
        {
            List<Criminal> result = new List<Criminal>();
            result = _criminals.Where(_criminals => _criminals.Growth == growth).Where(_criminals => _criminals.IsIncarcerated == false).ToList();
            return result;
        }

        private List<Criminal> SearchByWeight(int weight)
        {
            List<Criminal> result = new List<Criminal>();
            result = _criminals.Where(_criminals => _criminals.Weight == weight).Where(_criminals => _criminals.IsIncarcerated == false).ToList();
            return result;
        }

        private List<Criminal> SearchByNationality(string nationality)
        {
            List<Criminal> result = new List<Criminal>();
            result = _criminals.Where(_criminals => _criminals.Nationality == nationality).Where(_criminals => _criminals.IsIncarcerated == false).ToList();
            return result;
        }
    }
}
