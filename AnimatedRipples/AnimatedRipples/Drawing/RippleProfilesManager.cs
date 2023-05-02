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
        LayeredWindow layered;
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
            this.layered = new LayeredWindow();
            RippleType = RippleProfileType.Circle;
            _animationManager = new AnimationManager()
            {
                Increment = 0.020,
                //Increment = 0.010,
                //Increment = 0.070,
                //AnimationType = AnimationType.EaseOut,                
                //AnimationType = AnimationType.SpringInteropolator
                AnimationType = AnimationType.CustomQuadratic

            };
            _animationManager.SetDirection(AnimationDirection.InOutRepeatingIn);
            _animationManager.OnAnimationProgress += OnProcessAnimationProgress;
            _animationManager.OnAnimationFinished += OnAnimationFinished;
            _currentProfile = MakeDrawingProfile(RippleType);
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

        private void OnProcessAnimationProgress(object sender)
        {
            // We process the animation frames here. 
            // We perform the drawing here.                        
            // TODO: put this in a helper method.                        
            Debug.WriteLine(_animationManager.GetProgress());            
            var progress = _animationManager.GetProgress();
            RenderRippleProfile(_currentProfile, progress);            
            layered.SetBitmap(_surface, 255);
        }

        private void RenderRippleProfile(BaseProfile currentProfile, double progress)
        {
            _graphics.Clear(Color.Transparent);
            var opacity = (int)(progress * 35 * 5);
            // We adjust the ripple properties every animation frame. 
            _currentProfile.RippleEntries.ForEach(ripple =>
            {
                // Render the ripple --> inputs: graphics, progress, surface size.
                int rippleSize = (ripple.IsFixed) ? ripple.BaseRadius : (int)(progress * ripple.GetExpandedRadius());
                ripple.Bounds = (ripple.IsFixed) ? ripple.Bounds : DrawingHelper.CreateRectangle(200, 200, rippleSize);
                ripple.Opacity = opacity;
                ripple.Draw(_graphics);
            });
        }

        private void OnAnimationFinished(object sender)
        {
            //-- Long lasting ripple: show it and hide on finish. 
            Debug.WriteLine("Finished....");
            //layered.SetBitmap(new Bitmap(200, 200), 1);
            // Clear the _surface that was previously drawn onto the layered window.
            //layered.SetBitmap(_blankSurface, 1);
            _graphics.Clear(Color.Transparent);
            layered.Hide();
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
            }
            // Clear the _surface that was previously drawn onto the layered window.
            layered.SetBitmap(_blankSurface, 1);
            Debug.WriteLine("Updating....");
            // We perform the drawing here.            


            /*animate.Start(1000, 1, 250, EasingType.SineIn);
            animate.Complete = OnAnimationFinished;
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
    }
}
