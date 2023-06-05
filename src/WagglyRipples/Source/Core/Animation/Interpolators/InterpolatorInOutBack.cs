using System;

namespace FrostyBee.FriskyRipples.Animation
{
    internal class InterpolatorInOutBack 
    {
        private const double c1 = 2.70158;
        private const double c2 = c1 * 1.525;
        public double Interpolate(double t)
        {
            return t < 0.5 ? (Math.Pow(2 * t, 2) * ((c2 + 1) * 2 * t - c2)) / 2
                            : (Math.Pow(2 * t - 2, 2) * ((c2 + 1) * (t * 2 - 2) + c2) + 2) / 2;
        }
    }
}
