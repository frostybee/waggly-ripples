using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
