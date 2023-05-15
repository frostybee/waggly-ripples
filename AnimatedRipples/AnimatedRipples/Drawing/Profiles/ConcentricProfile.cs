using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormLayered.Drawing.Shapes;

namespace WinFormLayered.Drawing
{
    internal class ConcentricProfile : BaseProfile
    {
        //TODO: change the name to Lollipop
        // Tools required to draw the ripples.
        // TODO: store the drawing tools in a list in the base class. 
        // Need to dispose them all at once. 
        SolidBrush _brushInnerRipple;
        Pen _penOutline;
        Pen _innerPen;
        //Bitmap surface;

        int _baseRadius = 40; // Needs to be parametrized.
        public ConcentricProfile()
        {
            InitDrawingProfile();
        }

        private void InitDrawingProfile()
        {
            _brushInnerRipple = new SolidBrush(Color.Yellow);
            _penOutline = new Pen(Color.Crimson, 3);
            _innerPen = new Pen(Color.SteelBlue, 3)
            {
                DashStyle = DashStyle.Dash
            };
            
            int width = 200;
            int height = 200;
            //-- Make the ripples.
            _ripples.Clear();
            // NOTE: To avoid any potential memory leak, we create the ripples
            // once the profile is instantiated.
            // 

            // 1) Make the outer most ripple.
            _ripples.Add(
                new RippleEntry()
                {
                    IsExpandable = true,
                    Bounds = DrawingHelper.CreateRectangle(width, height, _baseRadius * 2),
                    FillBrush = _brushInnerRipple,
                    ShapeType = ShapeType.Ellipse,
                    Radius = 10,
                    RadiusMultiplier = 2.5f,
                    OutlinePen = _penOutline,
                    IsFilled = false,
                });
            int radius = 5;
            //Color internalRippleColor = Color.FromArgb(255 - (byte)progress * 255, Color.SteelBlue);            
            //Color internalRippleColor = Color.SteelBlue;
            // Put them in a loop.
            for (int i = 0; i < 3; i++)
            {
                //-- 2) Make ripples that will be rendered between the inner most and outer most ripples.
                _ripples.Add(
                    new RippleEntry()
                    {
                        IsExpandable = true,
                        Bounds = DrawingHelper.CreateRectangle(width, height, radius),
                        FillBrush = _brushInnerRipple,
                        ShapeType = ShapeType.Ellipse,
                        OutlinePen = _innerPen,
                        RadiusMultiplier = 2,
                        Radius = radius,
                        IsFade = false,
                        IsFilled = false,
                    });
                radius += 2;
            }
            //-- 3) Make the most inner ripple (aka the core).
            // This ripple's radius does not expand.
            _ripples.Add(
                new RippleEntry()
                {
                    IsExpandable = false,
                    IsFade = false,
                    //Bounds = DrawingHelper.CreateRectangle(surface.Width, surface.Height, 5)
                    Bounds = DrawingHelper.CreateRectangle(width, height, 7),
                    FillBrush = _brushInnerRipple,
                    ShapeType = ShapeType.Ellipse,
                    Radius = 7,
                    IsFilled = true,
                });
        }
        // TODO: reduce the opacity of the ripple's color.
        // TODO: Clam the dynamically computed radius of ripples. Make sure it's withing the _surface's bounding rectangle. 
    }
}
