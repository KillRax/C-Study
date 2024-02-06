using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumMatrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество строк в матрице");
            int rowMatrix = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите количество столбцов в матрице");
            int columnMatrix = Convert.ToInt32(Console.ReadLine());
            int[,] matrixA = new int[rowMatrix, columnMatrix];
            int[,] matrixB = new int[rowMatrix, columnMatrix];
            int[,] matrixC = new int[rowMatrix, columnMatrix];
            Random random = new Random();
            for (int i = 0; i < rowMatrix; i++)
            {
                for (int j = 0; j < columnMatrix; j++)
                {
                    matrixA[i, j] = random.Next(0, 100);
                    matrixB[i, j] = random.Next(0, 100);
                }
            }
            Console.WriteLine("Матрица А:");
            WriteMatrix(matrixA);
            Console.WriteLine("\nМатрица В:");
            WriteMatrix(matrixB);
            Console.WriteLine("\nСумма матриц:");
            for (int i = 0; i < rowMatrix; i++)
            {
                for (int j = 0; j < columnMatrix; j++)
                {
                    matrixC[i, j] = matrixA[i, j] + matrixB[i, j];
                    Console.Write($"{matrixC[i, j]} \t");
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
        static void WriteMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetUpperBound(0) + 1; i++)
            {
                for (int j = 0; j < matrix.GetUpperBound(1) + 1; j++)
                {
                    Console.Write($"{matrix[i, j]} \t");
                }
                Console.WriteLine();
            }
        }
    }
}
