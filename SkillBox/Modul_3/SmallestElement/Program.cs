using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallestElement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество элементов");
            int amountElement = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите число");
            int minElement = Convert.ToInt32(Console.ReadLine());
            for (int i = 1; i < amountElement; i++)
            {
                Console.WriteLine("Введите число");
                int element = Convert.ToInt32(Console.ReadLine());
                if (element < minElement)
                {
                    minElement = element;
                }
            }
            Console.WriteLine($"Наименьшее число = {minElement}");
            Console.ReadKey();
        }
    }
}
