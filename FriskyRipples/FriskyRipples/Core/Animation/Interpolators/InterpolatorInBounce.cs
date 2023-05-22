using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrostyBee.FriskyRipples.Animation
{
    internal class InterpolatorInBounce : IValueInterpolatable
    {
        private readonly InterpolatorOutBounce _outBounceInterpolator = new InterpolatorOutBounce();
        public double Interpolate(double progress)
        {
            return 1 - _outBounceInterpolator.Interpolate(1 - progress);            
        }
    }
}
