using FrostyBee.FriskyRipples.Animation;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using FrostyBee.FriskyRipples.Drawing;
using FrostyBee.FriskyRipples.Extensions;
using FrostyBee.FriskyRipples.LayeredForm;
using FrostyBee.FriskyRipples.Helpers;

namespace FrostyBee.FriskyRipples
{
    public partial class RippleViewerForm : Form
    {
        private readonly RippleProfilesManager _profilesManager = new RippleProfilesManager();        
        private AnimationManager _animationManager;
        private BaseProfile _currentProfile;        
        private Bitmap _canvas;
        Bitmap _blankCanvas = null;
        private Graphics _graphics;

        public RippleViewerForm()
        {
            InitializeComponent();            
            //            
            _currentProfile = new SonarPulseProfile();            
            _animationManager = new AnimationManager()
            {
                Increment = 0.010, // Control the animation duration.                                         
                InterpolationMode = InterpolationType.Linear
            };            
            DoubleBuffered = true;
            this.Load += RippleViewerForm_Load;
            this.Click += RippleViewerForm_Click;
            cmbProfilesList.SelectedIndexChanged += CmbProfilesList_SelectedIndexChanged;                    
            _animationManager.OnAnimationProgress += OnRipplesAnimation_Update;
            _animationManager.OnAnimationFinished += OnRipplesAnimation_Finished;           
        }

        private void RippleViewerForm_Click(object sender, EventArgs e)
        {
            // Render the current ripple profile onto the layered window
            // where the mouse has been clicked on the form.
            _profilesManager.ShowRipplesAt();
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            StartAnimation();
        }

        private void StartAnimation()
        {
            pcbRipplePreview.Image = _canvas;
            if (!_animationManager.IsAnimating())
            {
                _animationManager.SetProgress(0);                
                _animationManager.StartNewAnimation(_currentProfile.Options.AnimationDirection);
            }
        }

        private void OnRipplesAnimation_Update(object sender)
        {        
            if (_animationManager.IsAnimating())
            {            
                _graphics.Clear(Color.Transparent);
                // Draw and animate the selected profile. 
                var progress = _animationManager.GetProgress();
                _currentProfile.RenderRipples(_graphics, progress);
                //e.Graphics.DrawEllipse(new Pen(Brushes.Red), new Rectangle(pcbRipplePreview.Width / 2, pcbRipplePreview.Width / 2, 100, 100));
            }
            pcbRipplePreview.Invalidate();
        }

        private void RippleViewerForm_Load(object sender, EventArgs e)
        {
            // Populate the combo box with the ripple profiles descriptions.            
            cmbProfilesList.PopulateFromEnum(typeof(RippleProfileType));
            cmbAnimDirection.PopulateFromEnum(typeof(AnimationDirection));
            cmbInterpolationMode.PopulateFromEnum(typeof(InterpolationType));
            //-- Create the drawing canvas on which the ripples will be drawn.
            _canvas = DrawingHelper.CreateBitmap(pcbRipplePreview.Width, pcbRipplePreview.Height, Color.White);
            _blankCanvas = DrawingHelper.CreateBitmap(pcbRipplePreview.Width, pcbRipplePreview.Height, Color.White);
            pcbRipplePreview.Image = _canvas;
            pcbRipplePreview.BackColor = Color.White;
            _graphics = Graphics.FromImage(_canvas);
            _graphics.SetAntiAliasing(); // Need to set it once.
        }

        private void OnRipplesAnimation_Finished(object sender)
        {
            //-- Long lasting ripple: show it and hide on finish. 
            Debug.WriteLine("Finished....");
            // Clear the _surface that was previously drawn onto the _layeredWindow window.                                    
            pcbRipplePreview.Image = _blankCanvas;            
        }
        private void BtnLayeredWindow_Click(object sender, EventArgs e)
        {
            _profilesManager.ShowRipplesAt();
        }       
                
        private void SliderAnimSpeed_Scroll(object sender, EventArgs e)
        {
            lblAnimSpeed.Text = sliderAnimSpeed.Value.ToString();
            // Increase the animation speed.
            double speed = (double)sliderAnimSpeed.Value / 1000;
            _animationManager.Increment = speed;
            _currentProfile.Options.AnimationSpeed = speed;
            _profilesManager.ApplySettings(_currentProfile.Options);
        }
        private void CmbProfilesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            // A ripple profile has been selected. Switch to the newly selected profile. 
            RippleProfileType profile = cmbProfilesList.ParseEnumValue<RippleProfileType>();                        
            BaseProfile _newProfile = ConstructableFactory.Instantiate<BaseProfile>(profile);
            _newProfile.Options = _currentProfile.Options;
            _profilesManager.SwitchProfile(_newProfile);
            _currentProfile?.Dispose();
            _currentProfile = _newProfile;
            StartAnimation();
        }
        private void CmbAnimDirection_SelectedIndexChanged(object sender, EventArgs e)
        {
            // The direction of the animation has been changed.                                     
            _currentProfile.Options.AnimationDirection = cmbAnimDirection.ParseEnumValue<AnimationDirection>();                         
        }
        private void CmbInterpolationMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            // The animation's interpolation mode has been changed.                                    
            InterpolationType interpolation = cmbInterpolationMode.ParseEnumValue<InterpolationType>();
            _animationManager.InterpolationMode = interpolation;
            _currentProfile.Options.AnimInteroplation = interpolation;
            _profilesManager.ApplySettings(_currentProfile.Options);
        }
        
        private void BtnStopAnimation_Click(object sender, EventArgs e)
        {
            if (_animationManager.IsAnimating())
            {
                _animationManager.Stop();
                // Clear the preview.
            }
        }
        private void ChkbColorTransition_CheckedChanged(object sender, EventArgs e)
        {
            _currentProfile.Options.IsColorTransition = chkbColorTransition.Checked;
            Debug.WriteLine(_currentProfile.Options.IsColorTransition.ToString());
        }
    }
}
