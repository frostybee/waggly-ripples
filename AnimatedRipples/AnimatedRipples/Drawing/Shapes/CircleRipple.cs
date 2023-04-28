using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormLayered.Drawing
{
    internal class CircleRipple : BaseRipple
    {
        //TODO: need to pass an instance of RippleInfo (aka settings).
        public override void Draw(Graphics graphics, Bitmap surface, double progress)
        {
            graphics.Clear(Color.Transparent);            
            int baseRadius = 15;
            // Expand the size of the radius.            
            // TODO: ensure that the radius is <= maxRadius.
            //var radius = (int)(animationValue * baseRadius * 2);
            int radius = Math.Min((int)(progress * baseRadius * 2), surface.Width / 2);            
            var opacity = (int)(progress * 5 * 5);
            Color rippleColor = Color.FromArgb(255 - Math.Min(opacity * 10, 255), Color.HotPink);
            using (SolidBrush brush = new SolidBrush(rippleColor))
            using (Pen outlinePen = new Pen(Color.Crimson, 4)) // Pen of the outline
            {                
                Rectangle rect = DrawingHelper.CreateRectangle(surface.Width, surface.Height, radius);
                graphics.FillEllipse(brush, rect);
                //graphics.DrawEllipse(outlinePen, rect);                        
            }
        }
    }
}
