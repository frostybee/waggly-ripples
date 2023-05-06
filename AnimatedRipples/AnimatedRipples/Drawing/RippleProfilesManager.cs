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
using WinFormLayered.Drawing.Shapes;

namespace WinFormLayered.LayeredForm
{
    /// <summary>
    /// Responsible for creating and animating ripple profiles. 
    /// 
    /// A ripple profile consists of a drawing that is either to be drawn or animated. 
    /// It maintains ripple instances corresponding to what the user has selected/enabled.
    /// The profiles maintained are left click, right click, and double click ripple profiles. 
    /// </summary>
    internal class RippleProfilesManager
    {
        readonly LayeredWindow _layered;
        // NOTE: move those to the BaseProfile.
        Bitmap _surface = null;
        Bitmap _blankSurface = null;
        
        /// <summary>        
        /// The drawing canvas on which the mouse click ripples will be repeatedly drawn.
        /// </summary>
        Graphics _graphics;
        private AnimationManager _animationManager;
        private BaseProfile _currentProfile;
        public RippleProfileType RippleType { get; set; }
        public RippleProfilesManager()
        {
            _layered = new LayeredWindow();
            RippleType = RippleProfileType.Hexagon;
            RippleType = RippleProfileType.Concentric;
            RippleType = RippleProfileType.SonarPulse;
            
            _animationManager = new AnimationManager()
            {
                Increment = 0.020,
                //Increment = 0.010,                
                //AnimationType = AnimationType.EaseOut,                
                //AnimationType = AnimationType.EaseInElastic
                AnimationType = AnimationType.EaseInOutBounce

            };
            _animationManager.SetDirection(AnimationDirection.InOutRepeatingIn);
            _animationManager.OnAnimationProgress += OnProcessAnimationProgress;
            _animationManager.OnAnimationFinished += OnAnimationFinished;
            // Make default profile.
            _currentProfile = MakeDrawingProfile(RippleType);
        }
        private void OnProcessAnimationProgress(object sender)
        {
            // We process the animation frames here. 
            // We perform the drawing here.                        
            // TODO: put this in a helper method.                        
            Debug.WriteLine(_animationManager.GetProgress());
            var progress = _animationManager.GetProgress();
            RenderRipplesProfile(_currentProfile, progress);
            _layered.SetBitmap(_surface, 255);
        }

        /// <summary>
        /// Renders the ripples that are defined in a given profile.
        /// </summary>
        /// <param name="inRippleProfile">The profile to be rendered.</param>
        /// <param name="progress">The interpolated value that indicates the progress of the currently running animation. </param>
        private void RenderRipplesProfile(BaseProfile inRippleProfile, double progress)
        {
            if (inRippleProfile.RippleEntries.Count == 0)
            {
                //inRippleProfile.Draw(_graphics, _surface, progress);
             //   return;
            }
            
            _graphics.Clear(Color.Transparent);
            //TODO: move this to the ripple class. Needs to be computed there.
            var opacity = (int)(progress * 20 * 5);
            // We adjust the ripple properties every animation frame. 
            inRippleProfile.RippleEntries.ForEach(ripple =>
            {                
                // Render the ripple --> inputs: graphics, progress, surface size.                
                ripple.Opacity = opacity;
                //-- Might need to adjust the profile internal ripple definitions before rendering.
                // For instance, when animating an hexagon.
                // Render the ripple.
                ripple.Render(_graphics, progress);
            });
        }
        private BaseProfile MakeDrawingProfile(RippleProfileType inRippleType)
        {
            BaseProfile rippleProfile = null;
            // TODO: Convert this code to dynamic one. Detect type based on the selected profile and instantiate it 
            // at runtime. 
            switch (inRippleType)
            {
                case RippleProfileType.Crosshair:
                    Type t = typeof(CrosshairRipple);
                    rippleProfile = (BaseProfile)Activator.CreateInstance(t);
                    break;
                case RippleProfileType.Multiple:
                    break;
                case RippleProfileType.SonarPulse:
                    rippleProfile = new SonarPulseRipple();
                    break;
                case RippleProfileType.Circle:
                    rippleProfile = new CircleProfile();
                    break;
                case RippleProfileType.Single:
                    rippleProfile = new SingleRipple();
                    break;
                case RippleProfileType.Hexagon:
                    rippleProfile = new HexagonRipple();
                    break;
                case RippleProfileType.Square:
                    rippleProfile = new SquareRipple();
                    break;
                case RippleProfileType.Star:
                    rippleProfile = new StarRipple();
                    break;
                case RippleProfileType.Concentric:
                    rippleProfile = new ConcentricRipple();
                    break;
                case RippleProfileType.Spotlight:
                    rippleProfile = new SpotlightRipple();
                    break;
                default:
                    rippleProfile = new SpotlightRipple();
                    break;
            }
            return rippleProfile;
        }

        private void OnAnimationFinished(object sender)
        {
            //-- Long lasting ripple: show it and hide on finish. 
            Debug.WriteLine("Finished....");
            //_layered.SetBitmap(new Bitmap(200, 200), 1);
            // Clear the _surface that was previously drawn onto the _layered window.
            //_layered.SetBitmap(_blankSurface, 1);
            _graphics.Clear(Color.Transparent);
            _layered.Hide();
        }

        internal void ShowRipplesAt()
        {
            POINT p = new POINT();
            NativeMethods.GetCursorPos(out p);
            _layered.PositionX = p.X;
            _layered.PositionY = p.Y;
            _layered.Move();
            _layered.Show();
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
                //_surface = DrawingHelper.CreateBitmap(300, 300, Color.White);
                _surface = new Bitmap(200, 200, PixelFormat.Format32bppArgb);
                _blankSurface = new Bitmap(200, 200, PixelFormat.Format32bppArgb);
                _graphics = Graphics.FromImage(_surface);
                DrawingHelper.SetAntiAliasing(_graphics);
            }
            // Clear the _surface that was previously drawn onto the _layered window.
            _layered.SetBitmap(_blankSurface, 1);
            Debug.WriteLine("Updating....");
            // We perform the drawing here.            


            /*animate.Start(1000, 1, 100, EasingType.QuintInOut);
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
            //_currentProfile.Draw(_graphics, _surface, animate.Alpha);
            RenderRipplesProfile(_currentProfile, animate.Alpha);
            _layered.SetBitmap(_surface, 255);
        }
        // Metro animation
        private void objAnimationManager_OnAnimationFinished()
        {
            //-- Long lasting ripple: show it and hide on finish. 
            Debug.WriteLine("Finished....");
            //_layered.SetBitmap(new Bitmap(200, 200), 1);
            _graphics.Clear(Color.Transparent);
            _layered.SetBitmap(_blankSurface, 1);
            _layered.Hide();
        }
        int _radius = 0;
    }
}
