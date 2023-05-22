﻿using System.Drawing;
using FrostyBee.FriskyRipples.Drawing;
using FrostyBee.FriskyRipples.Extensions;
using FrostyBee.FriskyRipples.Helpers;

namespace FrostyBee.FriskyRipples.Drawing
{
    internal class HexagonProfile : BaseProfile
    {
        Pen _outlinePen;
        int _baseRadius = 10; // Needs to be parametrized.

        public HexagonProfile()
        {
            InitDrawingProfile();
        }

        private void InitDrawingProfile()
        {
            int opacity = 10;
            int strokeWidth = 4;
            var x = 200 / 2;
            var y = 200 / 2;

            _outlinePen = new Pen(Color.Crimson.ReduceOpacity(opacity), 4);
            // 1) Make the outer most ripple.
            _ripples.Add(
                new RippleEntry()
                {
                    IsExpandable = true,
                    Bounds = DrawingHelper.CreateRectangle(Width, Height, _baseRadius),
                    ShapeType = ShapeType.Polygon,
                    InitialRadius = _baseRadius,
                    RadiusMultiplier = 2,
                    OutlinePen = _outlinePen,
                    IsFilled = false,
                    PolygonType = PolygonType.Hexagon
                    //PolyPoints =  DrawingHelper.CreateHexagon(x, y, _baseRadius)
                });
        }
    }
}