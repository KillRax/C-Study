using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

namespace Employees
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true) 
            {
                Console.Clear();
                FileIsExist();
                Console.WriteLine("Введите действие: (1 - вывести данные, 2 - создать новую запись, 3 - выйти из программы)");
                string input = Console.ReadLine();
                Console.Clear();
                if (input == "1")
                {
                    OutputListOfEmployees();
                    Console.WriteLine("Для продолжения нажмите любую кнопку");
                    Console.ReadKey();
                }
                else if (input == "2")
                {
                    int id = FindActualID();
                    string lineData = CreateDataOfEmployee(id);
                    WriteEmployeeInList(lineData);
                    Console.WriteLine("Для продолжения нажмите любую кнопку");
                    Console.ReadKey();
                }
                else if (input == "3")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Вы ввели неподходящее значение!\nДля продолжения нажмите любую кнопку");
                    Console.ReadKey();
                }
            }
        }

        static void FileIsExist()
        { 
            if (!File.Exists("employees.txt"))
            {
                Console.WriteLine("Файл не существует! Необходимо внести первого сотрудника!");
                string lineOfData = CreateDataOfEmployee();
                WriteEmployeeInList(lineOfData);
            }
            else
            {
                Console.WriteLine("Файл найден!");
            }
        }

        static void WriteEmployeeInList(string lineOfData)
        {
            StreamWriter sw = new StreamWriter("employees.txt", true);
            sw.WriteLine(lineOfData);
            sw.Close();
            Console.WriteLine("Данные добавлены!");
        }

        static string CreateDataOfEmployee(int startID = 1)
        {
            int id = startID;

            Console.WriteLine("Введите Ф.И.О сотрудника:");
            string name = Console.ReadLine();

            Console.WriteLine("Введите рост сотрудника:");
            int height = Convert.ToInt32(Console.ReadLine());

            DateTime dateOfBirth = InputDateOfBirth();

            Console.WriteLine("Введите место рождения сотрудника:");
            string placeOfBirth = Console.ReadLine();

            var age = DateTime.Now.Year - dateOfBirth.Year;

            string lineOfData = ($"{id}#{DateTime.Now.ToShortDateString()} {DateTime.Now.ToShortTimeString()}#" +
                $"{name}#{age}#{height}#{dateOfBirth.ToShortDateString()}#{placeOfBirth}");

            Console.Clear();
            return lineOfData;
        }

        static void OutputListOfEmployees()
        {
            StreamReader sr = new StreamReader("employees.txt");
            string line = sr.ReadLine();
            string[] datas = { };
            while (line != null)
            {
                datas = line.Split('#');
                Console.WriteLine($"ID: {datas[0]}    Время записи: {datas[1]}\n" +
                                  $"Ф.И.О: {datas[2]}    Возраст: {datas[3]}    Рост: {datas[4]}\n" +
                                  $"Дата рождения: {datas[5]}    Место рождения: {datas[6]}");
                Console.WriteLine(new string('=',20));
                line = sr.ReadLine();
            }
            sr.Close();
        }

        static int FindActualID()
        {
            string lastLine = File.ReadLines("employees.txt").Last();
            string[] lastDatas = lastLine.Split('#');
            int actualID = Convert.ToInt32(lastDatas[0]) + 1;
            return actualID;
        }

        static DateTime InputDateOfBirth()
        {
            DateTime dateOfBirth;
            string input;

            do
            {
                Console.WriteLine("Введите дату рождения в формате дд.мм.гггг:");
                input = Console.ReadLine();
            }
            while (!DateTime.TryParseExact(input, "dd.MM.yyyy", null, DateTimeStyles.None, out dateOfBirth));

            return dateOfBirth;
        }
    }
}
