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
        SolidBrush brush;
        Pen _outlinePen;
        int _baseRadius = 10; // Needs to be parametrized.
        public SquareRipple()
        {
            InitDrawingProfile();
        }
        private void InitDrawingProfile()
        {
            brush = new SolidBrush(Color.DarkBlue.WithOpacity(_baseRadius * 10));
            _outlinePen = new Pen(Color.DarkBlue.WithOpacity(_baseRadius * 10), 4);

            // 1) Make the outer most ripple.
            _ripples.Add(
                new RippleEntry()
                {
                    IsExpandable = true,
                    ShapeType = ShapeType.Rectangle,
                    Bounds = DrawingHelper.CreateRectangle(Width, Height, _baseRadius),
                    Radius = 10,
                    RadiusMultiplier = 2,
                    OutlinePen = _outlinePen,
                    IsFilled = false,
                });
        }
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
