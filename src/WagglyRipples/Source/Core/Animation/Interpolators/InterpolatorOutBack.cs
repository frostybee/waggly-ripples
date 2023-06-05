using System;

namespace FrostyBee.FriskyRipples.Animation
{
    internal class InterpolatorOutBack 
    {        
        private const double c1 = 1.70158;
        private const double c3 = c1 + 1;
        public double Interpolate(double progress)
        {
            //return 1 + c3 * Math.Pow(progress - 1, 3) + c1 * Math.Pow(progress - 1, 2);
            return progress * (progress * progress - Math.Sin(progress * Math.PI));
            /*double progress = 1d - progress;
            return 1 - progress * (progress * progress - Math.Sin(progress * Math.PI));*/
        }
    }
}
