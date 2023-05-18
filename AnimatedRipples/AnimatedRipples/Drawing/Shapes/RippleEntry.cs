using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormLayered.Drawing.Shapes
{
    internal class RippleEntry
    {
        public ShapeType ShapeType { get; set; } = ShapeType.Ellipse;
        public bool IsFilled { get; set; } = false;
        public bool IsExpandable { get; set; } = true;
        public bool IsFade { get; set; } = true;
        public float RadiusMultiplier { get; set; } = 2.2f;
        public Color FillColor { get; set; }
        public Color StrokeColor { get; set; }
        public int Radius { get; set; }
        public int Opacity { get; set; }
        public BorderStyle BorderStyle { get; set; }
        public Rectangle Bounds { get; set; }
        public SolidBrush FillBrush { get; set; }
        public Pen OutlinePen { get; set; }
        public PointF[] PolyPoints { get; set; }
        public PolygonType PolygonType { get; set; }
        public double ExpandedRadius { get { return Radius * RadiusMultiplier; } }

        //-- TODO: can be moved to a BaseShape class: then render() it there.
        // Move this to profileRendered or Helper class.
        internal void Draw(Graphics graphics, double progress)
        {
            // Expand the radius of the current ripple to be rendered. 
            //FIXME: ripple.ExpandRadius(animationProgress);
            ExpandRadius(progress);
            //-- Get the opacity value for animating a fade-like color transition.
            AdjustColorOpacity(progress);
            //Debug.WriteLine("Opacity: " + opacity);
            //-- Draw this ripple entry.
            switch (ShapeType)
            {
                case ShapeType.Crosshair:
                    graphics.FillRectangle(FillBrush, Bounds);
                    break;
                case ShapeType.Ellipse:
                    // DrawCircle();
                    if (IsFilled)
                    {
                        graphics.FillEllipse(FillBrush, Bounds);
                    }
                    else
                    {
                        //OutlinePen.Color = OutlinePen.Color.ReduceOpacity(opacity);
                        graphics.DrawEllipse(OutlinePen, Bounds);
                    }
                    break;
                case ShapeType.Rectangle:
                    //OutlinePen.Color = OutlinePen.Color.ReduceOpacity(opacity);                    
                    /*if (IsFilled)
                    {
                        graphics.FillRectangle(FillBrush, Bounds);
                        
                    }
                    else
                    {*/
                        graphics.DrawRectangle(OutlinePen, Bounds);
                    
                    break;
                case ShapeType.Polygon:                    
                    var x = 200 / 2;
                    var y = 200 / 2;
                    int newRadius = Math.Min(Math.Max(1, (int)(progress * CalculateNewRadius())), 200 / 2);
                    switch (PolygonType)
                    {
                        case PolygonType.Diamond:
                            PolyPoints = DrawingHelper.CreateDiamond(x, y, newRadius);
                            break;
                        case PolygonType.Hexagon:
                            PolyPoints = DrawingHelper.CreateHexagon(x, y, newRadius);
                            break;
                        case PolygonType.Star:
                            PolyPoints = DrawingHelper.CreateStarShape(200, newRadius);
                            break;
                        default:
                            break;
                    }
                    
                    //PolyPoints = DrawingHelper.CreateHexagon(x, y, newRadius);
                    //PolyPoints = DrawingHelper.CreateStarShape(200, newRadius);
                    graphics.DrawPolygon(OutlinePen, PolyPoints.ToArray());
                    break;
            }
        }

        private void AdjustColorOpacity(double animationProgress)
        {
            //return (255 - Math.Min(Math.Max(0, (int)animationProgress* 150), 255));
            int opacity = 1;
            // Opacity percentage: 255 * 75 / 100
            float percentage = (float)Math.Round(animationProgress * 80, 2);
            opacity = Math.Max(1, Math.Min(255 * (int)percentage / 100, 255));
            if (IsFade)
            {
                if (IsFilled)
                {
                    FillBrush.Color = FillBrush.Color.ReduceOpacity(opacity);
                    //FillBrush.Color = DrawingHelper.RandomColor().ReduceOpacity(opacity);
                }
                else
                {
                    Debug.WriteLine("opacity: "+opacity);
                    OutlinePen.Color = OutlinePen.Color.ReduceOpacity(opacity);
                }
            }
        }

        internal void ExpandRadius(double progress)
        {

            if (IsExpandable)
            {
                // TODO: Take into consideration the MaxRadius.
                // TODO: Clamp the radius. 
                int newRadius = Math.Min(Math.Max(1, (int)(progress * CalculateNewRadius())), 200 / 2);
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
