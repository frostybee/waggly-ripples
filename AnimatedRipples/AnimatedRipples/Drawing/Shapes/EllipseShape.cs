using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;

namespace WinFormLayered.Drawing.Shapes
{
    internal class EllipseShape : BaseShape
    {
        public override void Draw(Graphics graphics, double progress)
        {
            // Expand the radius of the current ripple to be rendered. 
            //FIXME: ripple.ExpandRadius(progress);
            ExpandRadius(progress);
            if (IsFilled)
            {
                graphics.FillEllipse(FillBrush, Bounds);
            }
            else
            {
                OutlinePen.Color = OutlinePen.Color.WithOpacity(Opacity);
                graphics.DrawEllipse(OutlinePen, Bounds);
            }
        }
    }
}
