namespace GameOfLife
{
    using System;
    using System.Collections.Generic;
    using System.Threading;

    using GameOfLife.Classes;

    public class Program
    {
        public static void Main(string[] args)
        {
            var cells = new List<Cell>
                            {
                                new Cell(11, 9), new Cell(11, 10), new Cell(11, 11), new Cell(11, 12),
                                                 new Cell(12, 10), new Cell(13, 10), new Cell(14, 10),
                                                 new Cell(12, 11), new Cell(13, 11), new Cell(14, 11),
                                                 new Cell(12, 12), new Cell(13, 12), new Cell(14, 12)
                            };

            var game = new Game(27, 27, cells);

            while (true)
            {
                var boardLines = game.PlayTurn();

                foreach (var line in boardLines)
                {
                    Console.WriteLine(line);
                }

                Thread.Sleep(1000);
                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}
