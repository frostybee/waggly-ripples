using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO.Ports;
using FrostyBee.FriskyRipples.Attributes;
using FrostyBee.FriskyRipples.Extensions;

namespace FrostyBee.FriskyRipples.Drawing
{
    /// <summary>
    /// Each profile maintains its list of ripples. 
    /// </summary>
    internal abstract class BaseProfile :  IDisposable, IConstructable
    {
        private bool disposedValue;
        protected readonly List<RippleEntry> _ripples = new List<RippleEntry>();

        #region Properties
        public int Width { get; set; } = 200;
        public int Height { get; set; } = 200;
        public int BaseRadius { get; set; } = 10;        
        public ProfileOptions Options { get; set; } = new ProfileOptions();
        #endregion

        // Is it better to use an interface with public properties?

        /// <summary>
        /// Prepares and renders the ripples that are defined in a given profile.
        /// </summary>
        /// <param name="inRippleProfile">The profile to be rendered.</param>
        /// <param name="progress">The interpolated value that indicates the progress of the currently running animation. </param>
        public void RenderRipples(Graphics _graphics, double progress)
        {                                   
            // We adjust the ripple properties every animation frame. 
            _ripples.ForEach(ripple =>
            {                
                if (Options.IsColorTransition)
                {
                    Debug.WriteLine(Options.IsColorTransition.ToString());
                    // We fade the color of the ripple based on the current animation's progress value.
                    ripple.AdjustColorOpacity(progress);
                }
                ripple.ExpandRadius(progress);                
                // Draw the ripple.                
                ripple.Draw(_graphics);
            });
        }

        internal void ResetColorOpacity()
        {
            // We adjust the ripple properties every animation frame. 
            _ripples.ForEach(ripple =>
            {
                /*if (Options.IsColorTransition)
                {
                    Debug.WriteLine(Options.IsColorTransition.ToString());
                    // We fade the color of the ripple based on the current animation's progress value.
                    ripple.AdjustColorOpacity(progress);
                }*/
                ripple.ResetColor(255);
            });
        }

        public void DisposeDrawingTools()
        {
            _ripples.ForEach(ripple =>
            {
                // Dispose of the allocated drawing tools.
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