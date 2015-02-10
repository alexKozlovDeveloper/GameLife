using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using GameLife.GameLogic;

namespace GameLife.ViewElements
{
    class CellsGrid
    {
        private List<List<Cell>> _cells;
        private Grid _grid;

        private readonly int _widthCount;
        private readonly int _heightCount;

        private const int CellWidth = 10;
        private const int CellHeight = 10;

        private Random _rnd;

        public CellsGrid(int wCount, int hCount, Grid grid)
        {
            _grid = grid;

            _widthCount = wCount;
            _heightCount = hCount;

            _cells = new List<List<Cell>>();
            _rnd = new Random();

            for (var i = 0; i < _widthCount; i++)
            {
                var list = new List<Cell>();

                for (int j = 0; j < _heightCount; j++)
                {
                    list.Add(new Cell(CellWidth, CellHeight, i, j, _grid, CellStatus.Dead));
                }

                _cells.Add(list);
            }

            _grid.Width = GridWidth;
            _grid.Height = GridHeight;
        }

        public int GridWidth
        {
            get { return _widthCount * CellWidth; }
        }

        public int GridHeight
        {
            get { return _heightCount * CellHeight; }
        }

        public List<List<Cell>> Cells
        {
            get { return _cells; }
            set { _cells = value; }
        }

        public void RandomCellContent()
        {
            foreach (var cell in _cells)
            {
                foreach (var obj in cell)
                {
                    obj.Status = _rnd.Next(2) == 0 ? CellStatus.Dead : CellStatus.Live;
                }
            }
        }

        public List<Cell> GetNearbyCells(Cell cell)
        {
            var result = new List<Cell>();

            AddCell(cell.X-1, cell.Y-1, result);
            AddCell(cell.X-1, cell.Y, result);
            AddCell(cell.X-1, cell.Y+1, result);
            AddCell(cell.X, cell.Y+1, result);
            AddCell(cell.X+1, cell.Y+1, result);
            AddCell(cell.X+1, cell.Y, result);
            AddCell(cell.X+1, cell.Y-1, result);
            AddCell(cell.X, cell.Y-1, result);

            return result;
        }

        public Cell GetCell(int x, int y)
        {
            if (x >= 0 && x < _cells.Count)
            {
                if (y >= 0 && y < _cells[x].Count)
                {
                    return _cells[x][y];
                }
            }

            return null;
        }

        private void AddCell(int x, int y, List<Cell> cells)
        {
            var item = GetCell(x, y);

            if (item != null)
            {
                cells.Add(item);
            }
        }
    }
}
