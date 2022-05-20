using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Player_database
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataBase players = new DataBase(new List<Player> {new Player("Joe", 2), new Player("Ross", 3), new Player("Chandler", 4),
                                                                      new Player("Monika", 8), new Player("Fibi", 1), new Player("Raichel", 10)});
            bool isExit = false;

            while (isExit == false)
            {
                Console.Clear();
                Console.WriteLine($"Data base players");
                Console.SetCursorPosition(0, 2);
                Console.WriteLine($"1.Show all players\n2.Add player\n3.Delete player\n4.Ban a player by ID\n5.Unban a player by ID\n6.Exit");
                string userInput;
                Console.SetCursorPosition(0, 11);
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        players.ShowAll();
                        break;
                    case "2":
                        players.AddNewPlayer();
                        break;
                    case "3":
                        players.Delete();
                        break;
                    case "4":
                        players.SetBan();
                        break;
                    case "5":
                        players.SetUnban();
                        break;
                    case "6":
                        Console.WriteLine("Good bye!");
                        isExit = true;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine($"Data base players");
                        Console.SetCursorPosition(0, 2);
                        Console.WriteLine($"1.Show all players\n2.Add player\n3.Delete player\n4.Ban/unban a player by ID\n5.Exit");
                        break;
                }
                Console.ReadKey(true);
            }
        }
    }

    class Player
    {
        public string Name { get; private set; }
        public int Level { get; private set; }
        public bool IsBan { get; private set; }
        public int Id { get; private set; }

        public Player(string name, int level)
        {
            Name = name;
            Level = level;
        }

        public void SetBan(int id)
        {
            if (int.TryParse(Convert.ToString(id), out id) == true)
            {
                if (IsBan == false)
                {
                    IsBan = true;
                    Console.WriteLine($"{Id} Player - {Name} got a ban!");
                }
                else
                {
                    IsBan = false;
                    Console.WriteLine($"{Id} Player - {Name} out of the ban!");
                }
            }
            else
            {
                Console.WriteLine("Incorrect player ID input!");
            }
        }

        public void Show()
        {
            string banStatus;
            if (IsBan == true)
            {
                banStatus = "banned";
            }
            else
            {
                banStatus = "non banned";
            }
            Console.WriteLine($"{Id} Player - {Name} is level {Level}. Ban status '{banStatus}'");
        }
    }

    class DataBase
    {
        private List<Player> _players;

        public DataBase(List<Player> players)
        {
            _players = players;
        }

        public void ShowAll()
        {
            foreach (var player in _players)
            {
                player.Show();
            }
        }
        public void AddNewPlayer()
        {
            Console.Write("Enter the name player - ");
            string name = Console.ReadLine();
            Console.Write("Enter level player - ");
            int level;

            if (int.TryParse(Console.ReadLine(), out level) == true)
            {
                Player player = new Player(name, level);
                List<Player> players = _players;
                players.Add(player);
                _players = players;
            }
            else
            {
                Console.WriteLine("Try again");
            }
        }

        public void Delete()
        {
            Console.Write("Enter ID player who need delete - ");
            int id;

            if (int.TryParse(Console.ReadLine(), out id) == true)
            {
                List<Player> players = _players;
                players.Remove(players.Find(x => x.Id == id));
                _players = players;
            }
            else
            {
                Console.WriteLine($"There is no player with this {id}");
            }
        }

        public void SetBan()
        {
            Console.Write("Enter ID player who need ban/unban - ");
            int id;

            if (int.TryParse(Console.ReadLine(), out id) == true)
            {
                List<Player> players = _players;
                Player player = players.Find(x => x.Id == id);
                if (player.IsBan == false)
                {
                    player.SetBan(id);
                }
                else
                {
                    Console.WriteLine($"This player has banned!");
                }
                _players = players;
            }
            else
            {
                Console.WriteLine($"There is no player with this {id}");
            }
        }

        public void SetUnban()
        {
            Console.Write("Enter ID player who need ban/unban - ");
            int id;

            if (int.TryParse(Console.ReadLine(), out id) == true)
            {
                List<Player> players = _players;
                Player player = players.Find(x => x.Id == id);
                if (player.IsBan == true)
                {
                    player.SetBan(id);
                }
                else
                {
                    Console.WriteLine($"This player has banned!");
                }
                _players = players;
            }
            else
            {
                Console.WriteLine($"There is no player with this {id}");
            }
        }

    }
}
