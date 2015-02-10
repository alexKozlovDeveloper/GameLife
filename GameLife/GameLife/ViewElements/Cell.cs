using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using GameLife.GameLogic;

namespace GameLife.ViewElements
{
    class Cell
    {
        private readonly int _width;
        private readonly int _height;

        private int _x;
        private int _y;

        private Grid _grid;
        readonly Rectangle _rectangle;

        private CellStatus _status;

        public Cell(int h, int w, int x, int y, Grid grid, CellStatus status)
        {
            _width = w;
            _height = h;

            _x = x;
            _y = y;

            _grid = grid;

            _status = status;

            _rectangle = new Rectangle
            {
                Width = _width,
                Height = _height,
                Margin = new Thickness(Xpixel, Ypixel, 0, 0)
            };
            
            _grid.Children.Add(_rectangle);

            this.SetColor();
        }

        public void SetColor()
        {
            _rectangle.Fill = new SolidColorBrush(CellStatusColors.GetColorFromStatus(Status));
        }

        public CellStatus Status
        {
            get
            {
                return _status; 
            }
            set
            {
                _status = value;
                this.SetColor();
            }
        }

        public int Xpixel
        {
            get { return _x * _width; }
            set { _x = value; }
        }

        public int Ypixel
        {
            get { return _y * _height; }
            set { _y = value; }
        }

        public int X
        {
            get { return _x; }
            set { _x = value; }
        }

        public int Y
        {
            get { return _y; }
            set { _y = value; }
        }
    }
}
