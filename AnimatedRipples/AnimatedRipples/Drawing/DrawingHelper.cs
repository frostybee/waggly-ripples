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
        public static Color EvaluateTransitionColor(float fraction, int startValue, int endValue)
        {
            int startA = (startValue >> 24) & 0xff;
            int startR = (startValue >> 16) & 0xff;
            int startG = (startValue >> 8) & 0xff;
            int startB = startValue & 0xff;

            int endA = (endValue >> 24) & 0xff;
            int endR = (endValue >> 16) & 0xff;
            int endG = (endValue >> 8) & 0xff;
            int endB = endValue & 0xff;

            return Color.FromArgb(((startA + (int)(fraction * (endA - startA))) << 24),
                        ((startR + (int)(fraction * (endR - startR))) << 16),
                        ((startG + (int)(fraction * (endG - startG))) << 8),
                    ((startB + (int)(fraction * (endB - startB))))
                    );
        }
    }
}
