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
                    Radius = BaseRadius,
                    RadiusMultiplier = 3,
                    FillBrush = _innerBrush,
                    IsFilled = true,
                });
        }
    }
}
