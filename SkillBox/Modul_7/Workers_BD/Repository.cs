using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Workers_BD
{
    internal struct Repository
    {
        private string _fileName;
        private int _actualId;

        private List<Worker> _workers;  

        public Repository(string fileName)
        {  
            _fileName = fileName;
            _actualId = 0;
            _workers = new List<Worker>();
        }

        public void FileIsExist()
        {
            if (!File.Exists(_fileName))
            {
                Console.WriteLine("Файл не существует! Необходимо внести первого сотрудника!");
                AddNewWorker();
            }
            else
            {
                Console.WriteLine("Файл найден!");
                ReadFromFile();
                _actualId = _workers.Last().Id;
            }
            Console.WriteLine("Для продолжения нажмите любую кнопку!");
            Console.Clear();
            OutputAllWorkers();
        }

        /// <summary>
        /// Добавляет нового работника в список и сразу записывает в файл
        /// </summary>
        public void AddNewWorker()
        {
            _actualId++;
            _workers.Add(CreateWorker(_actualId));
            WriteToFile();
        }

        public void OutputAllWorkers()
        {
            foreach (Worker worker in _workers)
            {
                worker.ShowInfo();
            }
        }

        /// <summary>
        /// Позволяет выбрать конкретного сотрудника из списка и либо удалить его либо изменить его данные
        /// </summary>
        public void WorkWithConcreteWorker()
        {
            int placeOfWorker = FindConcreteWorker();
            Console.WriteLine("Выберите действие с записью: Изменить - 1, Удалить - 2");
            Console.WriteLine("Для выхода из данного режима введите что угодно");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    _workers[placeOfWorker] = CreateWorker(_workers[placeOfWorker].Id);
                    WriteToFile();
                    break;
                case "2":
                    _workers.Remove(_workers[placeOfWorker]);
                    WriteToFile();
                    break;
                default:
                    break;
            }
        }

        public void GetWorkersBetweenTwoDates(string firstDate, string secondDate)
        {
            DateTime dateFrom = DateTime.Parse(firstDate);
            DateTime dateTo = DateTime.Parse(secondDate);
            foreach (Worker worker in _workers)
            {
                if ((worker.MomentOfAdd >= dateFrom) && (worker.MomentOfAdd <= dateTo))
                {
                    worker.ShowInfo();
                }
            }
        }

        /// <summary>
        /// Выводит список работников сортированный по выбранному полю
        /// </summary>
        public void SortWorkers()
        {
            List<Worker> sortedWorkers = new List<Worker>();
            Console.WriteLine("Отсортировать работников по:");
            Console.WriteLine("ID - 1\nФ.И.О - 2\nВозраст - 3\nРост - 4\nДата рождения - 5\nМесто рождения - 6");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    sortedWorkers = _workers.OrderBy(w => w.Id).ToList();
                    break;
                case "2":
                    sortedWorkers = _workers.OrderBy(w => w.Name).ToList();
                    break;
                case "3":
                    sortedWorkers = _workers.OrderBy(w => w.Age).ToList();
                    break;
                case "4":
                    sortedWorkers = _workers.OrderBy(w => w.Height).ToList();
                    break;
                case "5":
                    sortedWorkers = _workers.OrderBy(w => w.DateOfBirth).ToList();
                    break;
                case "6":
                    sortedWorkers = _workers.OrderBy(w => w.PlaceOfBirth).ToList();
                    break;
                default:
                    Console.WriteLine("Введен неверный номер!");
                    break;
            }
            foreach (Worker worker in sortedWorkers)
            {
                worker.ShowInfo();
            }
        }

        private Worker CreateWorker(int startId)
        {
            int id = startId;

            Console.Write("Введите Ф.И.О сотрудника: ");
            string name = Console.ReadLine();

            Console.Write("Введите рост сотрудника: ");
            int height = Convert.ToInt32(Console.ReadLine());

            DateTime dateOfBirth = InputDateOfBirth();

            Console.Write("Введите место рождения сотрудника: ");
            string placeOfBirth = Console.ReadLine();

            Worker worker = new Worker(id, name, height, dateOfBirth, placeOfBirth);

            return worker;
        }

        private DateTime InputDateOfBirth()
        {
            DateTime dateOfBirth;
            string input;

            do
            {
                Console.Write("Введите дату рождения в формате дд.мм.гггг: ");
                input = Console.ReadLine();
            }
            while (!DateTime.TryParseExact(input, "dd.MM.yyyy", null, DateTimeStyles.None, out dateOfBirth));

            return dateOfBirth;
        }

        private void WriteToFile()
        {
            StreamWriter sw = new StreamWriter(_fileName);
            string lineOfData;
            foreach (Worker worker in _workers)
            {
                lineOfData = worker.WorkerToString();
                sw.WriteLine(lineOfData);
            }
            sw.Close();
            Console.WriteLine("Данные добавлены!");
        }

        private void ReadFromFile()
        {
            StreamReader sr = new StreamReader(_fileName);
            string line = sr.ReadLine();
            string[] datas = { };
            while (line != null)
            {
                datas = line.Split('#');
                _workers.Add(new Worker(datas[0], datas[1], datas[2], datas[3], datas[4], datas[5], datas[6]));
                line = sr.ReadLine();
            }
            sr.Close();
        }

        private int FindConcreteWorker()
        {
            Console.Write("Введите ID конкретного работника: ");
            int id = Convert.ToInt32(Console.ReadLine());

            int numberOfWorker = 0;

            for (int i = 0; i < _workers.Count; i++)
            {
                if (id == _workers[i].Id)
                {
                    _workers[i].ShowInfo();
                    numberOfWorker = i;
                    return numberOfWorker;
                }
            }
            Console.WriteLine("Данный ID не найден! Поврите попытку!");
            Console.ReadKey();
            numberOfWorker = FindConcreteWorker();
            return numberOfWorker;
        }
    }
}
