using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_storage
{
    enum Genre
    {
        None,
        Detective,
        ScienceFiction,
        Fantasy,
        Adventures,
        Novel,
        Scientific,
        Folklore,
        Humor,
        Documental
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Storage storage = new Storage
            (
                new List<Book>
                {
                    new Book("Гроздья гнева", "Джон Стейнбек", "1939", Genre.Novel),
                    new Book("Мор, ученик Смерти", "Терри Пратчетт", "1987",Genre.Fantasy),
                    new Book("Алмазный Меч, Деревянный Меч. Том 1","Ник Перумов","1998",Genre.Fantasy),
                    new Book("Алмазный Меч, Деревянный Меч. Том 2","Ник Перумов","1998",Genre.Fantasy),
                    new Book("Одноэтажная Америка","Илья Ильф и Евгений Петров","1936",Genre.Documental),
                    new Book("Череп на рукове","Ник Перумов","2002",Genre.ScienceFiction),
                    new Book("Череп в небесах","Ник Перумов","2004",Genre.ScienceFiction)
                }
            );
            bool isExit = false;

            while(isExit == false)
            {
                Console.Clear();
                Console.WriteLine("Books storage");
                Console.SetCursorPosition(0, 6);
                Console.WriteLine($"1.Show all catalog\n2.Add new book in storage\n3.Delete book from storage\n4.Find books by author\n5.Find books by title" +
                    $"\n6.Find books by publication year\n7.Find books by genre\n8.Exit");
                string userInput;
                Console.SetCursorPosition(0, 2);
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        storage.Show();
                        break;
                    case "2":
                        storage.Add();
                        break;
                    case "3":
                        storage.Delete();
                        break;
                    case "4":
                        storage.SearchByAuthor();
                        break;
                    case "5":
                        storage.SearchByTitle();
                        break;
                    case "6":
                        storage.SearchByPublicationYear();
                        break;
                    case "7":
                        storage.SearchByGenre();
                        break;
                    case "8":
                        isExit = true;
                        Console.WriteLine($"Good bye!");
                        break;
                    default:
                        Console.WriteLine($"Retype the command");
                        break;
                }
                Console.ReadKey(true);
            }
        }
    }

    class Book
    {
        public string Title { get; private set; }
        public string Author { get; private set; }
        public string PublicationYear { get; private set; }
        public Genre Genre { get; private set; }

        public Book(string bookTitle, string author, string publicationYear, Genre genre)
        {
            Title = bookTitle;
            Author = author;
            PublicationYear = publicationYear;
            Genre = genre;
        }
    }

    class Storage
    {
        private List<Book> _books;

        public Storage(List<Book> books)
        {
            _books = books;
        }

        public void Add()
        {
            string title;
            string author;
            string publicationYear;
            Genre genre;
            int numberGenre;
            Console.SetCursorPosition(0, 15);
            Console.Write($"Enter Author Name - ");
            author = Console.ReadLine();
            Console.Write($"Enter book title - ");
            title = Console.ReadLine();
            Console.Write($"Enter the year the book was published - ");
            publicationYear = Console.ReadLine();
            Console.WriteLine($"List of genres:");
            ShowAllGenre();
            Console.Write($"Choose the number genre of the book - ");

            if (int.TryParse(Console.ReadLine(),out numberGenre) == true)
            {
                if (numberGenre > Enum.GetValues(typeof(Genre)).Length)
                {
                    genre = Genre.None;
                    Console.WriteLine($"There is no such genre.");
                }
                else
                {
                    genre = (Genre)numberGenre;
                }
            }
            else
            {
                genre = Genre.None;
                Console.WriteLine($"There is no such genre.");
            }    
            
            Book book = new Book(title, author, publicationYear, genre);
            _books.Add(book);
        }

        public void Delete()
        {
            Console.Write($"Which book do you want to remove from storage? Enter title book - ");
            string title;
            title = Console.ReadLine();
            _books.RemoveAll(book => book.Title == title);
        }

        public void SearchByTitle()
        {
            string title;
            Console.Write("Enter book title - ");
            title = Console.ReadLine();
            ShowFoundBooks(_books.FindAll(book => book.Title == title));
        }

        public void SearchByAuthor()
        {
            string author;
            Console.Write("Enter book author - ");
            author = Console.ReadLine();
            ShowFoundBooks(_books.FindAll(book => book.Author == author));
        }

        public void SearchByPublicationYear()
        {
            string publicationYear;
            Console.Write("Enter book publication year - ");
            publicationYear = Console.ReadLine();
            ShowFoundBooks(_books.FindAll(book => book.PublicationYear == publicationYear));
        }

        public void SearchByGenre()
        {
            Console.SetCursorPosition(0, 15);
            ShowAllGenre();
            Console.SetCursorPosition(0, 2);
            Console.Write($"Choose the number genre of the book - ");
            string genre;
            genre = Console.ReadLine();
            ShowFoundBooks(_books.FindAll(book => book.Genre == (Genre)Convert.ToInt32(genre)));
        }

        public void Show()
        {
            Console.SetCursorPosition(0, 15);

            foreach (Book book in _books)
            {
                Console.WriteLine($"Author - {book.Author}. Title - {book.Title}. Publication year of the book - {book.PublicationYear}. Genre - {book.Genre}.");
            }
        }

        private void ShowFoundBooks(List<Book> books)
        {
            Console.SetCursorPosition(0, 15);

            if (books.Count > 0)
            {
                foreach (Book book in books)
                {
                    Console.WriteLine($"Author - {book.Author}. Title - {book.Title}. Publication year of the book - {book.PublicationYear}. Genre - {book.Genre}.");
                }
            }
            else
            {
                Console.WriteLine("This book is not in stock.");
            }
        }

        private void ShowAllGenre()
        {
            for (int i = 0; i < Enum.GetValues(typeof(Genre)).Length; i++)
            {
                Console.WriteLine($"{i}.{Enum.GetNames(typeof(Genre))[i]}");
            }
        }
    }
}
