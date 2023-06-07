﻿using System.Drawing;
using FrostyBee.FriskyRipples.Extensions;
using FrostyBee.FriskyRipples.Helpers;

namespace FrostyBee.FriskyRipples.Drawing
{
    internal class SpotlightProfile : BaseProfile
    {
        private SolidBrush _innerBrush;
        public SpotlightProfile()
        {
            InitProfileEntries();
        }
        private void InitProfileEntries()
        {
            Color rippleColor = Color.Crimson.ReduceOpacity(20);
            _innerBrush = new SolidBrush(rippleColor);
            //-- 1) Make the outer ripple.
            AddRipple(
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
