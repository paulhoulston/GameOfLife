namespace GameOfLife
{
    public class DeadCell : IAmACell
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public DeadCell(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}