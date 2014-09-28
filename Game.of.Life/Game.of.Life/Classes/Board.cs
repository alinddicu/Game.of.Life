namespace GameOfLife.Classes
{
    public class Board
    {
        private int _height;

        private int _width;

        private Cell[,] _cells;

        public Board(int height, int width)
        {
            _height = height;
            _width = width;
            _cells = new Cell[_height, _width];
        }
    }
}
