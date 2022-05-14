using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Picture
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int pictureInRow = 3;
            int picture = 52;
            int countRowsWithPicture = picture / pictureInRow;
            int pictureRest = picture % pictureInRow;
            Console.WriteLine("Количество картинок которое выведется на экран будет равно " + countRowsWithPicture);
            Console.WriteLine("Картинок которые не выведутся на экран будет " + pictureRest); 
            Console.ReadKey();
        }
    }
}
