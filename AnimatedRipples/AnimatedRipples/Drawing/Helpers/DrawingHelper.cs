using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormLayered.Drawing.Helpers;

namespace WinFormLayered.Drawing
{
    internal class DrawingHelper
    {

        public static Bitmap CreateBitmap(int width, int height, Color inColor)
        {
            if (width > 0 && height > 0)
            {
                Bitmap bmp = new Bitmap(width, height, PixelFormat.Format32bppArgb);

                using (Graphics graphics = Graphics.FromImage(bmp))
                {
                    graphics.Clear(inColor);
                }
                return bmp;
            }
            return null;
        }

        /// <summary>
        /// Creates a bounding rectangle for a ripple drawing.
        /// </summary>
        /// <param name="rippleRadius"></param>
        /// <returns></returns>
        internal static Rectangle CreateRectangle(int width, int height, int radius)
        {
            return new Rectangle(width / 2 - radius, height / 2 - radius, radius * 2, radius * 2);
        }
        internal static void SetAntiAliasing(System.Drawing.Graphics graphics)
        {
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphics.CompositingQuality = CompositingQuality.HighQuality;
        }

        internal static List<PointF> GetHexagonPoints(int x, int y, int radius)
        {
            //Get the middle of the panel            
            List<PointF> shapes = new List<PointF>(6);
            //Create 6 points
            for (int line = 0; line < shapes.Count; line++)
            {  //- TODO: put this in a method. We need to create the shapes once and update the radius on animation progress.              
                shapes[line] = new PointF(
                    x + radius * (float)Math.Cos(line * 60 * Math.PI / 180f),
                    y + radius * (float)Math.Sin(line * 60 * Math.PI / 180f));
            }
            return shapes;
        }

        public static void DrawShadow(Graphics G, GraphicsPath GP, int d, Color pBackColor)
        {
            Color[] colors = GetColorVector(Color.Black, pBackColor, d).ToArray();
            for (int i = 0; i < d; i++)
            {
                G.TranslateTransform(1f, 0.75f);                // <== shadow vector!
                using (Pen pen = new Pen(colors[i], 1.75f))  // <== pen width (*)
                    G.DrawPath(pen, GP);
            }
            G.ResetTransform();
        }
        public static GraphicsPath CreateCircle(float x, float y, float radius)
        {
            GraphicsPath gp = new GraphicsPath();
            gp.AddEllipse(x, y, radius * 2, radius * 2);
            return gp;
        }

        private static List<Color> GetColorVector(Color fc, Color bc, int depth)
        {
            List<Color> cv = new List<Color>();
            float dRed = 1f * (bc.R - fc.R) / depth;
            float dGreen = 1f * (bc.G - fc.G) / depth;
            float dBlue = 1f * (bc.B - fc.B) / depth;
            for (int d = 1; d <= depth; d++)
                cv.Add(Color.FromArgb(60, (int)(fc.R + dRed * d),
                  (int)(fc.G + dGreen * d), (int)(fc.B + dBlue * d)));
            return cv;
        }
        public static Color RandomColor()
        {
            return Color.FromArgb(RandomFast.Next(255), RandomFast.Next(255), RandomFast.Next(255));
        }
    }
}
