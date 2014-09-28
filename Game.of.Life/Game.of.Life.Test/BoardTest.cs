namespace GameOfLife.Test
{
    using System.Collections.Generic;

    using GameOfLife.Classes;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using NFluent;

    [TestClass]
    public class BoardTest
    {
        [TestMethod]
        public void Given1AliveNeighbourThenReturn1AliveNeighbour()
        {
            var cell1 = new Cell(1, 1);
            var cell2 = new Cell(1, 2) { IsAlive = true };

            var activeCells = new List<Cell> { cell1, cell2 };
            var board = new Board(3, 3, activeCells);

            var aliveNeighbours = board.CountAliveNeighbours(cell1);

            Check.That(aliveNeighbours).Equals(1);
        }

        [TestMethod]
        public void Given2AliveNeighboursThenReturn2AliveNeighbours()
        {

            var cell0 = new Cell(1, 0) { IsAlive = true };
            var cell1 = new Cell(1, 1);
            var cell2 = new Cell(1, 2) { IsAlive = true };

            var activeCells = new List<Cell> {cell0, cell1, cell2 };
            var board = new Board(3, 3, activeCells);

            var aliveNeighbours = board.CountAliveNeighbours(cell1);

            Check.That(aliveNeighbours).Equals(2);
        }

        [TestMethod]
        public void Given3AliveNeighboursThenReturn3AliveNeighbours()
        {
            var cell0 = new Cell(0, 0);
            var cell3 = new Cell(0, 1) { IsAlive = true };
            var cell1 = new Cell(1, 0) { IsAlive = true };
            var cell2 = new Cell(1, 1) { IsAlive = true };

            var activeCells = new List<Cell> { cell0, cell1, cell2, cell3 };
            var board = new Board(3, 3, activeCells);

            var aliveNeighbours = board.CountAliveNeighbours(cell0);

            Check.That(aliveNeighbours).Equals(3);
        }
    }
}
