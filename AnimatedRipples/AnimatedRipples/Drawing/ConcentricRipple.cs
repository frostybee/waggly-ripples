using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormLayered.Drawing
{
    internal class ConcentricRipple : BaseRipple
    {
        // Tools required to draw the ripples.
        SolidBrush brushInnerRipple;
        Pen penOutline;
        public ConcentricRipple() 
        {
            initDrawingTools();
        }

        private void initDrawingTools()
        {
            brushInnerRipple = new SolidBrush(Color.Yellow);
            penOutline = new Pen(Color.Crimson, 4);
        }

        //@see: https://stackoverflow.com/questions/9142833/show-my-location-on-google-maps-api-v3
        public override void Draw(Graphics graphics, Bitmap surface, double progress)
        {            
            graphics.Clear(Color.Transparent);
            int baseRadius = 20; // Needs to be parametrized.
            // TODO: add shadow around the ripples. Figure out how. 
            // NOTES: Here we paint the ripple. 
            // TODO: have a look at ShareX project and see how the created the layered window. 
            var rippleSize = (int)(progress * 50 * 2);            
            // TODO: reduce the opacity of the ripple's color.
            // TODO: Clam the dynamically computed radius of ripples. Make sure it's withing the _surface's bounding rectangle. 
            Color rippleColor = Color.Red;
            Rectangle outerRect = DrawingHelper.CreateRectangle(surface.Width, surface.Height, rippleSize);
            
            //_graphics.FillEllipse(new SolidBrush(rippleColor), outerRect);
            //_graphics.DrawEllipse(new Pen(rippleColor, 4), outerRect);
            int radius = 10;
            //Color internalRippleColor = Color.FromArgb(((byte)250 - (byte)(progress * 10)), Color.SteelBlue);
            Color internalRippleColor = Color.SteelBlue;
            for (int i = 0; i < 3; i++)
            {
                rippleSize = (int)(progress * radius * 1);
                Rectangle rect = DrawingHelper.CreateRectangle(surface.Width, surface.Height, rippleSize);
                Pen bluePen = new Pen(internalRippleColor, 3);
                bluePen.DashStyle = DashStyle.DashDot;
                //_graphics.DrawEllipse(bluePen, rect);
                radius += 10;
            }
            var thirdRipple = (int)(progress * baseRadius * 2);
            Rectangle thirdRect = DrawingHelper.CreateRectangle(surface.Width, surface.Height, thirdRipple);
            graphics.DrawEllipse(penOutline, thirdRect);
            // Draw the inner ripple (aka the core).
            Rectangle innerRect = DrawingHelper.CreateRectangle(surface.Width, surface.Height, 7);
            graphics.FillEllipse(brushInnerRipple, innerRect);
        }
    }
}
