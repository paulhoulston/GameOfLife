using NUnit.Framework;

namespace GameOfLife
{
    /*
     *  The universe of the Game of Life is an infinite two-dimensional orthogonal grid of square cells, each of which is in one of
     *  two possible states, alive or dead. Every cell interacts with its eight neighbours, which are the cells that are horizontally,
     *  vertically, or diagonally adjacent. At each step in time, the following transitions occur:
     *  
     *      -   Any live cell with fewer than two live neighbours dies, as if caused by under-population.
     *      -   Any live cell with two or three live neighbours lives on to the next generation.
     *      -   Any live cell with more than three live neighbours dies, as if by overcrowding.
     *      -   Any dead cell with exactly three live neighbours becomes a live cell, as if by reproduction.
     */

    public class Given_I_have_a_live_cell
    {
        private const int GridWidth = 3;
        private const int GridHeight = 3;
        private static readonly GridLifecycleManager GridIterator = new GridLifecycleManager(GridWidth, GridHeight);

        public class When_the_cell_no_live_neighbours
        {
            [Test]
            public void Then_the_cell_dies()
            {
                var cellAlive = false;
                var startingGrid = new Grid(new LiveCell(0, 0));
                GridIterator.NextEvolution(startingGrid).GetCellState(new Coordinate(0, 0), () => cellAlive = true, () => cellAlive = false);
                Assert.IsFalse(cellAlive);
            }
        }

        public class When_the_cell_has_one_live_neighbour
        {
            [Test]
            public void Then_the_cell_dies()
            {
                var cellAlive = false;
                var startingGrid = new Grid(new LiveCell(0, 0), new LiveCell(0, 1));
                GridIterator.NextEvolution(startingGrid).GetCellState(new Coordinate(0, 0), () => cellAlive = true, () => cellAlive = false);
                Assert.IsFalse(cellAlive);
            }
        }

        public class When_the_cell_has_two_horizontal_live_neighbours
        {
            [Test]
            public void Then_the_cell_is_alive()
            {
                var cellAlive = false;
                var startingGrid = new Grid(new LiveCell(0, 0), new LiveCell(1, 0), new LiveCell(2, 0));
                GridIterator.NextEvolution(startingGrid).GetCellState(new Coordinate(1, 0), () => cellAlive = true, () => cellAlive = false);
                Assert.IsTrue(cellAlive);

            }
        }

        public class When_the_cell_has_two_vertical_live_neighbours
        {
            [Test]
            public void Then_the_cell_is_alive()
            {
                var cellAlive = false;
                var startingGrid = new Grid(new LiveCell(0, 0), new LiveCell(0, 1), new LiveCell(0, 2));
                GridIterator.NextEvolution(startingGrid).GetCellState(new Coordinate(0, 1), () => cellAlive = true, () => cellAlive = false);
                Assert.IsTrue(cellAlive);
            }
        }

        public class When_the_cell_has_two_diagonal_live_neighbours_going_north_east_to_south_west
        {
            [Test]
            public void Then_the_cell_is_alive()
            {
                var cellAlive = false; 
                var startingGrid = new Grid(new LiveCell(0, 0), new LiveCell(1, 1), new LiveCell(2, 2));
                GridIterator.NextEvolution(startingGrid).GetCellState(new Coordinate(1, 1), () => cellAlive = true, () => cellAlive = false);
                Assert.IsTrue(cellAlive);
            }
        }

        public class When_the_cell_has_two_diagonal_live_neighbours_going_north_west_to_south_east
        {
            [Test]
            public void Then_the_cell_is_alive()
            {
                var cellAlive = false;
                var startingGrid = new Grid(new LiveCell(2, 0), new LiveCell(1, 1), new LiveCell(0, 2));
                GridIterator.NextEvolution(startingGrid).GetCellState(new Coordinate(1, 1), () => cellAlive = true, () => cellAlive = false);
                Assert.IsTrue(cellAlive);
            }
        }

        public class When_the_cell_has_any_2_live_neighbours
        {
            [Test]
            public void Then_the_cell_is_alive()
            {
                var cellAlive = false;
                var startingGrid = new Grid(new LiveCell(0, 0), new LiveCell(1, 0), new LiveCell(0, 1));
                GridIterator.NextEvolution(startingGrid).GetCellState(new Coordinate(0, 0), () => cellAlive = true, () => cellAlive = false);
                Assert.IsTrue(cellAlive);
            }
        }

