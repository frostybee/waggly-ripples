﻿using System.Drawing;
using FrostyBee.FriskyRipples.Extensions;
using FrostyBee.FriskyRipples.Helpers;

namespace FrostyBee.FriskyRipples.Drawing
{
    /// <summary>
    /// Represents a single expanding ripple.
    /// </summary>
    internal class SquaredPulseProfile : BaseProfile
    {
        
        private Pen _outlinePen;
        private SolidBrush _innerBrush;
        private SolidBrush _outerBrush;

        public SquaredPulseProfile()
        {
            InitProfileEntries();
        }

        private void InitProfileEntries()
        {
            int opacity = 10;
            _innerBrush = new SolidBrush(Color.DarkBlue);
            _outerBrush = new SolidBrush(Color.Crimson);

            _outlinePen = new Pen(Color.Crimson.ReduceOpacity(opacity), 4);
            // 1) Make the outer most ripple.
            //-- 2) Add the middle ripple.
            AddRipple(
                new RippleEntry()
                {
                    IsExpandable = true,
                    Bounds = DrawingHelper.CreateRectangle(Width, Height, BaseRadius+5),
                    ShapeType = ShapeType.Rectangle,
                    InitialRadius = BaseRadius+5,
                    IsFade = true,
                    RadiusMultiplier = 2,
                    FillBrush = _outerBrush,
                    OutlinePen = _outlinePen,
                    IsFilled = false,
                });
            //-- 3) Inner ripple that must drawn last.
            AddRipple(
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
