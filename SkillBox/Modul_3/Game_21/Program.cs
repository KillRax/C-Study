using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_21
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество карт!");
            int amountCard = Convert.ToInt32(Console.ReadLine());
            int sumValue = 0;
            int i = 0;
            while (i < amountCard)
            {
                Console.WriteLine("Введите карту!");
                string card = Console.ReadLine();
                switch (card)
                {
                    case "J":
                    case "K":
                    case "Q":
                    case "T":
                        sumValue += 10;
                        i++;
                        break;
                    case "2":
                    case "3":
                    case "4":
                    case "5":
                    case "6":
                    case "7":
                    case "8":
                    case "9":
                    case "10":
                        sumValue += Convert.ToInt32(card);
                        i++;
                        break;
                    default:
                        Console.WriteLine("Введено неверное значение! Порпробуйте снова!");
                        break;
                }
            }
            Console.WriteLine($"Сумма ваших кард = {sumValue}");
            Console.ReadKey();
        }
    }
}
