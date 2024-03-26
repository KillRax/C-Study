using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_WorkWithList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите количество элементов в списке: ");
            int countNumbers = Convert.ToInt32(Console.ReadLine());
            List<int> list = FillListByRandom(countNumbers);
            OutputList(list);

            Console.Write("\nВведите начало и конец диапазона чисел\nНачало: ");
            int startRange = Convert.ToInt32(Console.ReadLine());
            Console.Write("Конец: ");
            int endRange = Convert.ToInt32(Console.ReadLine());

            list = RemoveNumbersInRange(list, startRange, endRange);

            OutputList(list);
        }
        
        static List<int> FillListByRandom (int countNumbers)
        {
            Random random = new Random();
            List<int> list = new List<int>();
            for (int i = 0; i < countNumbers; i++)
            {
                list.Add(random.Next(0,101));
            }
            return list;
        }

        static void OutputList (List<int> list)
        {
            Console.WriteLine("Ваш лист:");
            foreach (int elem in list)
            {
                Console.WriteLine(elem);
            }
        }

        static List<int> RemoveNumbersInRange(List<int> list, int startRange, int endRange)
        {
            /* Реализация челез цикл
            List<int> selectedNums = new List<int>();
            foreach(int elem in list)
            {
                if (!((elem > startRange)&&(elem < endRange)))
                {
                    selectedNums.Add(elem);
                }
            }
            */

            //Реализация через LINQ
            var selectedNums = list.Where(n => (!((n > startRange) && (n < endRange)))).ToList();
            Console.WriteLine($"Числа в диапазоне от {startRange} до {endRange} удалены!\n");
            return selectedNums;
        }
    }
}
