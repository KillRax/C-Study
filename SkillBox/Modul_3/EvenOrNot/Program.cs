using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvenOrNot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите число!");
            int number = Convert.ToInt32(Console.ReadLine());
            if (number % 2 == 0)
            {
                Console.WriteLine("Число четное!");
            }
            else
            {
                Console.WriteLine("Число нечетное!");
            }
            Console.ReadKey();
        }
    }
}
