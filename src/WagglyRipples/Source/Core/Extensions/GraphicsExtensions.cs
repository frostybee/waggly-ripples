﻿using System.Drawing;
using System.Drawing.Drawing2D;

namespace FrostyBee.FriskyRipples.Extensions
{
    internal static class GraphicsExtensions
    {
        public static void SetAntiAliasing(this Graphics graphics)
        {
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphics.CompositingQuality = CompositingQuality.HighQuality;            
        }
    }
}
