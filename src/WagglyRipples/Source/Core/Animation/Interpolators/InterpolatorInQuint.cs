using System;

namespace FrostyBee.FriskyRipples.Animation
{
    internal class InterpolatorInQuint : IValueInterpolatable
    {        

        public double Interpolate(double progress)
        {
            return Math.Pow(progress, 5);
        }
    }
}
