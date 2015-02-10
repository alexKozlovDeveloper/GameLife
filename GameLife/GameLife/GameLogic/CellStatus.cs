using System.Collections.Generic;
using System.Windows.Media;

namespace GameLife.GameLogic
{
    enum CellStatus
    {
        Live,
        Dead
    }

    static class CellStatusColors
    {
        private static readonly Dictionary<CellStatus, Color> Colors;

        static CellStatusColors()
        {
            Colors = new Dictionary<CellStatus, Color>
            {
                {CellStatus.Live, System.Windows.Media.Colors.Green},
                {CellStatus.Dead, System.Windows.Media.Colors.GhostWhite}
            };
        }

        public static Color GetColorFromStatus(CellStatus status)
        {
            return Colors[status];
        }
    }
}
