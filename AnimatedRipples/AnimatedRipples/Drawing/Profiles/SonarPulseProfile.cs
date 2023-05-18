﻿using System;
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
    internal class SonarPulseProfile : BaseProfile
    { 
        SolidBrush _innerBrush;
        SolidBrush _outerBursh;
        Pen _middlePen;        
        public SonarPulseProfile()
        {
            InitDrawingProfile();
        }

        private void InitDrawingProfile()
        {
            _innerBrush = new SolidBrush(Color.Green);
            _outerBursh = new SolidBrush(Color.DarkGreen.WithOpacity(250));
            _middlePen = new Pen(Color.White, 3);
            
            // 1) Make the outer ripple.
            _ripples.Add(
                new RippleEntry()
                {
                    IsExpandable = true,
                    Bounds = DrawingHelper.CreateRectangle(Width, Height, 15),
                    ShapeType = ShapeType.Ellipse,
                    Radius = BaseRadius,
                    RadiusMultiplier = 3,
                    FillBrush = _outerBursh,
                    IsFilled = true,
                });            
            // 2) Make the most outer ripple. 
            _ripples.Add(
                new RippleEntry()
                {
                    IsExpandable = false,
                    IsFade = false,
                    Bounds = DrawingHelper.CreateRectangle(Width, Height, 9),
                    ShapeType = ShapeType.Ellipse,
                    Radius = 9,
                    RadiusMultiplier = 2,
                    OutlinePen = _middlePen,
                    IsFilled = false,
                });            
            // 3) Make the most inner ripple. It must drawn last.
            _ripples.Add(
                new RippleEntry()
                {
                    IsExpandable = false,
                    IsFade = false,
                    Bounds = DrawingHelper.CreateRectangle(Width, Height, 8),
                    ShapeType = ShapeType.Ellipse,
                    Radius = 8,
                    RadiusMultiplier = 2,
                    FillBrush = _innerBrush,
                    IsFilled = true,
                });
        }
    }
}