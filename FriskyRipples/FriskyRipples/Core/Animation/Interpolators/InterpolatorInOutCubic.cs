using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrostyBee.FriskyRipples.Animation
{
    internal class InterpolatorInOutCubic : IValueInterpolatable
    {        

        public double Interpolate(double progress)
        {
            return progress < 0.5 ? 4 * Math.Pow(progress, 3) : 1 - Math.Pow(-2 * progress + 2, 3) / 2;
        }
    }
}
