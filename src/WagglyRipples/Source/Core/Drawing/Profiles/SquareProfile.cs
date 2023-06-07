using System.Drawing;
using FrostyBee.FriskyRipples.Extensions;
using FrostyBee.FriskyRipples.Helpers;

namespace FrostyBee.FriskyRipples.Drawing
{
    internal class SquareProfile : BaseProfile
    {
        private SolidBrush brush;
        private Pen _outlinePen;        
        public SquareProfile()
        {
            InitProfileEntries();
        }
        private void InitProfileEntries()
        {
            int _baseRadius = 10; 
            brush = new SolidBrush(Color.DarkBlue.ReduceOpacity(_baseRadius * 10));
            _outlinePen = new Pen(Color.DarkBlue.ReduceOpacity(_baseRadius * 10), 4);

            // 1) Make the outer most ripple.
            AddRipple(
                new RippleEntry()
                {
                    IsExpandable = true,
                    ShapeType = ShapeType.Rectangle,
                    Bounds = DrawingHelper.CreateRectangle(Width, Height, _baseRadius),
                    InitialRadius = 10,
                    RadiusMultiplier = 2,
                    FillBrush = brush,
                    OutlinePen = _outlinePen,
                    IsFilled = true,
                });
        }         
    }
}
