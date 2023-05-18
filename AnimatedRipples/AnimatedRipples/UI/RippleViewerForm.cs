using FriskyMouse.UI;
using MaterialSkin.Animations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormLayered.Drawing;
using WinFormLayered.Drawing.Extensions;
using WinFormLayered.Drawing.Profiles;
using WinFormLayered.Drawing.Shapes;
using WinFormLayered.LayeredForm;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormLayered
{
    public partial class RippleViewerForm : Form
    {
        RippleProfilesManager _profilesManager;
        private AnimationManager _animationManager;
        private BaseProfile _currentProfile;
        private AnimationDirection _animationDirection;
        public RippleViewerForm()
        {
            InitializeComponent();            
            _profilesManager = new RippleProfilesManager();
            _currentProfile = new SonarPulseProfile();
            _animationDirection = AnimationDirection.In;
            _animationManager = new AnimationManager()
            {
                Increment = 0.010, // Control the animation duration.                                         
                InterpolationMode = InterpolationType.EaseOut
            };
            pcbRipplePreview.BackColor = Color.Transparent;
            //pcbRipplePreview.BringToFront();
            DoubleBuffered = true;
            this.Load += RippleViewerForm_Load;
            cmbProfilesList.SelectedIndexChanged += CmbProfilesList_SelectedIndexChanged;
            pcbRipplePreview.Paint += PcbRipplePreview_Paint;                        
            _animationManager.OnAnimationProgress += OnRipplesAnimation_Update;
            _animationManager.OnAnimationFinished += OnRipplesAnimation_Finished;           
        }
        private void PcbRipplePreview_Paint(object sender, PaintEventArgs e)
        {
            if (_animationManager.IsAnimating())
            {
                e.Graphics.SetAntiAliasing();
                e.Graphics.Clear(Color.White);                
                // Draw and animate the selected profile. 
                var progress = _animationManager.GetProgress();
                _currentProfile.RenderRipples(e.Graphics, progress);
                //e.Graphics.DrawEllipse(new Pen(Brushes.Red), new Rectangle(pcbRipplePreview.Width / 2, pcbRipplePreview.Width / 2, 100, 100));

            }
        }
        private void btnPreview_Click(object sender, EventArgs e)
        {
            StartAnimation();
        }

        private void StartAnimation()
        {
            if (!_animationManager.IsAnimating())
            {
                _animationManager.SetProgress(0);
                //_animationManager.StartNewAnimation(AnimationDirection.InOutIn);
                _animationManager.StartNewAnimation(_animationDirection);
            }
        }

        private void OnRipplesAnimation_Update(object sender)
        {
            // We process the animation frames here. 
            // We perform the drawing here.                        
            // TODO: put this in a helper method.                        
            Debug.WriteLine(_animationManager.GetProgress());
            var progress = _animationManager.GetProgress();
            //_currentProfile.RenderRipples(_graphics, progress);
            //RenderRipplesProfile(_currentProfile, progress);
            //_layeredWindow.SetBitmap(_surface, 255);
            pcbRipplePreview.Invalidate();
        }

        private void RippleViewerForm_Load(object sender, EventArgs e)
        {
            // Populate the combo box with the ripple profiles descriptions.            
            cmbProfilesList.PopulateFromEnum(typeof(RippleProfileType));
            cmbAnimDirection.PopulateFromEnum(typeof(AnimationDirection));
            cmbInterpolationMode.PopulateFromEnum(typeof(InterpolationType));
        }

        private void OnRipplesAnimation_Finished(object sender)
        {
            //-- Long lasting ripple: show it and hide on finish. 
            Debug.WriteLine("Finished....");
            //_layeredWindow.SetBitmap(new Bitmap(200, 200), 1);
            // Clear the _surface that was previously drawn onto the _layeredWindow window.
            //_layeredWindow.SetBitmap(_blankSurface, 1);
            //_graphics.Clear(Color.Transparent);
            //_layeredWindow.Hide();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            _profilesManager.ShowRipplesAt();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //_layeredWindow.Hide();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Test a shadow around a circle.

        }
        private void SliderAnimSpeed_Scroll(object sender, EventArgs e)
        {
            lblAnimSpeed.Text = sliderAnimSpeed.Value.ToString();
            // Increase the speed of the animation.
            _animationManager.Increment = (double)sliderAnimSpeed.Value / 1000;
        }
        private void CmbProfilesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            // A ripple profile has been selected. Switch to the newly selected profile. 
            RippleProfileType profile = cmbProfilesList.ParseEnumValue<RippleProfileType>();            
            _currentProfile.Dispose();
            _currentProfile = BaseProfile.CreateProfile(profile);            
            StartAnimation();
        }
        private void CmbAnimDirection_SelectedIndexChanged(object sender, EventArgs e)
        {
            // The direction of the animation has been changed.                                     
            _animationDirection = cmbAnimDirection.ParseEnumValue<AnimationDirection>();
        }
        private void CmbInterpolationMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            // The animation's interpolation mode has been changed.                                    
            _animationManager.InterpolationMode = cmbInterpolationMode.ParseEnumValue<InterpolationType>();
        }
        
        private void BtnStopAnimation_Click(object sender, EventArgs e)
        {
            if (_animationManager.IsAnimating())
            {
                _animationManager.Stop();
                // Clear the preview.
            }
        }    
    }
}
