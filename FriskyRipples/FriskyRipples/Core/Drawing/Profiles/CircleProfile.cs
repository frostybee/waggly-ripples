using System.Drawing;
using FrostyBee.FriskyRipples.Extensions;
using FrostyBee.FriskyRipples.Helpers;

namespace FrostyBee.FriskyRipples.Drawing
{
    internal class CircleProfile : BaseProfile 
    {
        Pen _outlinePen;
        int _baseRadius = 10; // Needs to be parametrized.
        public CircleProfile()
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
                    ShapeType = ShapeType.Ellipse,
                    InitialRadius = 10,
                    RadiusMultiplier = 2,
                    OutlinePen = _outlinePen,
                    IsFilled = false,
                });
        }        
    }
}
