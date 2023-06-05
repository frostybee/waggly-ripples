using System;

namespace FrostyBee.FriskyRipples.Animation
{
    internal class InterpolatorOutElastic 
    {
        private double c4 = (2 * Math.PI) / 3;
        internal const double HALFPI = Math.PI / 2d;
        public double Interpolate(double progress)
        {
            //return progress == 0 ? 0 : progress == 1 ? 1 : Math.Pow(2, -10 * progress) * Math.Sin((progress * 10 - 0.75) * c4) + 1;
            double p = progress;
            return Math.Sin(-13d * HALFPI * (p + 1)) * Math.Pow(2d, -10d * p) + 1d;

        }
    }
}
