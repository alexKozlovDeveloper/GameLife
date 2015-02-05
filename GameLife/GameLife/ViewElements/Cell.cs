using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace GameLife.ViewElements
{
    class Cell
    {
        private int _width;
        private int _height;

        private Grid _grid;
        Rectangle _rectangle;

        public Cell(int h, int w, int x, int y, Grid grid)
        {
            _width = w;
            _height = h;

            _grid = grid;

            _rectangle = new Rectangle();

            _rectangle.Width = _width;
            _rectangle.Height = _height;

            //_rectangle.Margin

            //_grid.Cohildren.Add(_rectangle);

            //_rectangle.Fill = new SolidColorBrush(System.Windows.Media.Colors.Green); 
        }

        public void SetColor(Color color)
        { 
            _rectangle.Fill = new SolidColorBrush(color); 
        }
    }
}
