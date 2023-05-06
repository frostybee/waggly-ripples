using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormLayered.Drawing.Shapes
{
    internal class RippleEntry
    {
        public bool IsFilled { get; set; }
        [DefaultValue(false)]
        public bool IsExpandable { get; set; }
        [DefaultValue(1)]
        public int RadiusMultiplier { get; set; } = 2;
        public Color FillColor { get; set; }
        public Color StrokeColor { get; set; }
        public int Radius { get; set; }
        public int Opacity { get; set; }
        public BorderStyle BorderStyle { get; set; }
        public Rectangle Bounds { get; set; }
        public Size Dimension { get; set; }
        public SolidBrush FillBrush { get; set; }
        public Pen OutlinePen { get; set; }
        public List<PointF> PolyPoints { get; set; }


        public ShapeType ShapeType { get; set; }
        public double ExpandedRadius { get { return Radius * RadiusMultiplier; } }

        //-- TODO: can be moved to a BaseShape class: then render() it there.
        // Move this to profileRendered or Helper class.
        internal void Render(Graphics graphics, double progress)
        {
            // Expand the radius of the current ripple to be rendered. 
            //FIXME: ripple.ExpandRadius(progress);
            ExpandRadius(progress);
            //-- Render this ripple entry.
            switch (ShapeType)
            {
                case ShapeType.Ellipse:
                    // DrawCircle();
                    if (IsFilled)
                    {
                        graphics.FillEllipse(FillBrush, Bounds);
                    }
                    else
                    {
                        OutlinePen.Color = OutlinePen.Color.WithOpacity(Opacity);
                        graphics.DrawEllipse(OutlinePen, Bounds);
                    }
                    break;
                case ShapeType.Rectangle:
                    graphics.DrawRectangle(OutlinePen, Bounds);
                    break;
                case ShapeType.Polygon:
                    //PolyPoints = DrawingHelper.GetHexagonPoints(200, 200, E);
                    break;
            }
        }

        internal void ExpandRadius(double progress)
        {

            if (IsExpandable)
            {
                int newRadius = Math.Min(Math.Max(1, (int)(progress * CalculateNewRadius())), 200 / 2);
                //int newRadius = Math.Min(Math.Max(1,(int)(progress * 50)), 200 / 2-5);
                //int newRadius = (int)();
                // Create a new bounding rectangle based on the newly expanded radius. 
                Bounds = DrawingHelper.CreateRectangle(200, 200, newRadius);
            }
        }

        internal double CalculateNewRadius()
        {
            return Radius * RadiusMultiplier;
        }
    }
}
