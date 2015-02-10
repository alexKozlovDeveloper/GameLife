using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GameLife.GameLogic;
using GameLife.ViewElements;

namespace GameLife
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Game _game;
        private Thread _liveTread;

        public MainWindow()
        {
            InitializeComponent();
            
            _game = new Game(new CellsGrid(10, 10, CellsGrid));
            
            var liveTread = new Thread(new ThreadStart(LiveTread));

            liveTread.Start();
        }

        private void LiveTread()
        {
            _game.NextStep();
            Thread.Sleep(1000);
        }
    }
}
