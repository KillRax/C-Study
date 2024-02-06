using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomMatrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество строк в матрице");
            int rowMatrix = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите количество столбцов в матрице");
            int columnMatrix = Convert.ToInt32(Console.ReadLine());
            int[,] matrix = new int[rowMatrix, columnMatrix];
            Random random = new Random();
            int sum = 0;
            for (int i = 0; i < rowMatrix; i++)
            {
                for (int j = 0; j < columnMatrix; j++)
                {
                    matrix[i, j] = random.Next(0, 100);
                    sum += matrix[i, j];
                    Console.Write($"{matrix[i, j]} \t");
                }
                Console.WriteLine();
            }
            Console.WriteLine($"Сумма элементов = {sum}");
            Console.ReadKey();
        }
    }
}
