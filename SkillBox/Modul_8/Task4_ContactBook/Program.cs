using System;
using System.IO;
using System.Xml.Serialization;
using System.Xml.Linq;
using System.Text.RegularExpressions;

namespace Task4_ContactBook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ClsPerson person;
            while (true)
            {
                Console.Write("Введите имя: ");
                string name = Console.ReadLine();
                Console.Write("Введите наззвание улицы: ");
                string street = Console.ReadLine();
                Console.Write("Введите номер дома: ");
                string houseNumber = Console.ReadLine();
                Console.Write("Введите номер квартиры: ");
                string flatNumber = Console.ReadLine();
                Console.Write("Введите номер телефона (8ХХХХХХХХХХ): ");
                string mobilePhone = Console.ReadLine();
                Console.Write("Введите домашний номер телефона (ХХХ-ХХ-ХХ): ");
                string flatPhone = Console.ReadLine();

                try
                {
                    person = new ClsPerson(name, street, houseNumber, flatNumber, mobilePhone, flatPhone);
                    Console.WriteLine("Данные успешно созданы!");
                    break;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"{ex.Message}");
                    Console.WriteLine("Попробуйте ввести данные заново!");
                    Console.ReadKey();
                }
                Console.Clear();
            }

            //Через XmlSerializer
            XmlSerializer serializer = new XmlSerializer(typeof(ClsPerson));
            using (StreamWriter writer = new StreamWriter("XmlSerPerson.xml"))
            {
                serializer.Serialize(writer, person);
            }

            //Через XElement
            XElement personXml = new XElement("Person",
                new XAttribute("Name", person.Name),
                new XElement("Address",
                    new XElement("Street", person.Address.Street),
                    new XElement("HouseNumber", person.Address.HouseNumber),
                    new XElement("FlatNumber", person.Address.FlatNumber)
                ),
                new XElement("Phones",
                    new XElement("MobilePhone", person.Phones.MobilePhone),
                    new XElement("FlatPhone", person.Phones.FlatPhone)
                )
            );

            personXml.Save("XElemPerson.xml");
        }

    }

    public class ClsPerson
    {
        [XmlAttribute("Name")]
        public string Name { get; set; }
        public ClsAddress Address { get; set; }

        public ClsPhones Phones { get; set; }

        public ClsPerson()
        {

        }

        public ClsPerson(string name, string street, string houseNumber, string flatNumber, string mobilePhone, string flatPhone)
        {
            Address = new ClsAddress(street, houseNumber, flatNumber);
            Phones = new ClsPhones(mobilePhone, flatPhone);
            Name = name;
        }
    }

    public class ClsAddress
    {
        public string Street { get; set; }
        public int HouseNumber { get; set; }
        public int FlatNumber { get; set; }

        public ClsAddress()
        {

        }

        public ClsAddress(string street, string houseNumber, string flatNumber)
        {
            if (!IsValidNumbers(houseNumber, flatNumber))
            {
                throw new ArgumentException("Номера дома и квартиры должны быть числом!");
            }
            Street = street;
            HouseNumber = Convert.ToInt32(houseNumber);
            FlatNumber = Convert.ToInt32(flatNumber);
        }

        public bool IsValidNumbers(string strHouseNumber, string strFlatNumber)
        {
            int houseNumber;
            int flatNumber;
            return int.TryParse(strHouseNumber, out houseNumber) && int.TryParse(strFlatNumber, out flatNumber);
        }
    }

    public class ClsPhones
    {
        public string MobilePhone { get; set; }
        public string FlatPhone { get; set; }

        public ClsPhones()
        {

        }

        public ClsPhones(string mobilePhone, string flatPhone)
        {
            if (!IsValidPhoneNumber(mobilePhone, flatPhone))
            {
                throw new ArgumentException("Введенные номера не соответстуют формату ввода!");
            }
            MobilePhone = mobilePhone;
            FlatPhone = flatPhone;
        }

        public bool IsValidPhoneNumber(string mobilePhone, string flatPhone)
        {
            string mobilePattern = @"^8\d{10}$";
            string flatPattern = @"^\d{3}-\d{2}-\d{2}$";
            Regex regexMobile = new Regex(mobilePattern);
            Regex regexFlat = new Regex(flatPattern);

            return regexMobile.IsMatch(mobilePhone) && regexFlat.IsMatch(flatPhone);
        }

    }

}
