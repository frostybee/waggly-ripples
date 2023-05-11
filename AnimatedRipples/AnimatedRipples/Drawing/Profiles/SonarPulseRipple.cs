using System;
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
    internal class SonarPulseRipple : BaseProfile
    {
        // TODO: add IsFilled. Color Transition: enabled/disabled.
        // Add random color?        
        SolidBrush _innerBrush;
        SolidBrush _outerBursh;
        public SonarPulseRipple()
        {
            InitDrawingProfile();
        }

        private void InitDrawingProfile()
        {
            int opacity = 10;
            _innerBrush = new SolidBrush(Color.Yellow);
            _outerBursh = new SolidBrush(Color.Crimson.WithOpacity(250));           
            
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
            // 2) Make the inner ripple that must drawn last.
            _ripples.Add(
                new RippleEntry()
                {
                    IsExpandable = false,
                    IsFade = false,
                    Bounds = DrawingHelper.CreateRectangle(Width, Height, 6),
                    ShapeType = ShapeType.Ellipse,
                    Radius = 6,
                    RadiusMultiplier = 2,
                    FillBrush = _innerBrush,                    
                    IsFilled = true,
                });

        }
        /* Inputs: canvas, radius, color, animation progress: multiplier. 
            Note:
                - on animation progress -> profile.Render(); on the canvas.
                Extract them from the current drawing methods. 
                Need the canvas and the _surface. 
            TODO: Inputs/parameters: radius of the ripple, canvas size should be fixed to 300
                  but I need to test it. 
        */
    }
}
