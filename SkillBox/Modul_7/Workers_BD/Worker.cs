using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workers_BD
{
    internal struct Worker
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public int Height { get; private set; }
        public string PlaceOfBirth { get; private set; }
        public int Age { get; private set; }
        public DateTime MomentOfAdd { get; private set; }

        public Worker(int id, DateTime momentOfAdd, string name, int age, int height, DateTime dateOfBirth, string placeOfBirth)
        {
            Id= id;
            Name = name;
            Height = height;
            DateOfBirth = dateOfBirth;
            MomentOfAdd = momentOfAdd;
            Age = age;
            PlaceOfBirth = placeOfBirth;
        }

        public Worker(int id, string name, int height, DateTime dateOfBirth, string placeOfBirth) :
            this(id, DateTime.Now, name, DateTime.Now.Year - dateOfBirth.Year, height, dateOfBirth, placeOfBirth)
        {
            
        }
        public Worker(string id, string momentOfAdd, string name, string age, string height, string dateOfBirth, string placeOfBirth)
        {
            Id = Convert.ToInt32(id);
            MomentOfAdd = DateTime.Parse(momentOfAdd);
            Name = name;
            Age = Convert.ToInt32(age);
            Height = Convert.ToInt32(height);
            DateOfBirth = DateTime.Parse(dateOfBirth);
            PlaceOfBirth = placeOfBirth;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"ID: {Id}    Время записи: {MomentOfAdd}\n" +
                                  $"Ф.И.О: {Name}    Возраст: {Age}    Рост: {Height}\n" +
                                  $"Дата рождения: {DateOfBirth.ToShortDateString()}    Место рождения: {PlaceOfBirth}");
            Console.WriteLine(new string('=', 20));
        }

        public string WorkerToString()
        {
            string lineOfData = ($"{Id}#{MomentOfAdd}#{Name}#{Age}#{Height}#{DateOfBirth.ToShortDateString()}#{PlaceOfBirth}");

            return lineOfData;
        }
    }
}
