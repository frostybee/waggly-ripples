using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormLayered.Drawing.Shapes;

namespace WinFormLayered.Drawing
{
    internal class HexagonRipple : BaseProfile
    {
        Pen _outlinePen;
        int _baseRadius = 10; // Needs to be parametrized.
        
        public HexagonRipple()
        {
            InitDrawingProfile();
        }

        private void InitDrawingProfile()
        {
            int opacity = 10;
            int strokeWidth = 4;
            var x = 200 / 2;
            var y = 200 / 2;

            _outlinePen = new Pen(Color.Crimson.WithOpacity(opacity), 4);
            // 1) Make the outer most ripple.
            _ripples.Add(
                new RippleEntry()
                {
                    IsExpandable = true,
                    Bounds = DrawingHelper.CreateRectangle(Width, Height, _baseRadius),
                    ShapeType = ShapeType.Polygon,
                    Radius = _baseRadius,
                    RadiusMultiplier = 2,
                    OutlinePen = _outlinePen,
                    IsFilled = false,
                    PolyPoints =  DrawingHelper.GetHexagonPoints(x, y, _baseRadius)
                });
            
            
            //int radius = Math.Min((int)(progress * baseRadius * 2), surface.Width / 2);
            // TODO: implement GetCurrentRaius(); in the BaseProfile
            
            //graphics.DrawPolygon(new Pen(Brushes.Red, strokeWidth), shapes);
        }
        

        //TODO: need to pass an instance of RippleInfo (aka settings).
        public override void Draw(Graphics graphics, Bitmap surface, double progress)
        {
            graphics.Clear(Color.Transparent);
            int baseRadius = 15;
            //graphics.DrawPolygon(new Pen(Brushes.Red, strokeWidth), shapes);

        }
    }
}
