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
    internal class ConcentricRipple : BaseProfile
    {
        //TODO: change the name to Lollipop
        // Tools required to draw the ripples.
        SolidBrush _brushInnerRipple;
        Pen _penOutline;
        Pen _innerPen;
        //Bitmap surface;

        int _baseRadius = 40; // Needs to be parametrized.
        public ConcentricRipple()
        {
            InitDrawingProfile();
        }

        private void InitDrawingProfile()
        {
            _brushInnerRipple = new SolidBrush(Color.Yellow);
            _penOutline = new Pen(Color.Crimson, 4);
            _innerPen = new Pen(Color.SteelBlue, 3);
            _innerPen.DashStyle = DashStyle.Dot;
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
                    ShapeType = ShapeType.Circle,
                    Radius = 10,
                    RadiusMultiplier = 2,
                    OutlinePen = _penOutline,
                    IsFilled = false,
                });            
            int radius = 5;
            //Color internalRippleColor = Color.FromArgb(255 - (byte)progress * 255, Color.SteelBlue);            
            //Color internalRippleColor = Color.SteelBlue;
            // Put them in a loop.
            for (int i = 0; i < 3; i++)
            {
                //-- Make ripples that will be rendered between the inner most and outer ripple.
                _ripples.Add(
                    new RippleEntry()
                    {
                        IsExpandable = true,                        
                        Bounds = DrawingHelper.CreateRectangle(width, height, radius),
                        FillBrush = _brushInnerRipple,
                        ShapeType = ShapeType.Circle,
                        OutlinePen = _innerPen,
                        RadiusMultiplier = 2,
                        Radius = radius,
                        IsFilled = false,
                    });
                radius += 2;
                // rippleSize = (int)(progress * radius * 1);
                /*Rectangle rect = DrawingHelper.CreateRectangle(surface.Width, surface.Height, rippleSize);
                Color internalRippleColor = Color.FromArgb(230, DrawingHelper.RandomColor());
                Pen bluePen = new Pen(internalRippleColor, 3);
                bluePen.DashStyle = DashStyle.Dot;
                graphics.DrawEllipse(bluePen, rect);
                radius += 5;*/
            }
            // 2) 
            //-- Make the most inner ripple (aka the core).            
            _ripples.Add(
                new RippleEntry()
                {
                    IsExpandable = false,
                    //Bounds = DrawingHelper.CreateRectangle(surface.Width, surface.Height, 5)
                    Bounds = DrawingHelper.CreateRectangle(width, height, 7),
                    FillBrush = _brushInnerRipple,
                    ShapeType = ShapeType.Circle,
                    Radius = 7,
                    IsFilled = true,
                });

        }

        //@see: https://stackoverflow.com/questions/9142833/show-my-location-on-google-maps-api-v3
        public override void Draw(Graphics graphics, Bitmap surface, double progress)
        {
            graphics.Clear(Color.Transparent);
            // TODO: add shadow around the ripples. Figure out how. 
            // NOTES: Here we paint the ripple. 
            // TODO: have a look at ShareX project and see how the created the _layered window.             

            // TODO: User a Rendered class that process the _ripples for all profiles.
            //       - Can be put in the base class: render profile.
            // INPUTS: the list of entries, and maybe some class members.
            _ripples.ForEach(ripple =>
            {
                // Render the ripple --> inputs: graphics, progress, surface size.
                /*int rippleSize = (ripple.IsExpandable) ? ripple.Radius : (int)(progress * ripple.ExpandedRadius);
                ripple.Bounds = (ripple.IsExpandable) ? ripple.Bounds : DrawingHelper.CreateRectangle(200, 200, rippleSize);*/

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


            // TODO: reduce the opacity of the ripple's color.
            // TODO: Clam the dynamically computed radius of ripples. Make sure it's withing the _surface's bounding rectangle. 
            /*Color rippleColor = Color.Red;
            Rectangle outerRect = DrawingHelper.CreateRectangle(surface.Width, surface.Height, rippleSize);

            //_graphics.FillEllipse(new SolidBrush(rippleColor), outerRect);
            //_graphics.DrawEllipse(new Pen(rippleColor, 4), outerRect);
            int radius = 10;
            //Color internalRippleColor = Color.FromArgb(255 - (byte)progress * 255, Color.SteelBlue);            
            //Color internalRippleColor = Color.SteelBlue;
            // Put them in a loop.
            for (int i = 0; i < 3; i++)
            {
                rippleSize = (int)(progress * radius * 1);
                Rectangle rect = DrawingHelper.CreateRectangle(surface.Width, surface.Height, rippleSize);
                Color internalRippleColor = Color.FromArgb(230, DrawingHelper.RandomColor());                
                Pen bluePen = new Pen(internalRippleColor, 3);
                bluePen.DashStyle = DashStyle.Dot;
                graphics.DrawEllipse(bluePen, rect);
                radius += 5;
            }
            // This is done:
            var thirdRipple = (int)(progress * _baseRadius * 2);
            Rectangle thirdRect = DrawingHelper.CreateRectangle(surface.Width, surface.Height, thirdRipple);
            //_penOutline.Color = Color.FromArgb(thirdRipple, _penOutline.Color);
            graphics.DrawEllipse(_penOutline, thirdRect);
            // Render the inner ripple (aka the core).
            Rectangle innerRect = DrawingHelper.CreateRectangle(surface.Width, surface.Height, 5);
            graphics.FillEllipse(_brushInnerRipple, innerRect);*/
        }
    }
}
