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
            PlayerDataBase players = new PlayerDataBase(new Player[] {new Player("Joe", 2), new Player("Ross", 3), new Player("Chandler", 4),
                                                                      new Player("Monika", 8), new Player("Fibi", 1), new Player("Raichel", 10)});
            bool isExit = false;

            while (isExit == false)
            {
                Console.Clear();
                Console.WriteLine($"Data base players");
                Console.SetCursorPosition(0, 2);
                Console.WriteLine($"1.Show all players\n2.Add player\n3.Delete player\n4.Ban/unban a player by ID\n5.Exit");
                int userInput;
                Console.SetCursorPosition(0, 11);

                if (int.TryParse(Console.ReadLine(), out userInput) == true)
                {
                    switch (userInput)
                    {
                        case 1:
                            players.ShowAll();
                            break;
                        case 2:
                            Console.Write("Enter the name player - ");
                            string name = Console.ReadLine();
                            Console.Write("Enter level player - ");
                            players.Add(name, Convert.ToInt32(Console.ReadLine()));
                            break;
                        case 3:
                            Console.Write("Enter ID player who need delete - ");
                            players.Delete(Convert.ToInt32(Console.ReadLine()));
                            break;
                        case 4:
                            Console.Write("Enter ID player who need ban/unban - ");
                            players.SetBan(Convert.ToInt32(Console.ReadLine()));
                            break;
                        case 5:
                            Console.WriteLine("Good bye!");
                            isExit = true;
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine($"Data base players");
                            Console.SetCursorPosition(0, 6);
                            Console.WriteLine($"1.Show all players\n2.Add player\n3.Delete player\n4.Ban/unban a player by ID\n5.Exit");
                            break;
                    }
                }
                Console.ReadKey(true);
            }
        }
    }

    class Player
    {
        public string Name { get; private set; }
        public int Level { get; private set; }
        public bool IsBan { get; set; }
        public int Id { get; set; }

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
            Console.WriteLine($"{Id} Player - {Name} is level {Level}. Ban status '{IsBan.ToString()}'");
        }
    }

    class PlayerDataBase
    {
        private Player[] _players;

        public PlayerDataBase(Player[] players)
        {
            _players = players;

            for (int i = 0; i < players.Length; i++)
            {
                _players[i].Id = i;
            }
        }

        public void ShowAll()
        {
            foreach (var player in _players)
            {
                player.Show();
            }
        }
        public void Add(string name, int level)
        {
            Player player = new Player(name, level);

            if (int.TryParse(Convert.ToString(level), out level) == true)
            {
                player.Id = _players.Length;
                List<Player> players = _players.ToList();
                players.Add(player);
                _players = players.ToArray();
                players = null;
            }
            else
            {
                Console.WriteLine("Try again");
            }
        }

        public void Delete(int id)
        {
            if (int.TryParse(Convert.ToString(id), out id) == true)
            {
                List<Player> players = _players.ToList();
                players.Remove(players.Find(x => x.Id == id));
                _players = players.ToArray();
                players = null;
            }
            else
            {
                Console.WriteLine($"There is no player with this {id}");
            }
        }

        public void SetBan(int id)
        {
            if (int.TryParse(Convert.ToString(id), out id) == true)
            {
                List<Player> players = _players.ToList();
                Player player = players.Find(x => x.Id == id);
                player.SetBan(id);
                _players = players.ToArray();
                players = null;
                player = null;
            }
            else
            {
                Console.WriteLine($"There is no player with this {id}");
            }
        }
    }
}
