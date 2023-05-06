using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormLayered.Drawing.Shapes;

namespace WinFormLayered.Drawing
{
    internal class CircleProfile : BaseProfile
    {
        Pen _outlinePen;
        int _baseRadius = 10; // Needs to be parametrized.
        public CircleProfile()
        {
            InitDrawingProfile();
        }

        private void InitDrawingProfile()
        {
            int opacity = 10;
            _outlinePen = new Pen(Color.Crimson.WithOpacity(opacity), 4);
            // 1) Make the outer most ripple.
            _ripples.Add(
                new RippleEntry()
                {
                    IsExpandable = true,
                    Bounds = DrawingHelper.CreateRectangle(Width, Height, _baseRadius),                     
                    ShapeType = ShapeType.Ellipse,
                    Radius = 10,
                    RadiusMultiplier = 2,
                    OutlinePen = _outlinePen,
                    IsFilled = false,
                });

        }

        //TODO: need to pass an instance of RippleInfo (aka settings).
        public override void Draw(Graphics graphics, Bitmap surface, double progress)
        {
            graphics.Clear(Color.Transparent);
            var opacity = (int)(progress * 35 * 5);
            // We adjust the ripple properties every animation frame. 
            _ripples.ForEach(ripple =>
            {
                // Render the ripple --> inputs: graphics, progress, surface size.
                int rippleSize = (ripple.IsExpandable) ? ripple.Radius : (int)(progress * ripple.ExpandedRadius);
                ripple.Bounds = (ripple.IsExpandable) ? ripple.Bounds : DrawingHelper.CreateRectangle(200, 200, rippleSize);
                ripple.Opacity = opacity;
                //RenderRipple();
                // Need to copy it locally.
                //RectangleF bounds = ripple.Bounds;
                //ripple.Radius = rippleSize;
                /* TODO: Solution ---> I can regenerate the rectangle in the property.
                 * bounds.Width = rippleSize;
                bounds.Height = rippleSize;
                bounds.X = 200/2;
                bounds.Y = 200/2;
                ripple.Bounds = bounds;*/
                //_brushInnerRipple.Color = DrawingHelper.RandomColor();
                //ripple.FillColor = DrawingHelper.RandomColor();
                ripple.Render(graphics, progress);
            });
            // Expand the size of the radius.            
            // TODO: ensure that the radius is <= maxRadius.
            //var radius = (int)(animationValue * _baseRadius * 2);
            //int radius = Math.Min((int)(progress * baseRadius * 2), surface.Width / 2);
            
            /*using (Pen outlinePen = new Pen(Color.Crimson.WithOpacity(opacity), 4)) // Pen of the outline
            {
                Rectangle rect = DrawingHelper.CreateRectangle(surface.Width, surface.Height, radius);
                graphics.DrawEllipse(outlinePen, rect);                               
                //-- Render drop shadow around the ripple.
                //GraphicsPath path = DrawingHelper.CreateCircle(surface.Width / 2f - radius - 2, surface.Height / 2f - radius, radius);
                //DrawingHelper.drawShadow(graphics, path, 4, Color.Yellow);
                //graphics.DrawPath(outlinePen, path);
            }*/
        }
    }
}
