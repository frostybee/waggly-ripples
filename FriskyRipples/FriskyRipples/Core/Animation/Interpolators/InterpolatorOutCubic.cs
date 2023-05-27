using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrostyBee.FriskyRipples.Animation
{
    internal class InterpolatorOutQuint : IValueInterpolatable
    {        
        public double Interpolate(double progress)
        {
            return 1 - Math.Pow(1 - progress, 5);
        }
    }
}
