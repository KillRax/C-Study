using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsPrime
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите число!");
            int yourNumber = Convert.ToInt32(Console.ReadLine());
            bool isPrime = IsPrime(yourNumber);
            if(isPrime)
            {
                Console.WriteLine($"Число {yourNumber} - простое!");
            }
            else
            {
                Console.WriteLine($"Число {yourNumber} - НЕпростое!");
            }
            Console.ReadKey();
        }
        static bool IsPrime(int number)
        {
            if (number == 2)
            {
                return true;
            }
            else if (number % 2 == 0)
            {
                return false;
            }
            else
            {
                int i = 3;
                while (i <= number - 1)
                {
                    if (number % i == 0)
                    {
                        return false;
                    }
                    i += 2;
                }
                return true;
            }
        }
    }
}
