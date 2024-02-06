using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_GuessNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите максимальное число диапазона");
            int maxRange = Convert.ToInt32(Console.ReadLine());
            Random random = new Random();
            int mysteryNumber = random.Next(0, maxRange);

            Console.WriteLine("Введите число чтобы угадайте число!\nЧтобы прекратить введите что угодно кроме числа!");
            bool result = int.TryParse(Console.ReadLine(), out var symbol);
            while (result)
            {
                int number = symbol;
                if (mysteryNumber < number)
                {
                    Console.WriteLine("Загаданное число меньше!");
                }
                else if (mysteryNumber > number)
                {
                    Console.WriteLine("Загаданное число больше!");
                }
                else
                {
                    Console.WriteLine("Вы угадали!");
                    break;
                }
                Console.WriteLine("Попробуйте еще раз!");
                result = int.TryParse(Console.ReadLine(), out symbol);
            }
            Console.WriteLine("Игра окончена!");
            Console.ReadLine();
        }
    }
}
