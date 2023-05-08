using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormLayered.Drawing.Shapes;

namespace WinFormLayered.Drawing
{
    internal abstract class BaseProfile
    {
        protected readonly List<RippleEntry> _ripples = new List<RippleEntry>();
        public int Width { get; set; } = 200;
        public int Height { get; set; } = 200;
        public int BaseRadius { get; set; } = 10;
        public List<RippleEntry> RippleEntries { get => _ripples; }

        // Is it better to use an interface with public properties?

        /// <summary>
        /// Renders the ripples that are defined in a given profile.
        /// </summary>
        /// <param name="inRippleProfile">The profile to be rendered.</param>
        /// <param name="progress">The interpolated value that indicates the progress of the currently running animation. </param>
        public void RenderRipples(Graphics _graphics, double progress)
        {
            
            Debug.WriteLine("Progress: " + progress);
            _graphics.Clear(Color.Transparent);
            //TODO: move this to the ripple class. Needs to be computed there.
            var opacity = (int)(progress * 20 * 5);
            // We adjust the ripple properties every animation frame. 
            _ripples.ForEach(ripple =>
            {
                // Render the ripple --> inputs: graphics, progress, surface size.                
                ripple.Opacity = opacity;
                //-- Might need to adjust the profile internal ripple definitions before rendering.
                // For instance, when animating an hexagon.
                // Render the ripple.                
                ripple.Render(_graphics, progress);
            });
        }
        
    }
}