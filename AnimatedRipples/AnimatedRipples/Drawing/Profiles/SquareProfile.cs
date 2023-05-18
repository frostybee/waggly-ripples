﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormLayered.Drawing.Shapes;

namespace WinFormLayered.Drawing
{
    internal class SquareProfile : BaseProfile
    {
        SolidBrush brush;
        Pen _outlinePen;
        int _baseRadius = 10; // Needs to be parametrized.
        public SquareProfile()
        {
            InitDrawingProfile();
        }
        private void InitDrawingProfile()
        {
            brush = new SolidBrush(Color.DarkBlue.ReduceOpacity(_baseRadius * 10));
            _outlinePen = new Pen(Color.DarkBlue.ReduceOpacity(_baseRadius * 10), 4);

            // 1) Make the outer most ripple.
            _ripples.Add(
                new RippleEntry()
                {
                    IsExpandable = true,
                    ShapeType = ShapeType.Rectangle,
                    Bounds = DrawingHelper.CreateRectangle(Width, Height, _baseRadius),
                    Radius = 10,
                    RadiusMultiplier = 2,
                    FillBrush = brush,
                    OutlinePen = _outlinePen,
                    IsFilled = true,
                });
        }         
    }
}