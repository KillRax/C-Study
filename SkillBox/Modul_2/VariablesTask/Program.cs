using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace VariablesTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = "Иванов Иван Иванович";
            string email = "IvanovII@mail.ru";
            int age = 19;
            double programmingPoints = 89.4;
            double mathPoints = 72.5;
            double physicsPoints = 67.8;

            double sumPoints = programmingPoints + mathPoints + physicsPoints;
            double avgPoints = sumPoints / 3;

            string resultOutput = "ФИО поступающего: {0}    Возраст: {1} \nEmail: {2}" +
                "\nБаллы: \n    Программирование: {3} \n    Математика: {4}\n    Физика: {5}" +
                "\nCумма баллов: {6} \nСредний балл: {7:0.0}";

            Console.WriteLine(resultOutput, name, age, email, programmingPoints, mathPoints, physicsPoints, sumPoints, avgPoints);
            Console.ReadLine();

        }
    }
}
