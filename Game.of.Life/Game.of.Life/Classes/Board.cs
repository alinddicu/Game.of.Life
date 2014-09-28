namespace GameOfLife.Classes
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;

    public class Board
    {
        private readonly uint _height;
        private readonly uint _width;
        private readonly Cell[,] _cells;

        public Board(uint height, uint width, IEnumerable<Cell> aliveCells)
        {
            _height = height;
            _width = width;
            _cells = new Cell[_height, _width];

            VerifyAssignableCells(aliveCells);
            InitAliveCells(aliveCells);
        }

        private void VerifyAssignableCells(IEnumerable<Cell> aliveCells)
        {
            foreach (var aliveCell in aliveCells)
            {
                if (aliveCell.X >= _width || aliveCell.Y >= _height)
                {
                    throw new InvalidDataException(string.Format(CultureInfo.CurrentCulture, "{0} is invalid and cannot be placed on the board", aliveCell));
                }
            }
        }

        private void InitAliveCells(IEnumerable<Cell> aliveCells)
        {
            foreach (var aliveCell in aliveCells)
            {
                _cells[aliveCell.X, aliveCell.Y] = aliveCell;
            }
        }

        private IEnumerable<Cell> GetNeighbours(Cell cell)
        {
            for (var i = (int)cell.X - 1; i < (int)cell.X + 1; i++)
            {
                for (var j = (int)cell.Y - 1; j < (int)cell.Y + 1; j++)
                {
                    if (!this.CoordsAreInBoard(i, j))
                    {
                        continue;
                    }

                    var foundCell = new Cell((uint)i, (uint)j);

                    if (foundCell != cell)
                    {
                        yield return foundCell;
                    }
                }
            }
        }

        public IEnumerable<Cell> GetAliveNeighbours(Cell cell)
        {
            return this.GetNeighbours(cell).Where(c => c.IsAlive);
        }

        public IEnumerable<Cell> GetDeadNeighbours(Cell cell)
        {
            return this.GetNeighbours(cell).Where(c => !c.IsAlive);
        }

        private bool CoordsAreInBoard(int x, int y)
        {
            return x >= 0 && x < _width && y >= 0 && y < _height;
        }
    }
}
