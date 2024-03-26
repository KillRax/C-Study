using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task2_PhoneBook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string,string> phoneBook = FillPhoneBook();
            FindSubscriber(phoneBook);
        }

        static string ReadPhoneNumber()
        {
            Console.Write("Введите номер телефона в формате +7-999-888-77-66: ");
            string phoneNumber = Console.ReadLine();
            
            bool isValid = IsValidPhoneNumber(phoneNumber);
            if ((isValid)||(phoneNumber == "")) 
            {
                return phoneNumber;
            }
            else 
            {
                Console.WriteLine("Несоответсвие формату ввода!");
                return ReadPhoneNumber();
            }
        }

        static bool IsValidPhoneNumber(string number)
        {
            // Регулярное выражение для проверки номера телефона
            string pattern = @"^\+\d-\d{3}-\d{3}-\d{2}-\d{2}$";
            Regex regex = new Regex(pattern);

            return regex.IsMatch(number);
        }

        static string InputNameSubscriber()
        {
            Console.Write("Введите ФИО абонента: ");
            string name = Console.ReadLine();
            return name;
        }

        static Dictionary<string,string> FillPhoneBook()
        {
            Dictionary<string,string> phoneBook = new Dictionary<string,string>();
            
            while (true)
            { 
                string phone = ReadPhoneNumber();
                if (phone == "")
                {
                    break;
                }
                else if (!phoneBook.ContainsKey(phone))
                {
                    string name = InputNameSubscriber();
                    phoneBook[phone] = name;
                }
                else 
                {
                    Console.WriteLine("Этот номер ужк зарегистрирован!");
                }
            }
            return phoneBook;
        }

        static void FindSubscriber(Dictionary<string,string> phoneBook)
        {
            Console.Clear();
            Console.WriteLine("Начат поиск абонентов...");
            string phone;
            string name;
            while (true)
            {
                phone = ReadPhoneNumber();
                if (phone == "")
                {
                    break;
                }
                else if (phoneBook.TryGetValue(phone, out name))
                {
                    Console.WriteLine($"Абонент: {name}    Номер: {phone}");
                }
                else
                {
                    Console.WriteLine("По данному номеру абонент не найден");
                }
            }
            
        }
    }
}
