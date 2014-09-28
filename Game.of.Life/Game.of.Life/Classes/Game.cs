namespace GameOfLife.Classes
{
    using System.Collections.Generic;
    using System.Linq;

    public class Game
    {
        private readonly Board _board;

        public Game(uint boardWidth, uint boardHeight, IEnumerable<Cell> initCells)
        {
            _board = new Board(boardWidth, boardHeight, initCells);
        }

        public IEnumerable<string> PlayTurn()
        {
            for (uint x = 0; x < _board.Width; x++)
            {
                for (uint y = 0; y < _board.Height; y++)
                {
                    var cell = _board.GetCell(x, y);

                    if (cell == null)
                    {
                        continue;
                    }

                    var aliveNeighbours = this._board.CountAliveNeighbours(cell);
                    if (cell.IsAlive)
                    {
                        if (aliveNeighbours < 2 || aliveNeighbours > 3)
                        {
                            cell.IsAlive = false;
                        }
                    }
                    else
                    {
                        if (aliveNeighbours == 3)
                        {
                            cell.IsAlive = true;
                        }
                    }
                }
            }

            return _board.Draw();
        }
    }
}
