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
        public override void Draw(Graphics graphics, Bitmap surface, double progress)
        {
            graphics.Clear(Color.Transparent);
            var animationValue = progress;
            int baseRadius = 20;
            // Expand the size of the radius.
            var radius = (int)(animationValue * baseRadius * 2);                        
            Color rippleColor = Color.FromArgb(255 - Math.Min(radius * 5, 255), Color.Crimson);
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
