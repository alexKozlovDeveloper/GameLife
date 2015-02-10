using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLife.ViewElements;

namespace GameLife.GameLogic
{
    class Game
    {
        private readonly CellsGrid _grid;

        public Game(CellsGrid grid)
        {
            _grid = grid;

            grid.RandomCellContent();
        }

        public void NextStep()
        {
            var newCells = new List<List<Cell>>();

            for (var i = 0; i < _grid.Cells.Count; i++)
            {
                var items = new List<Cell>();

                for (int j = 0; j < _grid.Cells[i].Count; j++)
                {
                    var item = _grid.Cells[i][j];

                    var nearby = _grid.GetNearbyCells(item);

                    var liveNearby = GetLiveCells(nearby);

                    if (item.Status == CellStatus.Dead && liveNearby == 3)
                    {
                        item.Status = CellStatus.Live;
                    }
                    else if (item.Status == CellStatus.Live && (liveNearby < 2 || liveNearby > 3))
                    {
                        item.Status = CellStatus.Dead;
                    }

                    items.Add(item);
                }
            }

            _grid.Cells = newCells;
        }

        private int GetLiveCells(IEnumerable<Cell> cells)
        {
            var res = 0;

            foreach (var cell in cells)
            {
                if (cell.Status == CellStatus.Live)
                {
                    res++;
                }
            }

            return res;
        }
    }
}
