using FriskyMouse.NativeApi;
using FriskyMouse.UI;
using MaterialWinforms.Animations;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormLayered.LayeredForm
{
    internal class RipplesController
    {
        LayeredWindow layered;        
        Bitmap bitmap = null;
        /// <summary>
        /// The drawing canvas on which the mouse click ripples will be repeatedly drawn.
        /// </summary>
        Graphics graphics;
        private AnimationManager objAnimationManager;
        public RipplesController()
        {
            this.layered = new LayeredWindow();
            objAnimationManager = new AnimationManager()
            {
                Increment = 0.035,
                //Increment = 0.010,
                //Increment = 0.070,
                //AnimationType = AnimationType.EaseOut,                
                //AnimationType = AnimationType.SpringInteropolator
                AnimationType = AnimationType.Linear

            };
            objAnimationManager.SetDirection(AnimationDirection.InOutRepeatingIn);
            objAnimationManager.OnAnimationProgress += ObjAnimationManager_OnAnimationProgress;
            objAnimationManager.OnAnimationFinished += objAnimationManager_OnAnimationFinished;
        }

        private void ObjAnimationManager_OnAnimationProgress(object sender)
        {
            // We perform the drawing here.            
            //DrawManyRipples(graphics);
            DrawExpandingCircle(graphics);
        }


        private void DrawManyRipples(Graphics graphics)
        {
            //e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            //e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;            
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
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

            Rectangle outer = CreateRectangle(rippleSize);
            var thirdRipple = (int)(animationValue * 10 * 2);
            Rectangle thirdCircle = CreateRectangle(thirdRipple);
            //graphics.DrawEllipse(_ColorSchemePen, outerRect);

            // TODO: reduce the opacity of the ripple's color.                        

            Color rippleColor = Color.Red;
            graphics.FillEllipse(new SolidBrush(rippleColor), outer);
            //graphics.DrawEllipse(new Pen(Color.Blue,4), thirdCircle);
            graphics.DrawEllipse(new Pen(rippleColor, 4), outer);
            Rectangle inner = new Rectangle(100 - 10 / 2, 100 - 10 / 2, 10, 10);
            graphics.FillEllipse(new SolidBrush(Color.Blue), inner);

            int radius = 30;
            //Color internalRippleColor = Color.FromArgb(((byte)250 - (byte)(objAnimationManager.GetProgress() * 50)), Color.SteelBlue);
            Color internalRippleColor = Color.SteelBlue;
            for (int i = 0; i < 2; i++)
            {
                rippleSize = (int)(animationValue * radius * 1);
                Rectangle rect = CreateRectangle(rippleSize);
                Pen bluePen = new Pen(internalRippleColor, 3);
                bluePen.DashStyle = DashStyle.DashDot;
                graphics.DrawEllipse(bluePen, rect);
                radius += 30;
            }

            //g.FillEllipse(rippleBrush, new Rectangle(animationSource.X - rippleRadius / 2, animationSource.Y - rippleRadius / 2, rippleRadius, rippleRadius));
            //CurrentRect.Height -=5; CurrentRect.Width -= 5;
            //graphics.DrawEllipse(_ColorSchemePen, CurrentRect);
            layered.SetBitmap(bitmap, 200);
        }
        /// <summary>
        /// Creates a bounding rectangle that bounds a ripple drawing.
        /// </summary>
        /// <param name="rippleRadius"></param>
        /// <returns></returns>
        private Rectangle CreateRectangle(int rippleRadius)
        {
            return new Rectangle(bitmap.Width / 2 - rippleRadius, bitmap.Height / 2 - rippleRadius, rippleRadius * 2, rippleRadius * 2);
        }

        // This is an expanding circle drawing profile.
        private void DrawExpandingCircle(Graphics graphics)
        {
            // TODO: put this in a helper method.
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphics.CompositingQuality = CompositingQuality.HighQuality;
            graphics.Clear(Color.Transparent);
            int width = 100;
            var animationValue = objAnimationManager.GetProgress();
            int baseRadius = 40;
            // Expand the size of the radius.
            var rippleRadius = (int)(animationValue * baseRadius * 2);
            Rectangle innerRect = new Rectangle(width - 10 / 2, width - 10 / 2, 10, 10);
            //Rectangle innerRect = CreateRectangle(rippleRadius);
            // Color of the large ripple
            Color rippleColor = Color.FromArgb(((byte)250 - (byte)(objAnimationManager.GetProgress() * 100 )), Color.Bisque);
            //Color rippleColor = Color.Red;
            // FIXME: the following objects needs to be created once in advance. 
            using (SolidBrush blueBrush = new SolidBrush(Color.Red))
            using (SolidBrush innerBrush = new SolidBrush(rippleColor))
            using (Pen outlinePen = new Pen(Color.Crimson, 2)) // Pen of the outline
            {                
                Rectangle outerRect = new Rectangle(width - rippleRadius / 2, width - rippleRadius / 2, rippleRadius, rippleRadius);
                // Adjust the ripple's color based on the current progress of the running animation. 
                // NOTE: the value of the opacity needs to be validated < 255                
                graphics.FillEllipse(innerBrush, outerRect);
                graphics.DrawEllipse(outlinePen, outerRect);
                graphics.FillEllipse(blueBrush, innerRect); // Needs to be drawn last!
                // TODO: Draw a circle outline à la Google Maps ripple
                // - Also, draw circle in the middle after the innerRect one. 
                // TODO: Look for drawing helpers in ShareX and other libraries. 
                layered.SetBitmap(bitmap, 255);
            }                                               
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
        internal void StartAnimation()
        {
            if (this.bitmap == null)
            {
                // Need to be disposed.
                // Check memory consumption of this version.
                this.bitmap = new Bitmap(200, 200);
                graphics = Graphics.FromImage(bitmap);
            }

            Debug.WriteLine("Updating....");
            // We perform the drawing here.            


            /*
             IntAnimate animate = new IntAnimate();//animate.Start(int duration, T initial, T end, EasingType easing = EasingType.Linear)
              animate.Start(1000, 1, 30, EasingType.Linear);
              animate.Complete = OnAnimationCompleted;
              animate.Update += OnAnimationUpdated;
              animate.Start(1000);*/            
            if (!objAnimationManager.IsAnimating())
            {
                objAnimationManager.SetProgress(0);
                //objAnimationManager.StartNewAnimation(AnimationDirection.InOutIn);
                objAnimationManager.StartNewAnimation(AnimationDirection.InOutIn);
            }

        }
        int _radius = 0;
        private void objAnimationManager_OnAnimationFinished(object sender)
        {
            //-- Long lasting ripple: show it and hide on finish. 
            Debug.WriteLine("Finished....");
            //layered.SetBitmap(new Bitmap(200, 200), 1);
            graphics.Clear(Color.Transparent);
            layered.Hide();
        }
    }
}
