using FriskyMouse.NativeApi;
using FriskyMouse.UI;
using MaterialWinforms.Animations;
using ReaLTaiizor.Animate.Metro;
using ReaLTaiizor.Enum.Metro;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormLayered.Drawing;

namespace WinFormLayered.LayeredForm
{
    /// <summary>
    /// Responsible for creating and animating ripple profiles.
    /// </summary>
    internal class DrawingManager
    {
        LayeredWindow layered;
        // NOTE: move those to the BaseRipple.
        Bitmap _surface = null;
        Bitmap _blankSurface = null;
        /// <summary>
        /// The drawing canvas on which the mouse click ripples will be repeatedly drawn.
        /// </summary>
        Graphics _graphics;
        private AnimationManager _animationManager;
        private BaseRipple _currentProfile;
        public DrawingManager()
        {
            this.layered = new LayeredWindow();

            _animationManager = new AnimationManager()
            {
                Increment = 0.020,
                //Increment = 0.010,
                //Increment = 0.070,
                //AnimationType = AnimationType.EaseOut,                
                //AnimationType = AnimationType.SpringInteropolator
                AnimationType = AnimationType.SpringInteropolator

            };
            _animationManager.SetDirection(AnimationDirection.InOutRepeatingIn);
            _animationManager.OnAnimationProgress += ObjAnimationManager_OnAnimationProgress;
            _animationManager.OnAnimationFinished += objAnimationManager_OnAnimationFinished;
        }

        private void ObjAnimationManager_OnAnimationProgress(object sender)
        {
            // We perform the drawing here.                        
            // TODO: put this in a helper method.                        
            Debug.WriteLine(_animationManager.GetProgress());
            _currentProfile.Draw(_graphics, _surface, _animationManager.GetProgress());
            layered.SetBitmap(_surface, 255);
        }

        internal void ShowRipplesAt()
        {
            POINT p = new POINT();
            NativeMethods.GetCursorPos(out p);
            layered.PositionX = p.X;
            layered.PositionY = p.Y;
            layered.Move();
            layered.Show();
            StartAnimation();
        }
        IntAnimate animate = new IntAnimate();//animate.Start(int duration, T initial, T end, EasingType easing = EasingType.Linear)    
        internal void StartAnimation()
        {

            if (_surface == null)
            {
                // Init the drawing _surface first.
                // Need to be disposed.
                // Check memory consumption of this version.
                _surface = new Bitmap(200, 200, PixelFormat.Format32bppArgb);
                _blankSurface = new Bitmap(200, 200, PixelFormat.Format32bppArgb);
                _graphics = Graphics.FromImage(_surface);
                DrawingHelper.SetAntiAliasing(_graphics);
                // TODO: Implement a profile switch.
                //_currentProfile = new SingleRipple(
                _currentProfile = new ConcentricRipple();
            }
            // Clear the _surface that was previously drawn onto the layered window.
            layered.SetBitmap(_blankSurface, 1);
            Debug.WriteLine("Updating....");
            // We perform the drawing here.            


            /*animate.Start(1000, 1, 250, EasingType.SineIn);
            animate.Complete = objAnimationManager_OnAnimationFinished;
            animate.Update = OnAnimationUpdated;*/
            //animate.Start(1000);
            if (!_animationManager.IsAnimating())
            {
                _animationManager.SetProgress(0);
                //_animationManager.StartNewAnimation(AnimationDirection.InOutIn);
                _animationManager.StartNewAnimation(AnimationDirection.InOutIn);
            }

        }
        // Metro animation: This is actually working fine.
        private void OnAnimationUpdated(int value)
        {
            Debug.WriteLine("Updated value: " + animate.Value);
            Debug.WriteLine("Updated Alpha: " + animate.Alpha);
            // We perform the drawing here.                        
            // TODO: put this in a helper method.                        
            _currentProfile.Draw(_graphics, _surface, animate.Alpha);
            layered.SetBitmap(_surface, 255);
        }
        // Metro animation
        private void objAnimationManager_OnAnimationFinished()
        {
            //-- Long lasting ripple: show it and hide on finish. 
            Debug.WriteLine("Finished....");
            //layered.SetBitmap(new Bitmap(200, 200), 1);
            _graphics.Clear(Color.Transparent);
            layered.Hide();
        }
        int _radius = 0;
        private void objAnimationManager_OnAnimationFinished(object sender)
        {
            //-- Long lasting ripple: show it and hide on finish. 
            Debug.WriteLine("Finished....");
            //layered.SetBitmap(new Bitmap(200, 200), 1);
            // Clear the _surface that was previously drawn onto the layered window.
            //layered.SetBitmap(_blankSurface, 1);
            _graphics.Clear(Color.Transparent);
            layered.Hide();
        }
    }
}
