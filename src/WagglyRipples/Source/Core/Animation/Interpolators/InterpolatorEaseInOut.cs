using System;

namespace FrostyBee.FriskyRipples.Animation
{
    internal class InterpolatorEaseInOut  
    {
        public double Interpolate(double time)
        {            
            return -(Math.Cos(Math.PI * time) - 1) / 2;
        }

    }
}
