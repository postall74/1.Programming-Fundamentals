using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amnesty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Criminal> criminals = new List<Criminal>
            {
                new Criminal("Фёдор Достоевский","Антиправительственное"),
                new Criminal("Лев Толстой","Уголовное"),
                new Criminal("Антон Чехов","Административное"),
                new Criminal("Николай Гоголь","Антиправительственное"),
                new Criminal("Михаил Лермонтов","Антиправительственное"),
                new Criminal("Иван Тургенев","Антиправительственное"),
                new Criminal("Александр Пушкин","Уголовное"),
                new Criminal("Михаил Булгаков","Уголовное"),
                new Criminal("Анна Ахматова","Уголовное"),
                new Criminal("Владимир Набоков","Уголовное"),
                new Criminal("Александр Толстой","Уголовное"),
                new Criminal("Фёдор Тютчев","Уголовное"),
                new Criminal("Марина Цветаева","Уголовное"),
                new Criminal("Владимир Высоцкий","Уголовное"),
                new Criminal("Александр Грин","Антиправительственное"),
                new Criminal("Михаил Ломоносов","Уголовное"),
                new Criminal("Даниил Хармс","Административное"),
                new Criminal("Владимир Короленко","Административное"),
                new Criminal("Самиул Маршак","Антиправительственное"),
                new Criminal("Владимр Даль","Административное"),
                new Criminal("Николай Гумилёв","Административное"),
                new Criminal("Иосиф Бродский","Административное"),
                new Criminal("Сергей Довлатов","Административное"),
                new Criminal("Николай Рерих","Административное"),
                new Criminal("Александр Блок","Административное"),
                new Criminal("Максим Горький","Административное"),
                new Criminal("Николай Некрасов","Административное"),
                new Criminal("Александр Грибоедов","Административное"),
                new Criminal("Борис Пастернак","Административное   "),
                new Criminal("Константин Паустовский","Антиправительственное")
            };
            LawCourt lawCourt = new LawCourt(criminals);
            lawCourt.Show();
            Console.WriteLine();
            lawCourt.Amnesty();
        }
    }

    public class Criminal
    {
        public string FullName { get; private set; }
        public string TypeCrime { get; private set; }

        public Criminal(string fullName, string typeCrime)
        {
            FullName = fullName;
            TypeCrime = typeCrime;
        }
    }

    public class LawCourt
    {
        private List<Criminal> _criminals;

        public LawCourt(List<Criminal> criminals)
        {
            _criminals = criminals;
        }

        public void Show()
        {
            foreach (Criminal criminal in _criminals)
            {
                Console.WriteLine($"Full Name - {criminal.FullName} | Type Crime - {criminal.TypeCrime}");
            }
        }

        public void Amnesty()
        {
            _criminals = _criminals.Where(_criminals => _criminals.TypeCrime != "Антиправительственное").ToList();
            Show();
        }
    }
}
