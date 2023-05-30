﻿using FrostyBee.FriskyRipples.Animation;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using FrostyBee.FriskyRipples.Drawing;
using FrostyBee.FriskyRipples.Extensions;
using FrostyBee.FriskyRipples.Helpers;
using FrostyBee.FriskyRipples.Attributes;


namespace FrostyBee.FriskyRipples
{
    public partial class RippleViewerForm : Form
    {
        private readonly RippleProfilesManager _profilesManager = new RippleProfilesManager();        
        private readonly ValueAnimator _rippleValueAnimator;
        private BaseProfile _currentProfile;        
        private Bitmap _canvas;
        Bitmap _blankCanvas = null;
        private Graphics _graphics;

        public RippleViewerForm()
        {
            InitializeComponent();            
            //            
            _currentProfile = new SonarPulseProfile();            
            _rippleValueAnimator = new ValueAnimator()
            {
                Increment = 0.010, // Control the animation duration.                                         
                Interpolation = InterpolationType.Linear
            };            
            DoubleBuffered = true;
            this.Load += RippleViewerForm_Load;
            this.Click += RippleViewerForm_Click;
            Application.ApplicationExit += Application_ApplicationExit;
            cmbProfilesList.SelectedIndexChanged += CmbProfilesList_SelectedIndexChanged;                    
            _rippleValueAnimator.Progressed += OnRipplesAnimation_Progressed;
            _rippleValueAnimator.Completed += OnRipplesAnimation_Completed;           
        }

        private void Application_ApplicationExit(object sender, EventArgs e)
        {
            _currentProfile?.Dispose();
        }

        private void RippleViewerForm_Click(object sender, EventArgs e)
        {
            // Render the current ripple profile onto the layered window
            // where the mouse has been clicked on the form.
            _profilesManager.ShowRipplesAt();
        }

        private void BtnPreview_Click(object sender, EventArgs e)
        {
            StartAnimation();
        }

        private void StartAnimation()
        {
            pcbRipplePreview.Image = _canvas;
         //   StopAnimation();
            _rippleValueAnimator.StartNewAnimation(_currentProfile.Options.AnimationDirection);
            if (!_rippleValueAnimator.IsAnimating())
            {                
                //_animationManager.StartNewAnimation(_currentProfile.Options.AnimationDirection);
                //_animationManager.StartNewAnimation(AnimationDirection.Out);
            }
        }
        private void StopAnimation()
        {
            if (_rippleValueAnimator.IsAnimating())
            {
                _rippleValueAnimator.Stop();
                // Clear the preview.
            }
        }
        private void OnRipplesAnimation_Progressed(object sender)
        {        
            if (_rippleValueAnimator.IsAnimating())
            {            
                _graphics.Clear(Color.Transparent);
                // Draw and animate the selected profile. 
                var progress = _rippleValueAnimator.GetProgress();
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

        private void OnRipplesAnimation_Completed(object sender)
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
            AdjustAnimationSpeed(sliderAnimSpeed.Value);            
        }
        private void CmbProfilesList_SelectedIndexChanged(object sender, EventArgs e)
        {            
            // Switch to the newly selected profile. 
            RippleProfileType profileType = cmbProfilesList.ParseEnumValue<RippleProfileType>();                        
            BaseProfile _newProfile = ConstructableFactory.GetInstanceOf<BaseProfile>(profileType);
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
            StartAnimation();
        }
        private void CmbInterpolationMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            // The animation's interpolation mode has been changed.                                     
            InterpolationType interpolation = cmbInterpolationMode.ParseEnumValue<InterpolationType>();
            _rippleValueAnimator.Interpolation = interpolation;
            _currentProfile.Options.InterpolationType = interpolation;
            _profilesManager.ApplySettings(_currentProfile.Options);
            // Adjust the animation speed based on the recommended value associated with the selected 
            // interpolation mode. 
            DefaultSpeedAttribute speedAttribute = interpolation.GetEnumAttribute<DefaultSpeedAttribute>();
            AdjustAnimationSpeed(speedAttribute.Speed);
            sliderAnimSpeed.Value = speedAttribute.Speed;
        }

        private void AdjustAnimationSpeed(int speed)
        {            
            lblAnimSpeed.Text = speed.ToString();
            // Increase the animation speed.
            double speedRate = (double)speed / 1000;
            _rippleValueAnimator.Increment = speedRate;
            _currentProfile.Options.AnimationSpeed = speedRate;
            _profilesManager.ApplySettings(_currentProfile.Options);
        }

        private void BtnStopAnimation_Click(object sender, EventArgs e)
        {            
            StopAnimation();
            _profilesManager.StopAnimation();
        }       

        private void ChkbColorTransition_CheckedChanged(object sender, EventArgs e)
        {
            _currentProfile.Options.IsColorTransition = chkbColorTransition.Checked;
            _currentProfile.ResetColorOpacity();
            Debug.WriteLine(_currentProfile.Options.IsColorTransition.ToString());
        }
    }
}
