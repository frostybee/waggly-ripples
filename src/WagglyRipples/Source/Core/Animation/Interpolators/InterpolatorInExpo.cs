using System;

namespace FrostyBee.FriskyRipples.Animation
{
    internal class InterpolatorInExpo
    {        

        public double Interpolate(double progress)
        {            
            double p = progress;
            return (p == 0.0d) ? p : Math.Pow(2d, 10d * (p - 1d));
        }
    }
}
