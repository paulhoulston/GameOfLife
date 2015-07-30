namespace GameOfLife
{
    public class LiveCell : IAmACell
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public LiveCell(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}