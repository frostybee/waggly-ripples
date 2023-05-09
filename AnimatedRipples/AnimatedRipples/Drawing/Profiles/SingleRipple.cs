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
    internal class SingleRipple : BaseProfile
    {
        // TODO: add IsFilled. Color Transition: enabled/disabled.
        // Add random color?        
        Pen _outlinePen;
        SolidBrush _innerBrush;
        SolidBrush _outerBursh;

        public SingleRipple()
        {
            MakeSingleProfile();
        }

        private void MakeSingleProfile()
        {
            int opacity = 10;
            _innerBrush = new SolidBrush(Color.Cyan);
            _outerBursh = new SolidBrush(Color.Crimson);
            _outlinePen = new Pen(Color.YellowGreen.ReduceOpacity(opacity), 4);            
            //-- 1) Add the middle ripple.
            _ripples.Add(
                new RippleEntry()
                {
                    IsExpandable = true,
                    Bounds = DrawingHelper.CreateRectangle(Width, Height, BaseRadius),
                    ShapeType = ShapeType.Ellipse,
                    Radius = BaseRadius,
                    RadiusMultiplier = 3,
                    FillBrush = _outerBursh,
                    OutlinePen = _outlinePen,
                    IsFilled = true,
                });
            //-- 2) Add the outline ripple.
            _ripples.Add(
                new RippleEntry()
                {
                    IsExpandable = true,
                    Bounds = DrawingHelper.CreateRectangle(Width, Height, BaseRadius),
                    ShapeType = ShapeType.Ellipse,
                    Radius = BaseRadius,
                    RadiusMultiplier = 3,
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
                    Radius = 6,
                    RadiusMultiplier = 2,
                    FillBrush = _innerBrush,
                    OutlinePen = _outlinePen,
                    IsFilled = true,
                });
        }
    }
}

