using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormLayered.Drawing.Extensions;

namespace WinFormLayered.Drawing
{
    internal class StarRipple : BaseProfile
    {
        public StarRipple()
        {
        }

        public  void Draw(Graphics graphics, Bitmap surface, double progress)
        {
            graphics.Clear(Color.Transparent);
            graphics.SetAntiAliasing();            
            double radiusSize = Convert.ToDouble(40 * progress);
            int opacity = (int)(progress * 100 *2);
            double middleX = surface.Width/2;
            double middleY = surface.Width / 2;
            double min = 0.05f;
            double half = radiusSize;
            middleX = middleX - half;
            middleY = middleY - half;
            //TODO: put this in a helper class. Needs to be adjustable.
            // Create an array of points.
            Point[] myArray =
                     {
                 new Point(Convert.ToInt32(middleX + half * (0.5 + min)), Convert.ToInt32(middleY + half * (0.84 + min))),
                 new Point(Convert.ToInt32(middleX + half * (1.5f + min)), Convert.ToInt32(middleY + half * (0.84f + min))),
                 new Point(Convert.ToInt32(middleX + half * (0.68f + min)), Convert.ToInt32(middleY + half * (1.45f + min))),                 
                 new Point(Convert.ToInt32(middleX + half * (1.0f + min)), Convert.ToInt32(middleY + half * (0.5f + min))),                 
                 new Point(Convert.ToInt32(middleX + half * (1.32f + min)), Convert.ToInt32(middleY + half * (1.45f + min))),                 
                 new Point(Convert.ToInt32(middleX + half * (0.5f + min)), Convert.ToInt32(middleY + half * (0.84f + min))),                 
             };

            // Create a GraphicsPath object and add a polygon.
            GraphicsPath myPath = new GraphicsPath();
            myPath.AddPolygon(myArray);            
            Color starColor = Color.FromArgb(255 - Math.Min(opacity, 255), Color.Crimson);
            //Color starColor = Color.FromArgb(230, Color.Crimson);
            //Color starColor = Color.FromArgb(255 - Math.Min((int)progress * 100*20, 200), Color.Crimson);
            // Render the path to the screen.
            Pen myPen = new Pen(starColor, 5);
            graphics.DrawPath(myPen, myPath);
        }
    }
}
