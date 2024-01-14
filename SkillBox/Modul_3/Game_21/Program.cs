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
            for (int i = 0; i < amountCard; i++)
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
                        break;

                    default:
                        sumValue += Convert.ToInt32(card);
                        break;
                }
            }
            Console.WriteLine($"Сумма ваших кард = {sumValue}");
            Console.ReadKey();
        }
    }
}
