﻿using System.Drawing;
using FrostyBee.FriskyRipples.Helpers;

namespace FrostyBee.FriskyRipples.Drawing
{
    internal class StarProfile : BaseProfile
    {
        private Pen _outlinePen;
        public StarProfile()
        {
            InitProfileEntries();
        }
        private void InitProfileEntries()
        {
            _outlinePen = new Pen(Color.Crimson, 4);
            // 1) Make the outer most ripple.
            AddRipple(
                new RippleEntry()
                {
                    IsExpandable = true,
                    ShapeType = ShapeType.Polygon,
                    Bounds = DrawingHelper.CreateRectangle(Width, Height, 20),
                    InitialRadius = 10,
                    RadiusMultiplier = 3,
                    OutlinePen = _outlinePen,
                    IsFilled = false,
                    PolygonType = PolygonType.Star
                });
        }
    }
}
