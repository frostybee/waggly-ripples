using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace FrostyBee.FriskyRipples.Animation
{
    internal class InterpolatorEaseInOut : IValueInterpolatable
    {
        private double PI = Math.PI;
        private double PI_HALF = Math.PI / 2;
        public double Interpolate(double time)
        {
            return time - Math.Sin(time * 2 * PI) / (2 * PI);
        }        

    }
}
