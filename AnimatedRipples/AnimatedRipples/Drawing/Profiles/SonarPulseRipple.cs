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
        public SonarPulseRipple()
        {
        }

        /* Inputs: canvas, radius, color, animation progress: multiplier. 
            Note:
                - on animation progress -> profile.Render(); on the canvas.
                Extract them from the current drawing methods. 
                Need the canvas and the _surface. 
            TODO: Inputs/parameters: radius of the ripple, canvas size should be fixed to 300
                  but I need to test it. 
        */
        public override void Draw(Graphics graphics, Bitmap surface, double progress)
        {
            graphics.Clear(Color.Transparent);
            int baseRadius = 15;
            int innerRadius = 8;                                    
            int opacityMultiplier = 5;            
            // FIXME: the color opacity needs to be validated: it's crashing when a spring interpolation is applied.
            // Color of the large ripple
            var radius = (int)(progress * baseRadius * 7);
            Color rippleColor = Color.DarkRed.WithOpacity(radius * opacityMultiplier);                        
            using (SolidBrush innerBrush = new SolidBrush(Color.DarkTurquoise))
            using (SolidBrush outerBursh = new SolidBrush(rippleColor))
            {             
                Rectangle outerRect = DrawingHelper.CreateRectangle(surface.Width, surface.Height, radius);                                
                graphics.FillEllipse(outerBursh, outerRect);
                // Render the inner ripple. It must drawn last.
                Rectangle innerRect = DrawingHelper.CreateRectangle(surface.Width, surface.Height, innerRadius);
                graphics.FillEllipse(innerBrush, innerRect);
            }
        }
    }
}
