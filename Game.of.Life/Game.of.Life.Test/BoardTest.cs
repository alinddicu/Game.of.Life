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
            var cell2 = new Cell(1, 2);
            cell2.IsAlive = true;
            var activeCells = new List<Cell> { cell1, cell2 };
            var board = new Board(3, 3, activeCells);

            var aliveNeighbours = board.CountAliveNeighbours(cell1);

            Check.That(aliveNeighbours).Equals(1);
        }
    }
}