        public class When_the_cell_has_with_any_3_live_neighbours
        {
            [Test]
            public void Then_the_cell_is_alive()
            {
                var cellAlive = false;
                var startingGrid = new Grid(new LiveCell(0, 0), new LiveCell(1, 0), new LiveCell(0, 1), new LiveCell(1, 1));
                GridIterator.NextEvolution(startingGrid).GetCellState(new Coordinate(1, 1), () => cellAlive = true, () => cellAlive = false);
                Assert.IsTrue(cellAlive);
            }
        }

        public class When_the_cell_has_4_live_neighbours
        {
            [Test]
            public void Then_the_cell_is_dead()
            {
                var cellAlive = false;
                var startingGrid = new Grid(new LiveCell(1, 0), new LiveCell(0, 1), new LiveCell(1, 1), new LiveCell(2, 1), new LiveCell(1, 2));
                GridIterator.NextEvolution(startingGrid).GetCellState(new Coordinate(1, 1), () => cellAlive = true, () => cellAlive = false);
                Assert.IsFalse(cellAlive);
            }
        }

        public class When_the_cell_has_5_live_neighbours
        {
            [Test]
            public void Then_the_cell_is_dead()
            {
                var cellAlive = false;
                var startingGrid = new Grid(new LiveCell(1, 0), new LiveCell(0, 1), new LiveCell(1, 1), new LiveCell(2, 1), new LiveCell(1, 2), new LiveCell(0, 0));
                GridIterator.NextEvolution(startingGrid).GetCellState(new Coordinate(1, 1), () => cellAlive = true, () => cellAlive = false);
                Assert.IsFalse(cellAlive);
            }
        }

        public class When_the_cell_has_6_live_neighbours
        {
            [Test]
            public void Then_the_cell_is_dead()
            {
                var cellAlive = false;
                var startingGrid = new Grid(new LiveCell(1, 0), new LiveCell(0, 1), new LiveCell(1, 1), new LiveCell(2, 1), new LiveCell(1, 2), new LiveCell(0, 0), new LiveCell(2, 0));
                GridIterator.NextEvolution(startingGrid).GetCellState(new Coordinate(1, 1), () => cellAlive = true, () => cellAlive = false);
                Assert.IsFalse(cellAlive);
            }
        }

        public class When_the_cell_has_7_live_neighbours
        {
            [Test]
            public void Then_the_cell_is_dead()
            {
                var cellAlive = false;
                var startingGrid = new Grid(new LiveCell(1, 0), new LiveCell(0, 1), new LiveCell(1, 1), new LiveCell(2, 1), new LiveCell(1, 2), new LiveCell(0, 0), new LiveCell(2, 0), new LiveCell(0, 2));
                GridIterator.NextEvolution(startingGrid).GetCellState(new Coordinate(1, 1), () => cellAlive = true, () => cellAlive = false);
                Assert.IsFalse(cellAlive);
            }
        }

        public class When_the_cell_has_8_live_neighbours
        {
            [Test]
            public void Then_the_cell_is_dead()
            {
                var cellAlive = false;
                var startingGrid = new Grid(new LiveCell(1, 0), new LiveCell(0, 1), new LiveCell(1, 1), new LiveCell(2, 1), new LiveCell(1, 2), new LiveCell(0, 0), new LiveCell(2, 0), new LiveCell(0, 2), new LiveCell(2, 2));
                GridIterator.NextEvolution(startingGrid).GetCellState(new Coordinate(1, 1), () => cellAlive = true, () => cellAlive = false);
                Assert.IsFalse(cellAlive);
            }
        }
    }

    public class Given_I_have_a_dead_cell
    {
        private const int GridWidth = 3;
        private const int GridHeight = 3;
        private static readonly GridLifecycleManager GridIterator = new GridLifecycleManager(GridWidth, GridHeight);

        public class When_the_cell_has_any_no_live_neighbours
        {
            [Test]
            public void Then_the_cell_is_dead()
            {
                var cellAlive = false;
                var startingGrid = new Grid();
                GridIterator.NextEvolution(startingGrid).GetCellState(new Coordinate(0, 0), () => cellAlive = true, () => cellAlive = false);
                Assert.IsFalse(cellAlive);
            }
        }

