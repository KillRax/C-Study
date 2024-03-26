using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3_CheckRepeat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<int> numbers = new HashSet<int>();
            int number;
            while (true) 
            {
                Console.Write("Введите число: ");
                number = Convert.ToInt32(Console.ReadLine());
                if (numbers.Contains(number))
                {
                    Console.WriteLine("Такое число уже есть в коллекции");
                }
                else
                {
                    numbers.Add(number);
                }
            }
        }
    }
}
