﻿using FriskyMouse.NativeApi;

using FrostyBee.FriskyRipples.Animation;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using FrostyBee.FriskyRipples.Drawing;
using FrostyBee.FriskyRipples.Extensions;
using FrostyBee.FriskyRipples.UI;

namespace FrostyBee.FriskyRipples
{
    /// <summary>
    /// Responsible for creating, switching and animating ripple profiles. 
    /// 
    /// A ripple profile consists of a drawing that is either to be drawn or animated. 
    /// It maintains ripple instances corresponding to what the user has selected/enabled.
    /// The profiles maintained are left click, right click, and double click ripple profiles. 
    /// </summary>
    internal class RippleProfilesManager
    {
        private readonly LayeredWindow _layeredWindow;
        private Bitmap _canvas = null;
        private Bitmap _blankCanvas = null;
        /// <summary>        
        /// The drawing canvas on which the mouse click ripples will be repeatedly drawn.
        /// </summary>
        private Graphics _graphics;
        private readonly ValueAnimator _animationManager;
        private BaseProfile _currentProfile;
        public RippleProfileType RippleType { get; set; }
        public RippleProfilesManager()
        {
            _layeredWindow = new LayeredWindow();
            RippleType = RippleProfileType.SonarPulse;

            _animationManager = new ValueAnimator()
            {
                Increment = 0.020, // Control the animation duration.
                //Increment = 0.010,                
                //InterpolationType = InterpolationType.EaseOut,                
                //InterpolationType = InterpolationType.InElastic
                Interpolation = InterpolationType.Linear

            };
            _animationManager.Progressed += RipplesAnimation_Progressed;
            _animationManager.Completed += RipplesAnimation_Finished;
        }

        public void SwitchProfile(BaseProfile inProfile)
        {
            _currentProfile = inProfile;
        }

        private void RipplesAnimation_Progressed(object sender)
        {
            // We process the animation frames here.             
            var progress = _animationManager.GetProgress();
            _graphics.Clear(Color.Transparent);
            _currentProfile.RenderRipples(_graphics, progress);
            //RenderRipplesProfile(_currentProfile, progress);
            _layeredWindow.SetBitmap(_canvas, 255);
        }

        private void RipplesAnimation_Finished(object sender)
        {
            _graphics.Clear(Color.Transparent);
            _layeredWindow.Hide();
        }

        internal void ShowRipplesAt()
        {
            NativeMethods.GetCursorPos(out POINT p);
            _layeredWindow.PositionX = p.X + 1;
            _layeredWindow.PositionY = p.Y + 1;
            _layeredWindow.Move();
            _layeredWindow.Show();
            StartAnimation();
        }

        internal void StartAnimation()
        {

            if (_canvas == null)
            {
                // Init the drawing _canvas first.
                // Need to be disposed.
                // Check memory consumption of this version.
                //_canvas = DrawingHelper.CreateBitmap(300, 300, Color.White);
                _canvas = new Bitmap(200, 200, PixelFormat.Format32bppArgb);
                _blankCanvas = new Bitmap(200, 200, PixelFormat.Format32bppArgb);
                _graphics = Graphics.FromImage(_canvas);
                _graphics.SetAntiAliasing();
            }
            _currentProfile.ResetColorOpacity();
            // Clear the _canvas that was previously drawn onto the _layeredWindow window.
            _layeredWindow.SetBitmap(_blankCanvas, 1);
            if (!_animationManager.IsAnimating())
            {
                //_animationManager.StartNewAnimation(AnimationDirection.InOutIn);
                _animationManager.StartNewAnimation(_currentProfile.Options.AnimationDirection);
            }
        }

        internal void ApplySettings(ProfileOptions profileSettings)
        {
            _animationManager.Increment = profileSettings.AnimationSpeed;
            _animationManager.Interpolation = profileSettings.InterpolationType;
        }

        internal void StopAnimation()
        {
            if (_animationManager.IsAnimating())
            {
                _animationManager.Stop();
            }
        }

        internal void Dispose()
        {
            _layeredWindow?.Dispose();
            _currentProfile?.Dispose();
            _blankCanvas.Dispose();
            _graphics?.Dispose();
            _canvas?.Dispose();
        }
    }
}
