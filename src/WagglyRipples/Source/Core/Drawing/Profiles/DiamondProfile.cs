﻿using System.Drawing;
using FrostyBee.FriskyRipples.Extensions;
using FrostyBee.FriskyRipples.Helpers;

namespace FrostyBee.FriskyRipples.Drawing
{
    internal class DiamondProfile : BaseProfile
    {
        private Pen _outlinePen;
        public DiamondProfile()
        {
            InitProfileEntries();
        }

        private void InitProfileEntries()
        {            
            int _baseRadius = 10;
            int opacity = 10;
            int strokeWidth = 4;            
            _outlinePen = new Pen(Color.DarkBlue.ReduceOpacity(opacity), 4);
            // 1) Make the outer most ripple.
            AddRipple(
                new RippleEntry()
                {
                    IsExpandable = true,
                    Bounds = DrawingHelper.CreateRectangle(Width, Height, _baseRadius),
                    ShapeType = ShapeType.Polygon,
                    InitialRadius = _baseRadius,
                    RadiusMultiplier = 2,
                    OutlinePen = _outlinePen,
                    IsFilled = false,
                    PolygonType = PolygonType.Diamond
                    //PolyPoints =  DrawingHelper.CreateHexagon(x, y, _baseRadius)
                });            
        }
    }
}
