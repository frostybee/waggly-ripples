using System;

namespace FrostyBee.FriskyRipples.Animation
{
    internal class InterpolatorInCubic : IValueInterpolatable
    {        

        public double Interpolate(double progress)
        {
            return Math.Pow(progress, 3);
        }
    }
}
