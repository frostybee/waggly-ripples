using System;

namespace FrostyBee.FriskyRipples.Animation
{
    internal class InterpolatorInOutElastic 
    {
        private double c5 = (2 * Math.PI) / 4.5;
        public double Interpolate(double time)
        {
            return time == 0
              ? 0
              : time == 1
              ? 1
              : time < 0.5
              ? -(Math.Pow(2, 20 * time - 10) * Math.Sin((20 * time - 11.125) * c5)) / 2
              : (Math.Pow(2, -20 * time + 10) * Math.Sin((20 * time - 11.125) * c5)) / 2 + 1;
        }
    }
}
