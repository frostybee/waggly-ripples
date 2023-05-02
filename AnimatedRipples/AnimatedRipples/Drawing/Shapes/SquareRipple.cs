using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormLayered.Drawing.Shapes;

namespace WinFormLayered.Drawing
{
    internal class SquareRipple : BaseProfile
    {
        public override void Draw(Graphics graphics, Bitmap surface, double progress)
        {
            graphics.Clear(Color.Transparent);            
            int baseRadius = 15;
            // Expand the size of the radius.
            var radius = (int)(progress * baseRadius * 3);
            Color rippleColor = Color.DarkBlue.WithOpacity(radius * 10);
            // TODO: create these tools once and dispose them upon switching a profile. 
            using (SolidBrush brush = new SolidBrush(rippleColor))
            using (Pen outlinePen = new Pen(rippleColor, 4)) // Pen of the outline
            {
                Rectangle rect = DrawingHelper.CreateRectangle(surface.Width, surface.Height, radius);                
                graphics.DrawRectangle(outlinePen, rect);
            }         
        }
    }
}
