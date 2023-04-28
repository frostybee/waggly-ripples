using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace WinFormLayered.Drawing.Shapes
{
    internal class CrosshairRipple : BaseRipple
    {
        public override void Draw(Graphics graphics, Bitmap surface, double progress)
        {
            graphics.Clear(Color.Transparent);
            // TODO: Add color transition.
            /*int width = Convert.ToInt32(40 * progress);          
            int height = Convert.ToInt32(10 * progress);*/
            int width = 40 ;
            int height = 8 ;
            graphics.FillRectangle(Brushes.CornflowerBlue, new Rectangle((surface.Width / 2) - 4, (surface.Height / 2) - 20, height, width));
            graphics.FillRectangle(Brushes.Crimson, new Rectangle((surface.Width / 2) - 20, (surface.Height / 2) - 4, width, height));
/*            var pathX = new GraphicsPath();
            var pathY = new GraphicsPath();
            pathX.AddLine(0, surface.Width / 2, surface.Width, surface.Width / 2);
            pathY.AddLine(surface.Width / 2, 0, surface.Width / 2, surface.Width);
            graphics.DrawPath(new Pen(Brushes.Red), pathX);
            graphics.DrawPath(new Pen(Brushes.Red), pathY);*/
            
        }
    }
}
