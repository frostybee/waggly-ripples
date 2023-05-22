using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrostyBee.FriskyRipples.Animation
{
    internal class InterpolatorEaseInOut : IValueInterpolatable
    {
        private double PI = Math.PI;
        private double PI_HALF = Math.PI / 2;
        public double Interpolate(double progress)
        {
            return EaseInOut(progress);
        }

        private double EaseInOut(double time)
        {
            return time - Math.Sin(time * 2 * PI) / (2 * PI);
        }
    }
}
