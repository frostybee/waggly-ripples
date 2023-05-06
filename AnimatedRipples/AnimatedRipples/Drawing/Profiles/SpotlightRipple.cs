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
    internal class SpotlightRipple : BaseProfile
    {
        //TODO: need to pass an instance of RippleInfo (aka settings).
        public override void Draw(Graphics graphics, Bitmap surface, double progress)
        {
            graphics.Clear(Color.Transparent);
            int baseRadius = 15;
            // Expand the size of the radius.            
            // TODO: ensure that the radius is <= maxRadius.
            //var radius = (int)(animationValue * _baseRadius * 2);
            int radius = Math.Min((int)(progress * baseRadius * 2), surface.Width / 2);
            var opacity = (int)(progress * 45 * 5);            
            Color rippleColor = Color.Crimson.WithOpacity(opacity);
            using (SolidBrush brush = new SolidBrush(rippleColor))
            using (Pen outlinePen = new Pen(Color.Red.WithOpacity(150), 4)) // Pen of the outline
            {
                Rectangle rect = DrawingHelper.CreateRectangle(surface.Width, surface.Height, radius);
                graphics.FillEllipse(brush, rect);
                //graphics.DrawEllipse(outlinePen, rect);                        
                //-- Render drop shadow around the ripple.
                //GraphicsPath path = DrawingHelper.CreateCircle(surface.Width / 2f - radius - 2, surface.Height / 2f - radius, radius);
                //DrawingHelper.drawShadow(graphics, path, 2, Color.DarkRed);
                //graphics.DrawPath(outlinePen, path);
            }
        }
    }
}
