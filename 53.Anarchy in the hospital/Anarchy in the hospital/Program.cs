using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anarchy_in_the_hospital
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Patient> patients = new List<Patient>
            {
                new Patient("Иванов Иван",25,"Язва"),
                new Patient("Сидоров Николай",40,"Артрит"),
                new Patient("Прокопенко Сергей",57,"Дисплазия"),
                new Patient("Тарасов Олег",33,"Перелом"),
                new Patient("Жуков Сергей",65,"Апендицит"),
                new Patient("Любимцева Марина",60,"Дисплазия"),
                new Patient("Денисенко Иван",44,"Инфаркт"),
                new Patient("Ильин Евгений",71,"Дисплазия"),
                new Patient("Сулинёв Евгений",42,"Туберкулез"),
                new Patient("Земсков Максим",50,"Тугоухость"),
                new Patient("Нагуманов Рашид",54,"Тугоухость"),
                new Patient("Ильгизова Фарида",38,"Анивризма"),
                new Patient("Ибрагимова Алиса",49,"Анивризма"),
                new Patient("Денисов Артём",21,"Перелом"),
                new Patient("Влацких Сергей",16,"Язва"),
                new Patient("Дегтярёв Тарас",29,"Перелом"),
                new Patient("Клим Жуков",47,"Инфаркт"),
                new Patient("Пучков Дмитрий",54,"Дисплазия"),
                new Patient("Зубкова Наталья",28,"Апендицит"),
                new Patient("Зубков Олег",69,"Артрит"),
                new Patient("Шевченко Александр",36,"Туберкулез"),
                new Patient("Земченко Николай",10,"Анивризма"),
                new Patient("Алтушкин Фёдор",88,"Дисплазия"),
                new Patient("Пацев Дмитрий",34,"Анивризма"),
                new Patient("Кочешкова Екатерина",30,"Язва"),
                new Patient("Самков Валерий",42,"Инфаркт"),
                new Patient("Кулик Иван",27,"Перелом"),
                new Patient("Варламов Андрей",26,"Язва"),
                new Patient("Рудной Сергей",26,"Туберкулез"),
                new Patient("Зверева Любовь",77,"Артрит")
            };
            Clinic clinic = new Clinic(patients);
            bool isExit = false;

            while (isExit == false)
            {
                Console.Clear();
                Console.WriteLine($"1.Отсортировать всех больных по фио\n2.Отсортировать всех больных по возрасту\n3.Вывести больных с определенным заболеванием\n4.Выход");

                switch (Console.ReadLine())
                {
                    case "1":
                        clinic.OrderByFullName();
                        break;
                    case "2":
                        clinic.OrderByAge();
                        break;
                    case "3":
                        clinic.ShowPatientWithDisease();
                        break;
                    case "4":
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

   public class Patient
    {
        public string FullName { get; private set; }
        public int Age { get; private set; }
        public string Disease { get; private set; }

        public Patient(string fullName, int age, string disease)
        {
            FullName = fullName;
            Age = age;
            Disease = disease;
        }

        public void Show()
        {
            Console.WriteLine($"Full Name - {FullName}\t | Age - {Age} | Disease - {Disease}");
        }
    }

    public class Clinic
    {
        private List<Patient> _patients;

        public Clinic(List<Patient> patients)
        {
            _patients = patients;
        }

        public void OrderByFullName()
        {
            _patients = _patients.OrderBy(_patients => _patients.FullName).ToList();

            foreach (Patient patient in _patients)
            {
                patient.Show();
            }
        }

        public void OrderByAge()
        {
            _patients = _patients.OrderBy(_patients => _patients.Age).ToList();

            foreach (Patient patient in _patients)
            {
                patient.Show();
            }
        }

        public void ShowPatientWithDisease()
        {
            List<Patient> tempPatients;
            Console.Write($"Enter disease - ");
            string disease = Console.ReadLine();
            tempPatients = _patients.Where(_patients => _patients.Disease == disease).ToList();

            foreach (Patient patient in tempPatients)
            {
                patient.Show();
            }
        }
    }
}
