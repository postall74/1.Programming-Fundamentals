using System;

namespace Polyclinic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int timeOfReceipt = 10;
            Console.WriteLine("Сколько людей в очереди перед вами?");
            int pacientCount = Convert.ToInt32(Console.ReadLine());
            int countMinutsInHours = 60;
            int waitingHours = timeOfReceipt * pacientCount / countMinutsInHours;
            int waitingMinutes = timeOfReceipt * pacientCount % countMinutsInHours;
            Console.WriteLine(waitingHours + ":" + waitingMinutes);
            Console.ReadKey();
        }
    }
}