        public class When_the_cell_has_any_1_live_neighbour
        {
            [Test]
            public void Then_the_cell_is_dead()
            {
                var cellAlive = false;
                var startingGrid = new Grid(new LiveCell(0, 0));
                GridIterator.NextEvolution(startingGrid).GetCellState(new Coordinate(1, 1), () => cellAlive = true, () => cellAlive = false);
                Assert.IsFalse(cellAlive);
            }
        }

        public class When_the_cell_has_any_2_live_neighbours
        {
            [Test]
            public void Then_the_cell_is_dead()
            {
                var cellAlive = false;
                var startingGrid = new Grid(new LiveCell(0, 0), new LiveCell(2, 2));
                GridIterator.NextEvolution(startingGrid).GetCellState(new Coordinate(1, 1), () => cellAlive = true, () => cellAlive = false);
                Assert.IsFalse(cellAlive);
            }
        }

        public class When_the_cell_has_with_any_3_live_neighbours
        {
            [Test]
            public void Then_the_cell_is_alive()
            {
                var cellAlive = false;
                var startingGrid = new Grid(new LiveCell(0, 0), new LiveCell(1, 0), new LiveCell(0, 1));
                GridIterator.NextEvolution(startingGrid).GetCellState(new Coordinate(1, 1), () => cellAlive = true, () => cellAlive = false);
                Assert.IsTrue(cellAlive);
            }
        }

        public class When_the_cell_has_4_live_neighbours
        {
            [Test]
            public void Then_the_cell_is_dead()
            {
                var cellAlive = false;
                var startingGrid = new Grid(new LiveCell(1, 0), new LiveCell(0, 1), new LiveCell(2, 1), new LiveCell(1, 2));
                GridIterator.NextEvolution(startingGrid).GetCellState(new Coordinate(1, 1), () => cellAlive = true, () => cellAlive = false);
                Assert.IsFalse(cellAlive);
            }
        }

        public class When_the_cell_has_5_live_neighbours
        {
            [Test]
            public void Then_the_cell_is_dead()
            {
                var cellAlive = false;
                var startingGrid = new Grid(new LiveCell(1, 0), new LiveCell(0, 1), new LiveCell(2, 1), new LiveCell(1, 2), new LiveCell(0, 0));
                GridIterator.NextEvolution(startingGrid).GetCellState(new Coordinate(1, 1), () => cellAlive = true, () => cellAlive = false);
                Assert.IsFalse(cellAlive);
            }
        }

        public class When_the_cell_has_6_live_neighbours
        {
            [Test]
            public void Then_the_cell_is_dead()
            {
                var cellAlive = false;
                var startingGrid = new Grid(new LiveCell(1, 0), new LiveCell(0, 1), new LiveCell(2, 1), new LiveCell(1, 2), new LiveCell(0, 0), new LiveCell(2, 0));
                GridIterator.NextEvolution(startingGrid).GetCellState(new Coordinate(1, 1), () => cellAlive = true, () => cellAlive = false);
                Assert.IsFalse(cellAlive);
            }
        }

        public class When_the_cell_has_7_live_neighbours
        {
            [Test]
            public void Then_the_cell_is_dead()
            {
                var cellAlive = false;
                var startingGrid = new Grid(new LiveCell(1, 0), new LiveCell(0, 1), new LiveCell(2, 1), new LiveCell(1, 2), new LiveCell(0, 0), new LiveCell(2, 0), new LiveCell(0, 2));
                GridIterator.NextEvolution(startingGrid).GetCellState(new Coordinate(1, 1), () => cellAlive = true, () => cellAlive = false);
                Assert.IsFalse(cellAlive);
            }
        }

        public class When_the_cell_has_8_live_neighbours
        {
            [Test]
            public void Then_the_cell_is_dead()
            {
                var cellAlive = false;
                var startingGrid = new Grid(new LiveCell(1, 0), new LiveCell(0, 1), new LiveCell(2, 1), new LiveCell(1, 2), new LiveCell(0, 0), new LiveCell(2, 0), new LiveCell(0, 2), new LiveCell(2, 2));
                GridIterator.NextEvolution(startingGrid).GetCellState(new Coordinate(1, 1), () => cellAlive = true, () => cellAlive = false);
                Assert.IsFalse(cellAlive);
            }
        }
    }
}