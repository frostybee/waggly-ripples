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
        public bool IsFixed { get; set; }
        [DefaultValue(1)]
        public int RadiusMultiplier { get; set; }
        public Color FillColor { get; set; }
        public Color StrokeColor { get; set; }
        public int BaseRadius { get; set; }
        public int Opacity { get; set; }
        public BorderStyle BorderStyle { get; set; }
        public RectangleF Bounds { get; set; }
        public Size Dimension { get; set; }
        public SolidBrush FillBrush { get; set; }
        public Pen OutlinePen { get; set; }

        public ShapeType ShapeType { get; set; }
        public double ExpandedRadius { get { return BaseRadius * RadiusMultiplier; } }

        //-- TODO: can be moved to a BaseShape class: then render() it there.
        internal void Draw(Graphics graphics)
        {
            //-- Render this ripple entry.
            switch (ShapeType)
            {
                case ShapeType.Circle:
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
                    break;
                case ShapeType.Polygon:
                    break;
            }
        }

        internal double GetExpandedRadius()
        {
            return BaseRadius * RadiusMultiplier;
        }
    }
}
