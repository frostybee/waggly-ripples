﻿using System.Drawing;
using System.Drawing.Drawing2D;
using FrostyBee.FriskyRipples.Helpers;

namespace FrostyBee.FriskyRipples.Drawing
{
    internal class ConcentricProfile : BaseProfile
    {
        private SolidBrush _brushInnerRipple;
        private Pen _penOutline;
        private Pen _innerPen;
               
        public ConcentricProfile()
        {
            InitProfileEntries();
        }

        private void InitProfileEntries()
        {
            int _baseRadius = 10;  
            int width = 200;
            int height = 200;
            _brushInnerRipple = new SolidBrush(Color.Yellow);
            _penOutline = new Pen(Color.Crimson, 4);
            _innerPen = new Pen(Color.SteelBlue, 3)
            {
                DashStyle = DashStyle.Dash
            };           
                       
            // 1) Make the outer most ripple.
            AddRipple(
                new RippleEntry()
                {
                    IsExpandable = true,
                    Bounds = DrawingHelper.CreateRectangle(width, height, _baseRadius * 2),
                    FillBrush = _brushInnerRipple,
                    ShapeType = ShapeType.Ellipse,
                    InitialRadius = 10,
                    RadiusMultiplier = 2.5f,
                    OutlinePen = _penOutline,
                    IsFilled = false,
                });
            //-- 2) Make ripples that will be rendered between the inner most and outer most ripples.
            int radius = 4;            
            for (int i = 0; i < 3; i++)
            {
                AddRipple(
                    new RippleEntry()
                    {
                        IsExpandable = true,
                        Bounds = DrawingHelper.CreateRectangle(width, height, radius),
                        FillBrush = _brushInnerRipple,
                        ShapeType = ShapeType.Ellipse,
                        OutlinePen = _innerPen,
                        RadiusMultiplier = 2,
                        InitialRadius = radius,
                        IsFade = false,
                        IsFilled = false,
                    });
                radius += 2;
            }
            // Make the core (most inner ripple).            
            AddRipple(
                new RippleEntry()
                {
                    IsExpandable = false,
                    IsFade = false,
                    //Bounds = DrawingHelper.CreateRectangle(surface.Width, surface.Height, 5)
                    Bounds = DrawingHelper.CreateRectangle(width, height, 7),
                    FillBrush = _brushInnerRipple,
                    ShapeType = ShapeType.Ellipse,
                    InitialRadius = 7,
                    IsFilled = true,
                });
        }        
    }
}
