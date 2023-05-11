using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormLayered.Drawing.Extensions;
using WinFormLayered.Drawing.Shapes;

namespace WinFormLayered.Drawing
{
    internal class StarRipple : BaseProfile
    {

        Pen _outlinePen;
        public StarRipple()
        {
            InitDrawingProfile();
        }
        private void InitDrawingProfile()
        {
            //TODO: store in the settings the stroke width of the pen.
            // And the style/dashed/dot
            _outlinePen = new Pen(Color.Crimson, 4);
            //_outlinePen.DashStyle = DashStyle.Dot;

            // 1) Make the outer most ripple.
            _ripples.Add(
                new RippleEntry()
                {
                    IsExpandable = true,
                    ShapeType = ShapeType.Polygon,
                    Bounds = DrawingHelper.CreateRectangle(Width, Height, 20),
                    Radius = 10,
                    RadiusMultiplier = 3,
                    OutlinePen = _outlinePen,
                    IsFilled = false,
                    PolygonType = PolygonType.Star
                });
        }
    }
}
