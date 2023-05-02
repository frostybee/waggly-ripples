using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormLayered.Drawing.Shapes
{
    internal static class ColorExtensions
    {
        public static Color WithOpacity(this Color inColor, int opacity)
        {
            return Color.FromArgb(255 - Math.Min(Math.Max(0,opacity), 255), inColor);
        }

    }
}
