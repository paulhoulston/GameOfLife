using System.Collections.Generic;
using System.Linq;

namespace GameOfLife
{
    public class GridLifecycleManager
    {
        private readonly int _width;
        private readonly int _height;

        public GridLifecycleManager(int width, int height)
        {
            _width = width;
            _height = height;
        }

        public Grid NextEvolution(Grid grid)
        {
            var array = new IAmACell[_width*_height];
            for (var y = 0; y < _height; y++)
                for (var x = 0; x < _width; x++)
                {
                    var coordinate = new Coordinate(x, y);
                    grid.GetCellState(coordinate,
                        () => array[coordinate.X + _width * coordinate.Y] = whenCurrentCellisAlive(coordinate, grid),
                        () => array[coordinate.X + _width * coordinate.Y] = whenCurrentCellIsDead(coordinate, grid));
                }
            return new Grid(array);
        }

        private static IAmACell whenCurrentCellisAlive(Coordinate coordinate, Grid grid)
        {
            if (hasTwoOrThreeNeighbours(grid, coordinate))
            {
                return new LiveCell(coordinate.X, coordinate.Y);
            }
            return new DeadCell(coordinate.X, coordinate.Y);
        }

        private static bool hasTwoOrThreeNeighbours(Grid grid, Coordinate coordinate)
        {
            return Enumerable.Range(2, 2).Contains(numberOfLiveNeighbours(grid, coordinate));
        }

        private static IAmACell whenCurrentCellIsDead(Coordinate coordinate, Grid grid)
        {
            if (hasThreeNeighbours(grid, coordinate))
            {
                return new LiveCell(coordinate.X, coordinate.Y);
            }
            return new DeadCell(coordinate.X, coordinate.Y);
        }

        private static bool hasThreeNeighbours(Grid grid, Coordinate coordinate)
        {
            return numberOfLiveNeighbours(grid, coordinate) == 3;
        }

        private static int numberOfLiveNeighbours(Grid grid, Coordinate coordinate)
        {
            var liveCellCount = 0;
            foreach (var coord in neighbouringCoordinates(coordinate))
                grid.GetCellState(coord, () => liveCellCount++, () => { });
            return liveCellCount;
        }

        private static IEnumerable<Coordinate> neighbouringCoordinates(Coordinate coordinate)
        {
            return new List<Coordinate>
            {
                new Coordinate(coordinate.X, coordinate.Y - 1),
                new Coordinate(coordinate.X, coordinate.Y + 1),
                new Coordinate(coordinate.X - 1, coordinate.Y),
                new Coordinate(coordinate.X + 1, coordinate.Y),
                new Coordinate(coordinate.X + 1, coordinate.Y - 1),
                new Coordinate(coordinate.X + 1, coordinate.Y + 1),
                new Coordinate(coordinate.X - 1, coordinate.Y - 1),
                new Coordinate(coordinate.X - 1, coordinate.Y + 1)
            };
        }
    }
}