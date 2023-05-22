using System.Drawing;
using FrostyBee.FriskyRipples.Drawing;
using FrostyBee.FriskyRipples.Extensions;
using FrostyBee.FriskyRipples.Helpers;

namespace FrostyBee.FriskyRipples.Drawing
{
    internal class SpotlightProfile : BaseProfile
    {
        // TODO: dispose the drawing tools.
        SolidBrush _innerBrush;
        public SpotlightProfile()
        {
            InitDrawingProfile();
        }
        private void InitDrawingProfile()
        {
            Color rippleColor = Color.Crimson.ReduceOpacity(20);
            _innerBrush = new SolidBrush(rippleColor);
            //-- 1) Make the outer ripple.
            _ripples.Add(
                new RippleEntry()
                {
                    IsExpandable = false,
                    Bounds = DrawingHelper.CreateRectangle(Width, Height, BaseRadius),
                    ShapeType = ShapeType.Ellipse,
                    InitialRadius = BaseRadius,
                    RadiusMultiplier = 3,
                    FillBrush = _innerBrush,
                    IsFilled = true,
                });
        }
    }
}
