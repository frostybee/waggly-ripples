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
    internal class SquaredPulseProfile : BaseProfile
    {
        // TODO: add IsFilled. Color Transition: enabled/disabled.
        // Add random color?        
        Pen _outlinePen;
        SolidBrush _innerBrush;
        SolidBrush _outerBursh;

        public SquaredPulseProfile()
        {
            InitDrawingProfile();
        }

        private void InitDrawingProfile()
        {
            int opacity = 10;
            _innerBrush = new SolidBrush(Color.DarkBlue);
            _outerBursh = new SolidBrush(Color.Crimson);

            _outlinePen = new Pen(Color.Crimson.ReduceOpacity(opacity), 4);
            // 1) Make the outer most ripple.
            //-- 2) Add the middle ripple.
            _ripples.Add(
                new RippleEntry()
                {
                    IsExpandable = true,
                    Bounds = DrawingHelper.CreateRectangle(Width, Height, BaseRadius+5),
                    ShapeType = ShapeType.Rectangle,
                    InitialRadius = BaseRadius+5,
                    IsFade = true,
                    RadiusMultiplier = 2,
                    FillBrush = _outerBursh,
                    OutlinePen = _outlinePen,
                    IsFilled = false,
                });
            //-- 3) Inner ripple that must drawn last.
            _ripples.Add(
                new RippleEntry()
                {
                    IsExpandable = false,
                    Bounds = DrawingHelper.CreateRectangle(Width, Height, 6),
                    ShapeType = ShapeType.Ellipse,
                    InitialRadius = 5,
                    IsFade  = false,
                    RadiusMultiplier = 2,
                    FillBrush = _innerBrush,
                    OutlinePen = _outlinePen,
                    IsFilled = true,
                });
        }        
    }
}
