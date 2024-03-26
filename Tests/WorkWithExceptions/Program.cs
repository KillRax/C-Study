using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WorkWithExceptions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите имя: ");
            string _name = Console.ReadLine();
            Console.Write("\nВведите номер телефона: ");
            string _phoneNumber = Console.ReadLine();

            try
            {
                User user = new User(_name, _phoneNumber);
                Console.WriteLine("Успешное создание");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
        }
        public class User
        {
            public string Name { get; private set; }
            public string PhoneNumber { get; private set; }

            public User(string name, string phoneNumber)
            {
                if (!IsValidPhoneNumber(phoneNumber))
                {
                    throw new ArgumentException("Введенный номер не соответствует формату!");
                }
                Name = name;
                PhoneNumber = phoneNumber;
            }

            private bool IsValidPhoneNumber(string mobilePhone)
            {
                string mobilePattern = @"^8\d{10}$";
                Regex regexMobile = new Regex(mobilePattern);

                return regexMobile.IsMatch(mobilePhone);
            }
        }
    }
}
