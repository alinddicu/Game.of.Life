namespace GameOfLife.Test
{
    using System.Collections.Generic;

    using GameOfLife.Classes;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using NFluent;

    [TestClass]
    public class CellTest
    {
        [TestMethod]
        public void GivenXequalsXandYequalsYThenCellsAreEqual()
        {
            var cell1 = new Cell(1, 1);
            var cell2 = new Cell(1, 1);

            Check.That(cell1).Equals(cell2);
        }

        [TestMethod]
        public void GivenCellInListThenListContainsCell()
        {
            var cell1 = new Cell(1, 1);
            var list = new List<Cell> { new Cell(1, 1) };

            Check.That(list).Contains(cell1);
        }
    }
}
