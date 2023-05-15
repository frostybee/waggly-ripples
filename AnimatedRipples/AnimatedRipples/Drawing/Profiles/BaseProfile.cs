using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormLayered.Drawing.Attributes;
using WinFormLayered.Drawing.Extensions;
using WinFormLayered.Drawing.Profiles;
using WinFormLayered.Drawing.Shapes;

namespace WinFormLayered.Drawing
{
    /// <summary>
    /// Each profile maintains its list of ripples. 
    /// </summary>
    internal abstract class BaseProfile : IDisposable
    {
        private bool disposedValue;
        protected readonly List<RippleEntry> _ripples = new List<RippleEntry>();

        #region Properties
        public int Width { get; set; } = 200;
        public int Height { get; set; } = 200;
        public int BaseRadius { get; set; } = 10;
        public List<RippleEntry> RippleEntries { get => _ripples; }
        public RippleProfileSettings Options { get; set; }
        #endregion

        // Is it better to use an interface with public properties?

        /// <summary>
        /// Renders the ripples that are defined in a given profile.
        /// </summary>
        /// <param name="inRippleProfile">The profile to be rendered.</param>
        /// <param name="progress">The interpolated value that indicates the progress of the currently running animation. </param>
        public void RenderRipples(Graphics _graphics, double progress)
        {
            Debug.WriteLine("Progress: " + progress);
            //_graphics.Clear(Color.Transparent);
            //TODO: move this to the ripple class. Needs to be computed there.
            var opacity = (int)(progress * 20 * 5);
            // We adjust the ripple properties every animation frame. 
            _ripples.ForEach(ripple =>
            {
                // Draw the ripple --> inputs: graphics, progress, surface size.                
                ripple.Opacity = opacity;
                //-- Might need to adjust the profile internal ripple definitions before rendering.
                // For instance, when animating an hexagon.
                // Draw the ripple.                
                ripple.Draw(_graphics, progress);
            });
        }
        public static BaseProfile MakeProfile(RippleProfileType profileType)
        {
            ConstructableEnumAttribute attribute = profileType.GetEnumAttribute<ConstructableEnumAttribute>();
            Debug.WriteLine(attribute.Type);
            BaseProfile profile = (BaseProfile)Activator.CreateInstance(attribute.Type);
            return profile;

        }
        public void DisposeDrawingTools()
        {
            _ripples.ForEach(ripple =>
            {
                ripple.FillBrush?.Dispose();
                ripple.OutlinePen?.Dispose();
            });
            _ripples?.Clear();
            Debug.WriteLine("Disposing drawing tools...");
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // Dispose of the drawing tools such as brushes, pens, etc.
                    DisposeDrawingTools();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}