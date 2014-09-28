namespace GameOfLife.Classes
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class Board
    {
        private readonly uint _height;
        private readonly uint _width;
        private readonly Cell[,] _cells;

        public Board(uint height, uint width, IEnumerable<Cell> aliveCells)
        {
            this._height = height;
            this._width = width;
            _cells = new Cell[this.Height, this.Width];

            VerifyAssignableCells(aliveCells);
            InitAliveCells(aliveCells);
        }

        public uint Height
        {
            get
            {
                return _height;
            }
        }

        public uint Width
        {
            get
            {
                return _width;
            }
        }

        private void VerifyAssignableCells(IEnumerable<Cell> aliveCells)
        {
            foreach (var aliveCell in aliveCells)
            {
                if (aliveCell.X >= this.Width || aliveCell.Y >= this.Height)
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

                    var foundCell = _cells[(uint)i, (uint)j];
                    if (foundCell != null && foundCell != cell)
                    {
                        yield return foundCell;
                    }
                }
            }
        }

        public int CountAliveNeighbours(Cell cell)
        {
            return GetNeighbours(cell).Count(c => c.IsAlive);
        }

        public Cell GetCell(uint x, uint y)
        {
            return _cells[x, y];
        }

        private bool CoordsAreInBoard(int x, int y)
        {
            return x >= 0 && x < this.Width && y >= 0 && y < this.Height;
        }

        public IEnumerable<string> Draw()
        {
            var line = new StringBuilder();

            for (uint x = 0; x < Width; x++)
            {
                for (uint y = 0; y < Height; y++)
                {
                    var cell = GetCell(x, y);

                    if (cell == null)
                    {
                        line.Append("X");
                    }
                    else if (cell.IsAlive)
                    {
                        line.Append("1");
                    }
                    else
                    {
                        line.Append("0");
                    }
                }

                yield return line.ToString();
                line.Clear();
            }
        }
    }
}
