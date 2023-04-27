using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormLayered.Drawing
{
    internal class DrawingHelper
    {
        
        /// <summary>
        /// Creates a bounding rectangle that bounds a ripple drawing.
        /// </summary>
        /// <param name="rippleRadius"></param>
        /// <returns></returns>
        internal static Rectangle CreateRectangle(int width, int height, int radius)
        {            
            return new Rectangle(width / 2 - radius, height / 2 - radius, radius * 2, radius * 2);            
        }
        internal static void SetAntiAliasing(System.Drawing.Graphics graphics)
        {
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphics.CompositingQuality = CompositingQuality.HighQuality;
        }
    }
}
