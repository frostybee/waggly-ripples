using System.Drawing;
using FrostyBee.FriskyRipples.Drawing;
using FrostyBee.FriskyRipples.Helpers;

namespace FrostyBee.FriskyRipples.Drawing
{
    internal class StarProfile : BaseProfile
    {

        Pen _outlinePen;
        public StarProfile()
        {
            InitDrawingProfile();
        }
        private void InitDrawingProfile()
        {
            //TODO: store in the settings the stroke width of the pen.
            // And the style/dashed/dot
            _outlinePen = new Pen(Color.Crimson, 4);
            //_outlinePen.DashStyle = DashStyle.Dot;

            // 1) Make the outer most ripple.
            _ripples.Add(
                new RippleEntry()
                {
                    IsExpandable = true,
                    ShapeType = ShapeType.Polygon,
                    Bounds = DrawingHelper.CreateRectangle(Width, Height, 20),
                    InitialRadius = 10,
                    RadiusMultiplier = 3,
                    OutlinePen = _outlinePen,
                    IsFilled = false,
                    PolygonType = PolygonType.Star
                });
        }
    }
}
