using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Top_server_players
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Player> players = new List<Player>
            {
                new Player("Ðemidar",60,125),
                new Player("Killybear",100,110),
                new Player("Wallirik",77,95),
                new Player("Lurtéx",64,80),
                new Player("Mudspitter",69,155),
                new Player("Elunm",60,114),
                new Player("Wlxz",77,101),
                new Player("Xøt",80,110),
                new Player("Sponsoredbtw",88,117),
                new Player("Hipey",91,121),
                new Player("Nuari",98,188),
                new Player("Abdulfatah",75,55),
                new Player("Sonah",101,114),
                new Player("Avidance",112,144),
                new Player("Boomchinh",108,138),
                new Player("Artesiaa",50,65),
                new Player("Thedark",33,66),
                new Player("Bingchilling",47,50),
                new Player("Blueiron",21,56),
                new Player("Johanan",34,18),
                new Player("Elunm",43,98),
                new Player("Thelïght",66,88),
                new Player("Nefu",104,88),
                new Player("Bwc",144,205),
                new Player("Ethiq",130,201),
                new Player("Femalebrain",100,100),
                new Player("Honeychild",100,100),
                new Player("Nevercared",113,151),
                new Player("Rãz",99,154),
                new Player("Killygorbg",1,10)
            };
            Server server = new Server(players);
            Console.WriteLine($"All server players:");
            server.ShowAllPlayers();
            Console.WriteLine();
            server.ShowTopThreeLevelPlayers();
            Console.WriteLine();
            server.ShowTopThreeStrngthPlayers();
        }
    }

    public class Player
    {
        public string Login { get; private set; }
        public int Level { get; private set; }
        public int Strength { get; private set; }

        public Player(string login, int level, int strength)
        {
            Login = login;
            Level = level;
            Strength = strength;
        }

        public void Show()
        {
            Console.WriteLine($"Login - {Login}\t | Level - {Level} | Strength - {Strength}");
        }
    }

    public class Server
    {
        List<Player> _players;

        public Server(List<Player> players)
        {
            _players = players;
        }

        public void ShowAllPlayers()
        {
            foreach (Player player in _players)
            {
                player.Show();
            }
        }

        public void ShowTopThreeLevelPlayers()
        {
            List<Player> topThreePlayers;
            int countTopPlayers = 3;
            topThreePlayers = _players.OrderByDescending(_players => _players.Level).ToList();
            topThreePlayers.RemoveRange(countTopPlayers, topThreePlayers.Count - countTopPlayers);
            Console.WriteLine($"Top three players on the server with the highest level:");

            foreach (Player player in topThreePlayers)
            {
                player.Show();
            }
        }

        public void ShowTopThreeStrngthPlayers()
        {
            List<Player> topThreePlayers;
            int countTopPlayers = 3;
            topThreePlayers = _players.OrderByDescending(_players => _players.Strength).ToList();
            topThreePlayers.RemoveRange(countTopPlayers, topThreePlayers.Count - countTopPlayers);
            Console.WriteLine($"Top three players on the server with the most power:");

            foreach (Player player in topThreePlayers)
            {
                player.Show();
            }
        }
    }
}
