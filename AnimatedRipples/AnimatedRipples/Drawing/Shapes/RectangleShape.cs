using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;

namespace WinFormLayered.Drawing.Shapes
{
    internal class RectangleShape : BaseShape
    {
        public override void Draw(Graphics graphics, double progress)
        {
            ExpandRadius(progress);            
            graphics.DrawRectangle(OutlinePen, Bounds);
        }
    }
}
