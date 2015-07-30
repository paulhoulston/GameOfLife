using System;
using System.Linq;

namespace GameOfLife
{
    public class Grid
    {
        private readonly IAmACell[] _cells;

        public Grid(params IAmACell[] cells)
        {
            _cells = cells;
        }

        public void GetCellState(Coordinate coordinate, Action onCellAlive, Action onCellDead)
        {
            if (isLiveCell(coordinate))
                onCellAlive();
            else
                onCellDead();
        }

        private bool isLiveCell(Coordinate coordinate)
        {
            return _cells.FirstOrDefault(cell => cell.X == coordinate.X && cell.Y == coordinate.Y) is LiveCell;
        }
    }
}