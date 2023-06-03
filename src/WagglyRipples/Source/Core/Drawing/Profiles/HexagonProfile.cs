using System.Drawing;
using FrostyBee.FriskyRipples.Extensions;
using FrostyBee.FriskyRipples.Helpers;

namespace FrostyBee.FriskyRipples.Drawing
{
    internal class HexagonProfile : BaseProfile
    {
        Pen _outlinePen;
        int _baseRadius = 10; // Needs to be parametrized.

        public HexagonProfile()
        {
            InitProfileEntries();
        }

        private void InitProfileEntries()
        {
            int opacity = 10;           
            _outlinePen = new Pen(Color.Crimson.ReduceOpacity(opacity), 4);
            // 1) Make the outer most ripple.
            AddRipple(
                new RippleEntry()
                {
                    IsExpandable = true,
                    Bounds = DrawingHelper.CreateRectangle(Width, Height, _baseRadius),
                    ShapeType = ShapeType.Polygon,
                    InitialRadius = _baseRadius,
                    RadiusMultiplier = 2,
                    OutlinePen = _outlinePen,
                    IsFilled = false,
                    PolygonType = PolygonType.Hexagon
                    //PolyPoints =  DrawingHelper.CreateHexagon(x, y, _baseRadius)
                });
        }
    }
}
