using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormLayered.Drawing
{
    internal class StarRipple : BaseRipple
    {
        public StarRipple()
        {
        }

        public override void Draw(Graphics graphics, Bitmap surface, double progress)
        {
            graphics.Clear(Color.Transparent);
            DrawingHelper.SetAntiAliasing(graphics);    
            double radiusSize = Convert.ToDouble(70 * progress);
            double middleHorizontal = surface.Width/2;
            double middleVertical = surface.Width / 2;
            double min = 0.0f;
            double half = radiusSize;
            middleHorizontal = middleHorizontal - half;
            middleVertical = middleVertical - half;
            
            // Create an array of points.
            Point[] myArray =
                     {
                 new Point(Convert.ToInt32(middleHorizontal + half * (0.5 + min)), Convert.ToInt32(middleVertical + half * (0.84 + min))),
                 new Point(Convert.ToInt32(middleHorizontal + half * (1.5f + min)), Convert.ToInt32(middleVertical + half * (0.84f + min))),
                 new Point(Convert.ToInt32(middleHorizontal + half * (0.68f + min)), Convert.ToInt32(middleVertical + half * (1.45f + min))),                 
                 new Point(Convert.ToInt32(middleHorizontal + half * (1.0f + min)), Convert.ToInt32(middleVertical + half * (0.5f + min))),                 
                 new Point(Convert.ToInt32(middleHorizontal + half * (1.32f + min)), Convert.ToInt32(middleVertical + half * (1.45f + min))),                 
                 new Point(Convert.ToInt32(middleHorizontal + half * (0.5f + min)), Convert.ToInt32(middleVertical + half * (0.84f + min))),                 
             };

            // Create a GraphicsPath object and add a polygon.
            GraphicsPath myPath = new GraphicsPath();
            myPath.AddPolygon(myArray);
            Color starColor = Color.FromArgb(230, Color.Crimson);
            // Draw the path to the screen.
            Pen myPen = new Pen(starColor, 5);
            graphics.DrawPath(myPen, myPath);
        }
    }
}
