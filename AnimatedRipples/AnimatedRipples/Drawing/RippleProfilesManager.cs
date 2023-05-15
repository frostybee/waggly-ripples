using FriskyMouse.NativeApi;
using FriskyMouse.UI;
using MaterialSkin.Animations;
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
using WinFormLayered.Drawing.Extensions;
using WinFormLayered.Drawing.Profiles;
using WinFormLayered.Drawing.Shapes;

namespace WinFormLayered.LayeredForm
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

        readonly LayeredWindow _layeredWindow;
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
            /* 
             * TODO: Include in the settings: 
             * - Flag: expandable ripple or not.
             * - Flag: color transition or not. 
             * NOTE: I can remove the specialized profiles and put 
             *      all the ripple instantiation in the BaseProfile class.
             */
            _layeredWindow = new LayeredWindow();            
            RippleType = RippleProfileType.Concentric;                                 
            RippleType = RippleProfileType.SquaredPulse;            
            RippleType = RippleProfileType.Cherry;
            RippleType = RippleProfileType.SonarPulse;
            RippleType = RippleProfileType.Spotlight;
            RippleType = RippleProfileType.Single;
            RippleType = RippleProfileType.SquaredPulse;
            RippleType = RippleProfileType.Hexagon;
            RippleType = RippleProfileType.Star;          
            RippleType = RippleProfileType.SonarPulse;
            RippleType = RippleProfileType.Diamond;

            _animationManager = new AnimationManager()
            {
                Increment = 0.020, // Control the animation duration.
                //Increment = 0.010,                
                //InterpolationType = InterpolationType.EaseOut,                
                //InterpolationType = InterpolationType.EaseInElastic
                InterpolationMode = InterpolationType.EaseOut                

            };
            _animationManager.SetDirection(AnimationDirection.InOutRepeatingIn);
            _animationManager.OnAnimationProgress += OnRipplesAnimationUpdate;
            _animationManager.OnAnimationFinished += OnRipplesAnimationFinished;
            // Make default profile.
            _currentProfile = MakeDrawingProfile(RippleType);
            SwitchProfile(RippleProfileType.Star);
        }

        public void SwitchProfile(RippleProfileType inSelectedProfile)
        {
            _currentProfile?.DisposeDrawingTools();
            _currentProfile = MakeDrawingProfile(inSelectedProfile);
        }

        private void OnRipplesAnimationUpdate(object sender)
        {
            // We process the animation frames here. 
            // We perform the drawing here.                        
            // TODO: put this in a helper method.                        
            Debug.WriteLine(_animationManager.GetProgress());
            var progress = _animationManager.GetProgress();
            _currentProfile.RenderRipples(_graphics, progress);
            //RenderRipplesProfile(_currentProfile, progress);
            _layeredWindow.SetBitmap(_surface, 255);
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
                case RippleProfileType.Diamond:
                    rippleProfile = new DiamondProfile();
                    break;
                case RippleProfileType.SonarPulse:
                    rippleProfile = new SonarPulseRipple();
                    break;
                case RippleProfileType.SquaredPulse:
                    rippleProfile = new SquaredRipple();
                    break;
                case RippleProfileType.Single:
                    rippleProfile = new CircleProfile();
                    break;
                case RippleProfileType.Cherry:
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

        private void OnRipplesAnimationFinished(object sender)
        {
            //-- Long lasting ripple: show it and hide on finish. 
            Debug.WriteLine("Finished....");
            //_layeredWindow.SetBitmap(new Bitmap(200, 200), 1);
            // Clear the _surface that was previously drawn onto the _layeredWindow window.
            //_layeredWindow.SetBitmap(_blankSurface, 1);
            _graphics.Clear(Color.Transparent);
            _layeredWindow.Hide();
        }
     
        internal void ShowRipplesAt()
        {
            POINT p = new POINT();
            NativeMethods.GetCursorPos(out p);
            _layeredWindow.PositionX = p.X +1 ;
            _layeredWindow.PositionY = p.Y +1;
            _layeredWindow.Move();
            _layeredWindow.Show();
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
                _graphics.SetAntiAliasing();                
            }
            // Clear the _surface that was previously drawn onto the _layeredWindow window.
            _layeredWindow.SetBitmap(_blankSurface, 1);
            //Debug.WriteLine("Updating....");
            // We perform the drawing here.            


            /*animate.Start(1000, 1, 1000, EasingType.QuadOut);
            animate.Complete = objAnimationManager_OnAnimationFinished;
            animate.Update = OnAnimationUpdated;*/
            //animate.Start(1000);
            if (!_animationManager.IsAnimating())
            {
                _animationManager.SetProgress(0);
                //_animationManager.StartNewAnimation(AnimationDirection.InOutIn);
                _animationManager.StartNewAnimation(AnimationDirection.In);
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
            //RenderRipplesProfile(_currentProfile, animate.Alpha);
            _currentProfile.RenderRipples(_graphics, animate.Alpha);
            _layeredWindow.SetBitmap(_surface, 255);
        }
        // Metro animation
        private void objAnimationManager_OnAnimationFinished()
        {
            //-- Long lasting ripple: show it and hide on finish. 
            Debug.WriteLine("Finished....");
            //_layeredWindow.SetBitmap(new Bitmap(200, 200), 1);
            _graphics.Clear(Color.Transparent);
            _layeredWindow.SetBitmap(_blankSurface, 1);
            _layeredWindow.Hide();
        }
        

        int _radius = 0;
    }
}
