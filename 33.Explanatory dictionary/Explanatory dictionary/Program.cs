using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explanatory_dictionary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> explanatoryDictionary = new Dictionary<string, string>();
            explanatoryDictionary.Add("АБЗАЦ", "Красная строка, отступ в начале строки.");
            explanatoryDictionary.Add("АВАНТЮРА", "Рискованное и сомнительное дело, предпринятое врасчете на случайный успех.");
            explanatoryDictionary.Add("АГНЕЦ", "Ягненок (обычно как жертвенное животное).");
            explanatoryDictionary.Add("АКЫН", "Народный поэт-певец (в Казахстане, Киргизии).");
            explanatoryDictionary.Add("АНТОНИМ", "В языкознании: слово, противоположное по значениюдругому слову, напр. светлый и темный - антонимы.");
            explanatoryDictionary.Add("АДЕПТ", "Приверженец, последователь какого-н.учения.");
            explanatoryDictionary.Add("БАЛЛ", "Единица оценки степени, силы какого-н. физическогоявления (спец.).");
            explanatoryDictionary.Add("БЕЛУХА", "Крупный полярный дельфин.");
            explanatoryDictionary.Add("БИСЕР", "Мелкие стеклянные цветные бусинки, зернышкисо сквозными отверстиями.");
            explanatoryDictionary.Add("ВАЛ3", "В экономике: общий объем продукции в стоимостномвыражении, произведенной за какой-н. определенный период.");
            explanatoryDictionary.Add("ВЕКСЕЛЬ", " Ценная бумага, долговой документ- обязательство уплатить кому-н. определенную сумму денег в определенныйсрок.");
            bool isExit = false;

            while (isExit == false)
            {
                Console.Write("Введите слово, что бы узнать его значение: ");
                string word = Console.ReadLine().ToUpper();

                if (word == "EXIT")
                {
                    isExit = true;
                    Console.WriteLine("До скорой встречи!");
                }
                else if (explanatoryDictionary.ContainsKey(word) == false)
                {
                    Console.WriteLine("Такого слова нету в словаре, попробуй еще разок!");
                }
                else
                {
                    Console.WriteLine($"{word} - {explanatoryDictionary[word]}");
                }
                Console.ReadKey(true);
            }
        }
    }
}
