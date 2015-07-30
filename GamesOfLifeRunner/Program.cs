using System;
using System.Threading;
using GameOfLife;

namespace GamesOfLifeRunner
{
    internal class Program
    {
        private const int GridWidth = 40;
        private const int GridHeight = 25;
        private const int NumberOfIterations = 250;
        private static readonly GridLifecycleManager GridIterator = new GridLifecycleManager(GridWidth, GridHeight);

        private static void Main()
        {
            var grid = new Grid(randomGridCells());
            for (var i = 0; i < NumberOfIterations; i++)
            {
                Console.Clear();
                for (var y = 0; y < GridHeight; y++)
                {
                    Console.WriteLine();
                    for (var x = 0; x < GridWidth; x++)
                    {
                        grid.GetCellState(new Coordinate(x, y), () => Console.Write("X"), () => Console.Write(" "));
                    }
                }
                grid = GridIterator.NextEvolution(grid);
                Thread.Sleep(25);
            }

            Console.WriteLine("\r\n\r\n\r\nPress any key to continue");
            Console.ReadKey();
        }

        private static IAmACell[] randomGridCells()
        {
            var rand = new Random();
            var seedCells = new IAmACell[GridWidth*GridHeight];
            for (var x = 0; x < GridWidth; x++)
                for (var y = 0; y < GridHeight; y++)
                {
                    if (rand.NextDouble() > 0.5)
                        seedCells[x + GridWidth*y] = new LiveCell(x, y);
                    else
                        seedCells[x + GridWidth*y] = new DeadCell(x, y);
                }
            return seedCells;
        }
    }
}