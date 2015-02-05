using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace GameLife.ViewElements
{
    class CellsGrid
    {
        private List<List<Cell>> _cells;
        private Grid _grid;

        private int _widthCount;
        private int _heightCount;

        private int cellWidth = 10;
        private int cellHeight = 10;

        public CellsGrid(int wCount, int hCount, Grid grid)
        {
            _grid = grid;

            _widthCount = wCount;
            _heightCount = hCount;

            _cells = new List<List<Cell>>();

            for (int i = 0; i < _widthCount; i++)
            {
                var list = new List<Cell>();

                for (int j = 0; j < _heightCount; j++)
                {
                    list.Add(new Cell(cellWidth, cellHeight, i, j, _grid));
                }

                _cells.Add(list);
            }

            _grid.Width = GridWidth;
            _grid.Height = GridHeight;
        }

        public int GridWidth
        {
            get { return _widthCount * cellWidth; } 
        }

        public int GridHeight
        {
            get { return _heightCount * cellHeight; } 
        }
    }
}
