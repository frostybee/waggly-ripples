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
    /// <summary>
    /// Represents a single expanding ripple.
    /// </summary>
    internal class SquaredRipple : BaseProfile
    {
        // TODO: add IsFilled. Color Transition: enabled/disabled.
        // Add random color?        
        Pen _outlinePen;
        SolidBrush _innerBrush;
        SolidBrush _outerBursh;         

        public SquaredRipple()
        {
            InitDrawingProfile();
        }

        private void InitDrawingProfile()
        {
            int opacity = 10;
            _innerBrush = new SolidBrush(Color.Yellow);
            _outerBursh = new SolidBrush(Color.Crimson);

            _outlinePen = new Pen(Color.Crimson.WithOpacity(opacity), 4);
            // 1) Make the outer most ripple.
            //-- 2) Add the middle ripple.
            _ripples.Add(
                new RippleEntry()
                {
                    IsExpandable = true,
                    Bounds = DrawingHelper.CreateRectangle(Width, Height, BaseRadius),
                    ShapeType = ShapeType.Rectangle,
                    Radius = BaseRadius,
                    RadiusMultiplier = 3,
                    FillBrush = _outerBursh,
                    OutlinePen = _outlinePen,
                    IsFilled = true,
                });
            //-- 3) Inner ripple that must drawn last.
            _ripples.Add(
                new RippleEntry()
                {
                    IsExpandable = false,
                    Bounds = DrawingHelper.CreateRectangle(Width, Height, 5),
                    ShapeType = ShapeType.Ellipse,
                    Radius = 5,
                    RadiusMultiplier = 2,
                    FillBrush = _innerBrush,
                    OutlinePen = _outlinePen,
                    IsFilled = true,
                });           
            
        }

        /* Inputs: canvas, radius, color, animation progress: multiplier. 
            Note:
                - on animation progress -> profile.Render(); on the canvas.
                Extract them from the current drawing methods. 
                Need the canvas and the _surface. 
            TODO: Inputs/parameters: radius of the ripple, canvas size should be fixed to 300
                  but I need to test it. 
        */
        public override void Draw(Graphics graphics, Bitmap surface, double progress)
        {
            graphics.Clear(Color.Transparent);
            int width = 100;
            var animationValue = progress;
            int baseRadius = 15;
            int innerRadius = 5;
            // Expand the size of the radius.
            var rippleRadius = (int)(animationValue * baseRadius * 2);
            //Square innerRect = new Square(width / 2 -30, width / 2 -30, 30, 30);
            Rectangle innerRect = DrawingHelper.CreateRectangle(surface.Width, surface.Height, innerRadius);
            // FIXME: the color opacity needs to be validated: it's crashing when a spring interpolation is applied.
            // Color of the large ripple
            //Color rippleColor = Color.FromArgb(((byte)250 - (byte)(progress * 40 )), Color.RosyBrown);
            Color rippleColor = Color.Indigo;
            // FIXME: the following objects needs to be created once in advance. 
            using (SolidBrush innerBrush = new SolidBrush(Color.Yellow))
            using (SolidBrush outerBursh = new SolidBrush(rippleColor))
            using (Pen outlinePen = new Pen(Color.Crimson, 3)) // Pen of the outline
            {
                //Square outerRect = new Square(width - rippleRadius / 2, width - rippleRadius / 2, rippleRadius, rippleRadius);                
                Rectangle outerRect = DrawingHelper.CreateRectangle(surface.Width, surface.Height, rippleRadius);
                // Adjust the ripple's color based on the current progress of the running animation. 
                // NOTE: the value of the opacity needs to be validated < 255                
                graphics.FillEllipse(outerBursh, outerRect);
                graphics.DrawEllipse(outlinePen, outerRect);
                // Render the inner ripple. It must drawn last.
                graphics.FillEllipse(innerBrush, innerRect);

                // TODO: Render a circle outline à la Google Maps ripple
                // - Also, draw circle in the middle after the innerRect one. 
                // TODO: Look for drawing helpers in ShareX and other libraries.                 
            }
        }
    }
}
