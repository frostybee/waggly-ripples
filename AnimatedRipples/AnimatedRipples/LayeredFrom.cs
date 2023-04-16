using Bee.GlobalHooks.NativeApi;
using MaterialWinforms.Animations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormLayered
{
    public partial class LayeredFrom : Form
    {
        private AnimationManager objAnimationManager;
        private Point _Origin;
        private Brush FillBrush;
        private Bitmap Original;
        private Bitmap Final;
        private Boolean _StyleWurdeGesetzt = false;
        private Pen _ColorSchemePen;
        private Form _BaseForm;
        [DllImport("user32.dll", SetLastError = true)]

        private static extern UInt32 GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]

        static extern int SetWindowLong(IntPtr hWnd, int nIndex, IntPtr dwNewLong);

        [DllImport("user32.dll")]

        static extern bool SetLayeredWindowAttributes(IntPtr hwnd, uint crKey, byte bAlpha, uint dwFlags);

        public const int GWL_EXSTYLE = -20;

        public const int WS_EX_LAYERED = 0x80000;

        public const int WS_EX_TRANSPARENT = 0x20;

        public const int LWA_ALPHA = 0x2;

        public const int LWA_COLORKEY = 0x1;
        public LayeredFrom()
        {
            MakeFormLayered();
            InitializeComponent();
            //BackColor = Color.;
            _BaseForm = this;

            objAnimationManager = new AnimationManager()
            {
                Increment = 0.012,
                //Increment = 0.010,
                //Increment = 0.070,
                //AnimationType = AnimationType.EaseOut,                
                //AnimationType = AnimationType.SpringInteropolator
                AnimationType = AnimationType.Linear

            };
            objAnimationManager.SetDirection(AnimationDirection.InOutRepeatingIn);
            DoubleBuffered = true;
            objAnimationManager.OnAnimationProgress += sender => Invalidate();
            objAnimationManager.OnAnimationFinished += objAnimationManager_OnAnimationFinished;
            _ColorSchemePen = new Pen(new SolidBrush(Color.DarkRed), 3);

        }
        private void objAnimationManager_OnAnimationFinished(object sender)
        {
            //-- Long lasting ripple: show it and hide on finish. 
            Debug.WriteLine("Finished....");
            Hide();
        }

        private void MakeFormLayered()
        {
            //IMPORTANT: @SEE: https://learn.microsoft.com/en-us/archive/msdn-magazine/2006/march/practical-tips-for-boosting-the-performance-of-windows-forms-apps
            // Making the form run faster. 

            FormBorderStyle = FormBorderStyle.None;
            ShowInTaskbar = false;
            SetWindowLong(this.Handle, GWL_EXSTYLE, (IntPtr)(GetWindowLong(this.Handle, GWL_EXSTYLE) | WS_EX_LAYERED | WS_EX_TRANSPARENT));
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true); // OR DoubleBufferred = true; // sets both flags

            //SetWindowLong(this.Handle, GWL_EXSTYLE, (IntPtr)(GetWindowLong(this.Handle, (int)ExtendedWinStyles.WS_CUSTOM_TRASPARENT_WINDOW)));            
            // set transparency to 50% (128)
            TopMost = true;
            //SetLayeredWindowAttributes(this.Handle, 0, 225, LWA_ALPHA);            
            // Make it transparent.

            //SetStyle(ControlStyles.SupportsTransparentBackColor, true);            
            // Make the form transparent.
            this.BackColor = Color.White;
            this.TransparencyKey = Color.White;
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (Final == null)
            {
                //Final = CreateImage();
                //FillBrush = new TextureBrush(Final);
            }
            //DrawManyRipples(e.Graphics);
            DrawExpandingCircle(e.Graphics);
        }

        private void DrawExpandingCircle(Graphics graphics)
        {
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphics.CompositingQuality = CompositingQuality.HighQuality;
            graphics.Clear(Color.Tan);
            var animationValue = objAnimationManager.GetProgress();
            int baseRadius = 20;
            // Expand the size of the radius.
            var rippleRadius = (int)(animationValue * baseRadius * 2);
            Rectangle inner = new Rectangle(100 - 10 / 2, 100 - 10 / 2, 10, 10);
            graphics.FillEllipse(new SolidBrush(Color.LightBlue), inner);
            Rectangle outer = new Rectangle(100 - rippleRadius / 2, 100 - rippleRadius / 2, rippleRadius, rippleRadius);
            // Adjust the ripple's color based on the current progress of the running animation. 
            // NOTE: the value of the opacity needs to be validated < 255
            //Color rippleColor = Color.FromArgb(((byte)250 - (byte)(objAnimationManager.GetProgress() * 120 )), Color.Red);
            Color rippleColor = Color.Red;
            //graphics.FillEllipse(new SolidBrush(rippleColor), outer);
            graphics.DrawEllipse(new Pen(Color.Blue, 2), outer);
            // TODO: Draw a circle outline à la Google Maps ripple
            // - Also, draw circle in the middle after the inner one. 
            // TODO: Look for drawing helpers in ShareX and other libraries. 
        }

        private void DrawManyRipples(Graphics graphics)
        {
            //e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            //e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;            
            //e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;

            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.CompositingQuality = CompositingQuality.HighQuality;
            graphics.Clear(Color.Tan);

            // NOTES: Here we paint the ripple. 
            // TODO: have a look at ShareX project and see how the created the layered window. 

            //Rectangle CurrentRect = CalculateCurrentRect();
            //graphics.FillEllipse(FillBrush, CurrentRect);         

            //graphics.DrawEllipse(_ColorSchemePen, CurrentRect);
            var animationValue = objAnimationManager.GetProgress();
            //graphics.DrawEllipse(_ColorSchemePen, CurrentRect);
            //var rippleRadius = (int)(animationValue * 40 * 2);
            var rippleSize = (int)(animationValue * 30 * 2);
            Debug.WriteLine(animationValue);
            Point animationSource = objAnimationManager.GetSource(0);
            Rectangle outer = new Rectangle(100 - rippleSize / 2, 100 - rippleSize / 2, rippleSize, rippleSize);
            var thirdRipple = (int)(animationValue * 10 * 2);
            Rectangle thirdCircle = new Rectangle(100 - thirdRipple / 2, 100 - thirdRipple / 2, thirdRipple, thirdRipple);
            //graphics.DrawEllipse(_ColorSchemePen, outer);
            // TODO: reduce the opacity of the ripple's color. 
            // T            
            //Color rippleColor = Color.FromArgb(((byte) 100 - (byte)(objAnimationManager.GetProgress() * 0.4)), Color.Red);
            Color rippleColor = Color.FromArgb(((byte)250 - (byte)(objAnimationManager.GetProgress() * 270)), Color.Red);
            graphics.FillEllipse(new SolidBrush(rippleColor), outer);
            //graphics.DrawEllipse(new Pen(Color.Blue,4), thirdCircle);
            graphics.DrawEllipse(new Pen(rippleColor, 4), outer);
            Rectangle inner = new Rectangle(100 - 10 / 2, 100 - 10 / 2, 10, 10);
            graphics.FillEllipse(new SolidBrush(Color.Blue), inner);

            int radius = 30;
            Color internalRippleColor = Color.FromArgb(((byte)250 - (byte)(objAnimationManager.GetProgress() * 250)), Color.SteelBlue);
            for (int i = 0; i < 2; i++)
            {
                rippleSize = (int)(animationValue * radius * 1);
                Rectangle rect = new Rectangle(100 - rippleSize / 2, 100 - rippleSize / 2, rippleSize, rippleSize);
                Pen bluePen = new Pen(internalRippleColor, 5);
                bluePen.DashStyle = DashStyle.DashDot;
                graphics.DrawEllipse(bluePen, rect);
                radius += 30;
            }

            //g.FillEllipse(rippleBrush, new Rectangle(animationSource.X - rippleRadius / 2, animationSource.Y - rippleRadius / 2, rippleRadius, rippleRadius));

            //CurrentRect.Height -=5; CurrentRect.Width -= 5;
            //graphics.DrawEllipse(_ColorSchemePen, CurrentRect);
        }

        private void GenerateOriginalBitmap()
        {
            Original = CreateImage();
        }
        public Bitmap CreateImage()
        {
            Bitmap bmp = new Bitmap(_BaseForm.Width / 2, _BaseForm.Height / 2);
            _BaseForm.DrawToBitmap(bmp, new Rectangle(0, 0, _BaseForm.Width / 2, _BaseForm.Height / 2));
            //objDimmer.DrawToBitmap(DimmerBitmap, new Rectangle(0, 0, _BaseForm.Width, _BaseForm.Height));
            //Graphics.FromImage(bmp).DrawImageUnscaled(ChangeImageOpacity(DimmerBitmap, 222), 0, 0);
            DrawToBitmap(bmp, new Rectangle(Location.X - _BaseForm.Location.X, Location.Y - _BaseForm.Location.Y, Width / 2, Height / 2));

            return bmp;
        }
        protected override void OnLoad(EventArgs e)
        {
            //Opacity = 0;
            base.OnLoad(e);
            //this.Location = Parent.Location;
            //this.Size = Parent.Size;

            GenerateOriginalBitmap();
            BackgroundImage = Original;
            //TopMost = true;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            /*objAnimationManager.SetProgress(0);
            _Origin = PointToClient(_Origin); ;
            objAnimationManager.StartNewAnimation(AnimationDirection.In);*/
        }

        // DISABLED: since I have two or more ripples. 
        private Rectangle CalculateCurrentRect()
        {
            Rectangle newRectangle = new Rectangle();

            double xEdge = (Width / 2 >= _Origin.X ? Width / 2 : 0);
            double YEdge = (Height / 2 >= _Origin.Y ? Height / 2 : 0);

            // TODO: fade the color of the circle based on the current animation progress.
            //double radiusMax = Math.Sqrt(Math.Pow(_Origin.X - xEdge, 2) + Math.Pow(_Origin.Y - YEdge, 2));
            double radiusMax = 130;
            radiusMax *= 2;
            double radius = radiusMax * objAnimationManager.GetProgress();
            //double radius = 15;
            double top = _Origin.Y - (radius / 2);
            double Left = _Origin.X - (radius / 2);
            newRectangle.Location = new Point((int)Left, (int)top);
            newRectangle.Size = new Size((int)radius, (int)radius);
            return newRectangle;
        }
        private const int bytesPerPixel = 4;

        internal void StartAnimation()
        {
            if (!objAnimationManager.IsAnimating())
            {
                objAnimationManager.SetProgress(0);
                _Origin = new Point(Width / 2, Height / 2);
                //objAnimationManager.StartNewAnimation(AnimationDirection.InOutIn);
                objAnimationManager.StartNewAnimation(AnimationDirection.In);
            }
        }

        internal void ShowForm()
        {
            Show();
            StartAnimation();
        }



        /*  protected override CreateParams CreateParams
          {
              get
              {
                  const int WS_EX_LAYERED = 0x80000;
                  const int WS_EX_TRANSPARENT = 0x20;
                  CreateParams cp = base.CreateParams;
                  cp.ExStyle |= WS_EX_LAYERED;
                  //cp.ExStyle |= WS_EX_TRANSPARENT;
                  int WS_EX_TOPMOST = 0x00000008;
                  cp.ExStyle |= WS_EX_TOPMOST;
                  return cp;
              }
          }*/
        // Make layered.
        /*protected override CreateParams CreateParams
        {
            get
            {
                const int CS_DROPSHADOW = 0x20000;
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }*/
        /*    protected override CreateParams CreateParams
            {
                get
                {
                    // Extend the CreateParams property of the Button class.
                    CreateParams cp = base.CreateParams;
                    // Update the button Style.
                    //cp.Style |= 0x00000040; // BS_ICON value
                    cp.Style |= Convert.ToInt32(ExtendedWinStyles.WS_CUSTOM_TRASPARENT_WINDOW);
                    //cp.Style |= Convert.ToInt32(ExtendedWinStyles.WS_EX_LAYERED | ExtendedWinStyles.WS_EX_TOPMOST);

                    return cp;
                }
            }*/
    }
}