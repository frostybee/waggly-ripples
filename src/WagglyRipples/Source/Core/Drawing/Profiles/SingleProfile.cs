﻿using System.Drawing;
using FrostyBee.FriskyRipples.Extensions;
using FrostyBee.FriskyRipples.Helpers;

namespace FrostyBee.FriskyRipples.Drawing
{
    /// <summary>
    /// Represents a single expanding ripple.
    /// </summary>
    internal class SingleProfile : BaseProfile
    {
        // TODO: add IsFilled. Color Transition: enabled/disabled.
        // Add random color?        
        Pen _outlinePen;
        SolidBrush _innerBrush;
        SolidBrush _outerBrush;

        public SingleProfile()
        {
            MakeSingleProfile();
        }

        private void MakeSingleProfile()
        {
            int opacity = 10;
            _innerBrush = new SolidBrush(Color.Cyan);
            _outerBrush = new SolidBrush(Color.Crimson);
            _outlinePen = new Pen(Color.YellowGreen.ReduceOpacity(opacity), 4);            

            //-- 1) Add the middle ripple.
            AddRipple(
                new RippleEntry()
                {
                    IsExpandable = true,
                    Bounds = DrawingHelper.CreateRectangle(Width, Height, BaseRadius),
                    ShapeType = ShapeType.Ellipse,
                    InitialRadius = BaseRadius,
                    RadiusMultiplier = 3,
                    FillBrush = _outerBrush,
                    OutlinePen = _outlinePen,
                    IsFilled = true,
                });
            //-- 2) Add the outline ripple.
            AddRipple(
                new RippleEntry()
                {
                    IsExpandable = true,
                    Bounds = DrawingHelper.CreateRectangle(Width, Height, BaseRadius),
                    ShapeType = ShapeType.Ellipse,
                    InitialRadius = BaseRadius,
                    RadiusMultiplier = 3,
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
                    InitialRadius = 6,
                    RadiusMultiplier = 2,
                    FillBrush = _innerBrush,
                    OutlinePen = _outlinePen,
                    IsFilled = true,
                });
        }
    }
}

