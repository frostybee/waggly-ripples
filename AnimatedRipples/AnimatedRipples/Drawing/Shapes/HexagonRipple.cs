using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormLayered.Drawing.Shapes;

namespace WinFormLayered.Drawing
{
    internal class HexagonRipple : BaseProfile
    {
        //TODO: need to pass an instance of RippleInfo (aka settings).
        public override void Draw(Graphics graphics, Bitmap surface, double progress)
        {
            graphics.Clear(Color.Transparent);
            int baseRadius = 15;
            int strokeWidth = 4;
            //Get the middle of the panel
            var x = surface.Width / 2;
            var y = surface.Height / 2;            
            var shapes = new PointF[6];            
            int radius = Math.Min((int)(progress * baseRadius * 2), surface.Width / 2);
            // TODO: implement GetCurrentRaius(); in the BaseProfile
            //Create 6 points
            for (int line = 0; line < shapes.Length; line++)
            {  //- TODO: put this in a method. We need to create the shapes once and update the radius on animation progress.              
                shapes[line] = new PointF(
                    x + radius * (float)Math.Cos(line * 60 * Math.PI / 180f),
                    y + radius * (float)Math.Sin(line * 60 * Math.PI / 180f));
            }
            graphics.DrawPolygon(new Pen(Brushes.Red, strokeWidth), shapes);

        }
    }
}
