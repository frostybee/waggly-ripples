using System;

namespace FrostyBee.FriskyRipples.Animation
{
    internal class InterpolatorInCubic
    {        

        public double Interpolate(double progress)
        {
            return Math.Pow(progress, 3);
        }
    }
}
