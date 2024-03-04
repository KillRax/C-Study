using GameOfLifeForms;
using System;
using System.Threading;


namespace ConsoleLife
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Нажмите Enter чтобы начать симуляцию");
            Console.ReadLine();
            Console.SetCursorPosition(0, 0);
            Console.CursorVisible = false;
         
            var gameEngine = new GameEngine
                (
                    rows: 25,
                    cols: 50,
                    density: 3
                );

            while (true)
            {
                var field = gameEngine.GetCurrentGeneration();

                for (int y = 0; y < field.GetLength(1); y++)
                { 
                    var str = new char[field.GetLength(0)];

                    for (int x = 0; x < field.GetLength(0); x++)
                    {
                        if (field[x, y])
                            str[x] = '#';
                        else
                            str[x] = ' ';
                    }
                    Console.WriteLine(str);
                }
                Thread.Sleep(100);
                Console.SetCursorPosition(0, 0);
                gameEngine.NextGeneration();
            }
        }
    }
}
