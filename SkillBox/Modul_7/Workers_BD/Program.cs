using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workers_BD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Repository repository = new Repository("workers.txt");
            repository.FileIsExist();
            while (true)
            {
                Console.WriteLine("Выберете действие!");
                Console.WriteLine("Просмотреть все записи - 0\nСоздать запись - 1\nНайти конкретного сотрудника - 2\n" +
                                  "Вывести записи созданные в диапазон дат - 3\nСортировать сотрудников по полю - 4");
                string input = Console.ReadLine();
                Console.Clear();
                switch (input)
                {
                    case "0":
                        repository.OutputAllWorkers();
                        ReadKeyClear();
                        break;
                    case "1":
                        repository.AddNewWorker();
                        ReadKeyClear();
                        break;
                    case "2":
                        repository.WorkWithConcreteWorker();
                        ReadKeyClear();
                        break;
                    case "3":
                        Console.Write("Первая дата (дд.ММ.гггг): ");
                        string firstDate = Console.ReadLine();
                        Console.Write("Вторая дата (дд.ММ.гггг): ");
                        string secondDate = Console.ReadLine();
                        repository.GetWorkersBetweenTwoDates(firstDate, secondDate);
                        ReadKeyClear();
                        break;
                    case "4":
                        repository.SortWorkers();
                        ReadKeyClear();
                        break;
                    default:
                        Console.WriteLine("Введен неверный номер!");
                        ReadKeyClear();
                        break;
                }
            }
        }

        static void ReadKeyClear()
        {
            Console.ReadKey();
            Console.Clear();
        }
    }
}
